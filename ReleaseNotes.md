## New in 0.1.3 (Released 2025/07/16)

**Features**
 - Enable binding to/from any System.Windows.Forms.Control - #20 by @brainbolt

## New in 0.1.2 (Released 2017/09/05)

**Features**
 - Allow null values for the KeyValueStrategy - #17 via @brycekbargar

## New in 0.1.1 (Released 2016/04/28)

**Features**
 - Bind to and from Panel Controls - #15 via @brycekbargar
 - Add a strategy for `KeyValuePair`s - #14 via @brycekbargar
 - Allow registration of strategies per-control - #12 via @brycekbargar
 
## New in 0.1.0 (Released 2016/03/18)

**Features**
 - Add Support for UserControl - #8 via @brycekbargar
 - Add FAKE build script - #9 via @minton
 - Migrate to NUnit - #10 via @minton

**Other**

 - Add a spiffy NuGet icon - #11 via @minton

**Breaking Changes**

`AddRegistration(Type control, string property, Type type)` has been removed from this release.
