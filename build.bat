@echo off
pushd %~dp0
if not exist "tools\FAKE\tools\Fake.exe" "src\.nuget\NuGet.exe" "Install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion"

IF [%1]==[] GOTO DEFAULTTASK
IF [%2]==[] GOTO SINGLETASK
"tools\FAKE\tools\Fake.exe" build.fsx %1 ver=%2
GOTO END
:SINGLETASK
"tools\FAKE\tools\Fake.exe" build.fsx %1
GOTO END
:DEFAULTTASK
"tools\FAKE\tools\Fake.exe" build.fsx
:end
