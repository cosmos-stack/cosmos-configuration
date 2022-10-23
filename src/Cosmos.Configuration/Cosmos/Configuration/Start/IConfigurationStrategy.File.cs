using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Start;

/// <summary>
/// File Strategy <br />
/// 文件策略
/// </summary>
public interface IFileStrategy : IConfigurationStrategy
{
    void AddFile(ConfigurationStarter starter, IFileProvider provider, string path, bool optional, bool reloadOnChange);
}