using Alexinea.Extensions.Configuration.Toml;
using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Adapters.Start;
#if !NET451 && !NET452
public class TomlFileStrategy :
    IFileStrategy,
    IStreamStrategy,
    IConfigurationSourceStrategy
#else
    public class TomlFileStrategy :
        IFileStrategy
#endif
{
    public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        starter.AddTomlFile(provider, path, optional, reloadOnChange);
    }
#if !NET451 && !NET452
    public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
    {
        if (typeof(TConfigurationSource) != typeof(TomlConfigurationSource)) return;
        starter.AddTomlConfigurationSource(source => (configureSource as Action<TomlConfigurationSource>)?.Invoke(source));
    }

    public void AddStream(ConfigurationStarter starter, Stream stream)
    {
        starter.AddTomlStream(stream);
    }
#endif
}