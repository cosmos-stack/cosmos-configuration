using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration.Start;

/// <summary>
/// Configuration Source Strategy <br />
/// 配置源策略
/// </summary>
public interface IConfigurationSourceStrategy : IConfigurationStrategy
{
    void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource;
}