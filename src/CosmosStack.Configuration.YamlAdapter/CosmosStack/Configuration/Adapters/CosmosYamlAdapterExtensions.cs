using System;
using System.IO;
using Alexinea.Extensions.Configuration.Yaml;
using CosmosStack.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace CosmosStack.Configuration.Adapters
{
    public static class CosmosYamlAdapterExtensions
    {
        public static ConfigurationStarter AddYamlFile(this ConfigurationStarter starter, string path)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(path));
        }

        public static ConfigurationStarter AddYamlFile(this ConfigurationStarter starter, string path, bool optional)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(path, optional));
        }

        public static ConfigurationStarter AddYamlFile(this ConfigurationStarter starter, string path, bool optional, bool reloadOnChange)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(path, optional, reloadOnChange));
        }

        public static ConfigurationStarter AddYamlFile(this ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(provider, path, optional, reloadOnChange));
        }

        public static ConfigurationStarter AddYamlFileOptional(this ConfigurationStarter starter, string path)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(path, true));
        }

        public static ConfigurationStarter AddYamlFileOptional(this ConfigurationStarter starter, string path, bool reloadOnChange)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(path, true, reloadOnChange));
        }
#if !NET451 && !NET452
        public static ConfigurationStarter AddYamlConfigurationSource(this ConfigurationStarter starter, Action<YamlConfigurationSource> configureSource)
        {
            return starter.AddConfig(updater => updater.AddYamlFile(configureSource));
        }

        public static ConfigurationStarter AddYamlStream(this ConfigurationStarter starter, Stream stream)
        {
            return starter.AddConfig(updater => updater.AddYamlStream(stream));
        }
#endif
    }
}