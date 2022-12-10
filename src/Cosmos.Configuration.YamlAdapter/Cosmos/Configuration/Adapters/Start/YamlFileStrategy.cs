using Cosmos.Configuration.Start;
using Microsoft.Extensions.FileProviders;
using Alexinea.Extensions.Configuration.Yaml;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration.Adapters.Start;

public class YamlFileStrategy :
    IFileStrategy,
    IStreamStrategy,
    IConfigurationSourceStrategy
{
    public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        starter.AddYamlFile(provider, path, optional, reloadOnChange);
    }

    public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
    {
        if (typeof(TConfigurationSource) != typeof(YamlConfigurationSource)) return;
        starter.AddYamlConfigurationSource(source => (configureSource as Action<YamlConfigurationSource>)?.Invoke(source));
    }

    public void AddStream(ConfigurationStarter starter, Stream stream)
    {
        starter.AddYamlStream(stream);
    }
}