using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration
{
    public class ConfigurationGetter : IConfigurationGetter
    {
        public IConfigurationRoot GetRoot() => ConfigurationManager.GetRoot();
        public IConfigurationSection GetSection(string sectionKey) => ConfigurationManager.GetSection(sectionKey);
        public IEnumerable<IConfigurationSection> GetSections() => ConfigurationManager.GetSections();
        public IEnumerable<IConfigurationSection> GetSections(string sectionKey) => ConfigurationManager.GetSections(sectionKey);
    }
}