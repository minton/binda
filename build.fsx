// include Fake lib
#r "tools/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile
open Fake.Testing.NUnit3
open System
open System.IO

let authors = ["@minton"; "@hotgazpacho"; "@brycekbargar"]
let projectName = "Binda"
let projectDescription = "Smart WinForms Data Binding"

let debugDir = __SOURCE_DIRECTORY__ + @"\src\binda\bin\Debug\"
let releaseDir = __SOURCE_DIRECTORY__ + @"\src\binda\bin\Release\"
//Hard coded paths since f# via FAKE always returns x86 ProgramFiles
let nunit = __SOURCE_DIRECTORY__ + @"\src\packages\NUnit.ConsoleRunner.3.2.0\tools\nunit3-console.exe"
let packages = __SOURCE_DIRECTORY__ + @"\src\packages"
let version = getBuildParamOrDefault "ver" "0.0.1"
let testAssemblies = !! (@"src\binda.tests\bin\Debug\binda.tests.dll")
let packagingRoot = "./packaging/"
let packagingDir = packagingRoot @@ "binda"

let releaseNotes = 
    ReadFile "ReleaseNotes.md"
    |> ReleaseNotesHelper.parseReleaseNotes
    
//Helper
let rec getAllFiles dir pattern =
    seq { yield! Directory.EnumerateFiles(dir, pattern)
          for d in Directory.EnumerateDirectories(dir) do
              yield! getAllFiles d pattern }
    
//Restore Nuget stuff
Target "RestorePackages" (fun _ -> 
     "./src/binda.sln"
     |> RestoreMSSolutionPackages (fun _ ->
         RestorePackageDefaults)
 )

// Clean out the directories
Target "Clean" (fun _ ->
    CleanDirs [debugDir; releaseDir; packagingRoot; packagingDir;]
    CopyFile packagingDir "ReleaseNotes.md"

    let setParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Clean"]
            Properties =
                [
                    "Configuration", "Release"
                ]
         }
    build setParams "./src/binda.sln"  
    
    let setParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Clean"]
            Properties =
                [
                    "Configuration", "Debug"
                ]
         }
    build setParams "./src/binda.sln"    
)

//Update version info before building
Target "UpdateAssemblyInfo" (fun _ ->
    let csharpAssemblyInfos = getAllFiles __SOURCE_DIRECTORY__ "AssemblyInfo.cs"
    let assemblyAttributes =   [Attribute.Title projectName
                                Attribute.Description projectDescription
                                Attribute.Version version
                                Attribute.FileVersion version]
    csharpAssemblyInfos
    |> Seq.iter (fun i -> UpdateAttributes i assemblyAttributes)
)

Target "BuildRelease" (fun _ ->
    let setParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Build"]
            Properties =
                [
                    "Optimize", "True"
                    "DebugSymbols", "True"
                    "Configuration", "Release"
                ]
         }
    build setParams "./src/binda.sln"       
)

Target "BuildAppDebug" (fun _ ->
    let setParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Build"]
            Properties =
                [
                    "Configuration", "Debug"
                ]
         }
    build setParams "./src/binda.sln"       
)

Target "NUnitTests" (fun _ ->
    testAssemblies
    |> NUnit3 (fun p ->
        { p with
            TimeOut = TimeSpan.FromMinutes 20. })      
)

Target "BuildAndTest" (fun _ ->
    trace "Built and ran tests."
)

Target "CreatePackage" (fun _ ->
    let net45Dir = packagingDir @@ "lib/net45/"
    CleanDir net45Dir

    CopyFile net45Dir (releaseDir @@ "Binda.dll")
    CopyFile net45Dir (releaseDir @@ "Inflector.dll")
    
    let key = environVarOrFail "nugetkey"
    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName
            Description = projectDescription
            OutputPath = packagingRoot
            Summary = projectDescription
            WorkingDir = packagingDir
            Version = version
            ReleaseNotes = toLines releaseNotes.Notes
            AccessKey = key
            Publish = true }) "binda.nuspec"
)

// Dependencies
"Clean"
  ==> "RestorePackages"
  ==> "UpdateAssemblyInfo"
  ==> "BuildRelease"
"Clean"
  ==> "RestorePackages"
  ==> "BuildAppDebug"
  ==> "NUnitTests"
  ==> "BuildAndTest"
"BuildRelease"
  ==> "CreatePackage"

// default task
RunTargetOrDefault "BuildAndTest"