using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Xml;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Adapters.Start;

public class XmlFileStrategy :
    IFileStrategy,
    IStreamStrategy,
    IConfigurationSourceStrategy
{
    public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    {
        starter.AddXmlFile(provider, path, optional, reloadOnChange);
    }

    public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
    {
        if (typeof(TConfigurationSource) != typeof(XmlConfigurationSource)) return;
        starter.AddXmlConfigurationSource(source => (configureSource as Action<XmlConfigurationSource>)?.Invoke(source));
    }

    public void AddStream(ConfigurationStarter starter, Stream stream)
    {
        starter.AddXmlStream(stream);
    }
}