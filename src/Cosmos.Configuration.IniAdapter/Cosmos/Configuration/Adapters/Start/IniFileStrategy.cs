using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Adapters.Start;
#if !NET451 && !NET452
public class IniFileStrategy :
    IFileStrategy,
    IStreamStrategy,
    IConfigurationSourceStrategy
#else
    public class IniFileStrategy :
        IFileStrategy
#endif
{
    public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        starter.AddIniFile(provider, path, optional, reloadOnChange);
    }
#if !NET451 && !NET452
    public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
    {
        if (typeof(TConfigurationSource) != typeof(IniConfigurationSource)) return;
        starter.AddIniConfigurationSource(source => (configureSource as Action<IniConfigurationSource>)?.Invoke(source));
    }

    public void AddStream(ConfigurationStarter starter, Stream stream)
    {
        starter.AddIniStream(stream);
    }
#endif
}