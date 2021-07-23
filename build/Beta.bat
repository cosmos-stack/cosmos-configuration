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
dotnet pack src/Cosmos.Configuration/Cosmos.Configuration.csproj                                 -c Release -o nuget_packages --no-restore

::adapters
dotnet pack src/Cosmos.Configuration.CliAdapter/Cosmos.Configuration.CliAdapter.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.IniAdapter/Cosmos.Configuration.IniAdapter.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.JsonAdapter/Cosmos.Configuration.JsonAdapter.csproj         -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.TomlAdapter/Cosmos.Configuration.TomlAdapter.csproj         -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.XmlAdapter/Cosmos.Configuration.XmlAdapter.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.YamlAdapter/Cosmos.Configuration.YamlAdapter.csproj         -c Release -o nuget_packages --no-restore

::extensions
dotnet pack src/Cosmos.Configuration.Extensions.ConsoleApp/Cosmos.Configuration.Extensions.ConsoleApp.csproj -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Configuration.Extensions.WebApp/Cosmos.Configuration.Extensions.WebApp.csproj         -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Beta" --skip-duplicate
	echo.
)

::get back to build folder
cd build