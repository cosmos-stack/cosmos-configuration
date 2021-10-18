@echo off

echo =======================================================================
echo CosmosStack.Configuration
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
dotnet pack src/CosmosStack.Configuration/CosmosStack.Configuration.csproj                                 -c Release -o nuget_packages --no-restore

::adapters
dotnet pack src/CosmosStack.Configuration.CliAdapter/CosmosStack.Configuration.CliAdapter.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Configuration.IniAdapter/CosmosStack.Configuration.IniAdapter.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Configuration.JsonAdapter/CosmosStack.Configuration.JsonAdapter.csproj         -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Configuration.TomlAdapter/CosmosStack.Configuration.TomlAdapter.csproj         -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Configuration.XmlAdapter/CosmosStack.Configuration.XmlAdapter.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Configuration.YamlAdapter/CosmosStack.Configuration.YamlAdapter.csproj         -c Release -o nuget_packages --no-restore

::extensions
dotnet pack src/CosmosStack.Configuration.Extensions.ConsoleApp/CosmosStack.Configuration.Extensions.ConsoleApp.csproj -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Configuration.Extensions.WebApp/CosmosStack.Configuration.Extensions.WebApp.csproj         -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Release" --skip-duplicate
	echo.
)

::get back to build folder
cd scripts