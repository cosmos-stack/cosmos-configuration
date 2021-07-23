#if !NET451 && !NET452
using System;
using System.IO;
using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;
#else
using Cosmos.Configuration.Start;
using Microsoft.Extensions.FileProviders;

#endif

namespace Cosmos.Configuration.Adapters.Start
{
#if !NET451 && !NET452
    public class JsonFileStrategy :
        IFileStrategy,
        IStreamStrategy,
        IConfigurationSourceStrategy
#else
    public class JsonFileStrategy :
        IFileStrategy
#endif
    {
        public void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            starter.AddJsonFile(provider, path, optional, reloadOnChange);
        }
#if !NET451 && !NET452
        public void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource
        {
            if (typeof(TConfigurationSource) != typeof(JsonConfigurationSource)) return;
            starter.AddJsonConfigurationSource(source => (configureSource as Action<JsonConfigurationSource>)?.Invoke(source));
        }

        public void AddStream(ConfigurationStarter starter, Stream stream)
        {
            starter.AddJsonStream(stream);
        }
#endif
    }
}