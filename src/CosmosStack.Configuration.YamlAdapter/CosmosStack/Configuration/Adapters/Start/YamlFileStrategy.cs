#if !NET451 && !NET452
using System;
using System.IO;
using Alexinea.Extensions.Configuration.Yaml;
using CosmosStack.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
#else
using CosmosStack.Configuration.Start;
using Microsoft.Extensions.FileProviders;

#endif

namespace CosmosStack.Configuration.Adapters.Start
{
#if !NET451 && !NET452
    public class YamlFileStrategy : 
        IFileStrategy,
        IStreamStrategy,
        IConfigurationSourceStrategy
#else
    public class YamlFileStrategy :
        IFileStrategy
#endif
    {
        public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            starter.AddYamlFile(provider, path, optional, reloadOnChange);
        }
#if !NET451 && !NET452
        public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
        {
            if (typeof(TConfigurationSource) != typeof(YamlConfigurationSource)) return;
            starter.AddYamlConfigurationSource(source => (configureSource as Action<YamlConfigurationSource>)?.Invoke(source));
        }

        public void AddStream(ConfigurationStarter starter, Stream stream)
        {
            starter.AddYamlStream(stream);
        }
#endif
    }
}