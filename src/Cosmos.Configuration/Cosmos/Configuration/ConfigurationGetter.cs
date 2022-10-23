using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration;

/// <summary>
/// Configuration Getter <br />
/// 默认配置获取器
/// </summary>
public class ConfigurationGetter : IConfigurationGetter
{
    public IConfigurationRoot GetRoot() => ConfigurationManager.GetRoot();
    public IConfigurationSection GetSection(string sectionKey) => ConfigurationManager.GetSection(sectionKey);
    public IEnumerable<IConfigurationSection> GetSections() => ConfigurationManager.GetSections();
    public IEnumerable<IConfigurationSection> GetSections(string sectionKey) => ConfigurationManager.GetSections(sectionKey);
}