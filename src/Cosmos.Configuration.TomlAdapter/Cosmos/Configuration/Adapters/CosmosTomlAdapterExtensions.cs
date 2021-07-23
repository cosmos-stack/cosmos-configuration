using System;
using System.IO;
using Alexinea.Extensions.Configuration.Toml;
using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
#if !NET451 && !NET452
#else
#endif
namespace Cosmos.Configuration.Adapters
{
    public static class CosmosTomlAdapterExtensions
    {
        public static ConfigurationStarter AddTomlFile(this ConfigurationStarter starter, string path)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(path));
        }

        public static ConfigurationStarter AddTomlFile(this ConfigurationStarter starter, string path, bool optional)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(path, optional));
        }

        public static ConfigurationStarter AddTomlFile(this ConfigurationStarter starter, string path, bool optional, bool reloadOnChange)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(path, optional, reloadOnChange));
        }

        public static ConfigurationStarter AddTomlFile(this ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(provider, path, optional, reloadOnChange));
        }

        public static ConfigurationStarter AddTomlFileOptional(this ConfigurationStarter starter, string path)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(path, true));
        }

        public static ConfigurationStarter AddTomlFileOptional(this ConfigurationStarter starter, string path, bool reloadOnChange)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(path, true, reloadOnChange));
        }
#if !NET451 && !NET452
        public static ConfigurationStarter AddTomlConfigurationSource(this ConfigurationStarter starter, Action<TomlConfigurationSource> configureSource)
        {
            return starter.AddConfig(updater => updater.AddTomlFile(configureSource));
        }

        public static ConfigurationStarter AddTomlStream(this ConfigurationStarter starter, Stream stream)
        {
            return starter.AddConfig(updater => updater.AddTomlStream(stream));
        }
#endif
    }
}