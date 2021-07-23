using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Start
{
    public interface IFileStrategy : IConfigurationStrategy
    {
        void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange);
    }
}