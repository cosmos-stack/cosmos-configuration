using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CosmosStack.Configuration
{
    /// <summary>
    /// Configuration Getter Interface <br />
    /// 配置获取接口
    /// </summary>
    public interface IConfigurationGetter
    {
        IConfigurationRoot GetRoot();
        IConfigurationSection GetSection(string sectionKey);
        IEnumerable<IConfigurationSection> GetSections();
        IEnumerable<IConfigurationSection> GetSections(string sectionKey);
    }
}