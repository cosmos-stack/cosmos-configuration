using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Xml;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Adapters;

public static class CosmosXmlAdapterExtensions
{
    public static ConfigurationStarter AddXmlFile(this ConfigurationStarter starter, string path)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(path));
    }

    public static ConfigurationStarter AddXmlFile(this ConfigurationStarter starter, string path, bool optional)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(path, optional));
    }

    public static ConfigurationStarter AddXmlFile(this ConfigurationStarter starter, string path, bool optional, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(path, optional, reloadOnChange));
    }

    public static ConfigurationStarter AddXmlFile(this ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(provider, path, optional, reloadOnChange));
    }

    public static ConfigurationStarter AddXmlFileOptional(this ConfigurationStarter starter, string path)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(path, true));
    }

    public static ConfigurationStarter AddXmlFileOptional(this ConfigurationStarter starter, string path, bool reloadOnChange)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(path, true, reloadOnChange));
    }
#if !NET451 && !NET452
    public static ConfigurationStarter AddXmlConfigurationSource(this ConfigurationStarter starter, Action<XmlConfigurationSource> configureSource)
    {
        return starter.AddConfig(updater => updater.AddXmlFile(configureSource));
    }

    public static ConfigurationStarter AddXmlStream(this ConfigurationStarter starter, Stream stream)
    {
        return starter.AddConfig(updater => updater.AddXmlStream(stream));
    }
#endif
}