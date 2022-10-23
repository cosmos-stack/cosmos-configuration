using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Adapters;

public static class CosmosJsonAdapterExtensions
{
    public static ConfigurationStarter AddJsonFile(this ConfigurationStarter starter, string path)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(path));
    }

    public static ConfigurationStarter AddJsonFile(this ConfigurationStarter starter, string path, bool optional)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(path, optional));
    }

    public static ConfigurationStarter AddJsonFile(this ConfigurationStarter starter, string path, bool optional, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(path, optional, reloadOnChange));
    }

    public static ConfigurationStarter AddJsonFile(this ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(provider, path, optional, reloadOnChange));
    }

    public static ConfigurationStarter AddJsonFileOptional(this ConfigurationStarter starter, string path)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(path, true));
    }

    public static ConfigurationStarter AddJsonFileOptional(this ConfigurationStarter starter, string path, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(path, true, reloadOnChange));
    }
#if !NET451 && !NET452
    public static ConfigurationStarter AddJsonConfigurationSource(this ConfigurationStarter starter, Action<JsonConfigurationSource> configureSource)
    {
        return starter.AddConfig(updater => updater.AddJsonFile(configureSource));
    }

    public static ConfigurationStarter AddJsonStream(this ConfigurationStarter starter, Stream stream)
    {
        return starter.AddConfig(updater => updater.AddJsonStream(stream));
    }
#endif
}