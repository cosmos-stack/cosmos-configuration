using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration.Ini;

namespace Cosmos.Configuration.Adapters;

public static class CosmosIniAdapterExtensions
{
    public static ConfigurationStarter AddIniFile(this ConfigurationStarter starter, string path)
    {
        return starter.AddConfig(updater => updater.AddIniFile(path));
    }

    public static ConfigurationStarter AddIniFile(this ConfigurationStarter starter, string path, bool optional)
    {
        return starter.AddConfig(updater => updater.AddIniFile(path, optional));
    }

    public static ConfigurationStarter AddIniFile(this ConfigurationStarter starter, string path, bool optional, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddIniFile(path, optional, reloadOnChange));
    }

    public static ConfigurationStarter AddIniFile(this ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddIniFile(provider, path, optional, reloadOnChange));
    }

    public static ConfigurationStarter AddIniFileOptional(this ConfigurationStarter starter, string path)
    {
        return starter.AddConfig(updater => updater.AddIniFile(path, true));
    }

    public static ConfigurationStarter AddIniFileOptional(this ConfigurationStarter starter, string path, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddIniFile(path, true, reloadOnChange));
    }

    public static ConfigurationStarter AddIniConfigurationSource(this ConfigurationStarter starter, Action<IniConfigurationSource> configureSource)
    {
        return starter.AddConfig(updater => updater.AddIniFile(configureSource));
    }

    public static ConfigurationStarter AddIniStream(this ConfigurationStarter starter, Stream stream)
    {
        return starter.AddConfig(updater => updater.AddIniStream(stream));
    }
}