using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Adapters.Start;

public class JsonFileStrategy :
    IFileStrategy,
    IStreamStrategy,
    IConfigurationSourceStrategy
{
    public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        starter.AddJsonFile(provider, path, optional, reloadOnChange);
    }

    public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
    {
        if (typeof(TConfigurationSource) != typeof(JsonConfigurationSource)) return;
        starter.AddJsonConfigurationSource(source => (configureSource as Action<JsonConfigurationSource>)?.Invoke(source));
    }

    public void AddStream(ConfigurationStarter starter, Stream stream)
    {
        starter.AddJsonStream(stream);
    }
}