@echo off

echo =======================================================================
echo Cosmos.Configuration
echo =======================================================================

::go to parent folder
cd ..

::create nuget_packages
if not exist nuget_packages (
    md nuget_packages
    echo Created nuget_packages folder.
)

::clear nuget_packages
for /R "nuget_packages" %%s in (*) do (
    del "%%s"
)
echo Cleaned up all nuget packages.
echo.

::start to package all projects

::core
dotnet pack src/Cosmos.Configuration             -c Release -o nuget_packages --no-restore

::adapters
dotnet pack src/Cosmos.Configuration.CliAdapter  -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.IniAdapter  -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.JsonAdapter -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.TomlAdapter -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.XmlAdapter  -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.YamlAdapter -c Release -o nuget_packages --no-restore

::extensions
dotnet pack src/Cosmos.Configuration.Bundles.CliAppPackage -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.Bundles.WebAppPackage -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do (
::    dotnet nuget push "%%s" -s "Beta" --skip-duplicate --no-symbols
    dotnet nuget push "%%s" -s "Release" --skip-duplicate
    echo.
)

::get back to build folder
cd scripts