using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration
{
    public interface IConfigurationGetter
    {
        IConfigurationRoot GetRoot();
        IConfigurationSection GetSection(string sectionKey);
        IEnumerable<IConfigurationSection> GetSections();
        IEnumerable<IConfigurationSection> GetSections(string sectionKey);
    }
}