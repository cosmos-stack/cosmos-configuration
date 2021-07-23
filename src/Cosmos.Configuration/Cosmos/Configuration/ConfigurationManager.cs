using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration
{
    public static class ConfigurationManager
    {
        private static IConfigurationRoot _root;

        internal static void SetRoot(IConfigurationRoot root)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        internal static IConfigurationRoot GetRoot() => _root;

        public static IConfigurationSection GetSection(string sectionKey)
        {
            return _root.GetSection(sectionKey);
        }

        public static IEnumerable<IConfigurationSection> GetSections()
        {
            return _root.GetChildren();
        }

        public static IEnumerable<IConfigurationSection> GetSections(string sectionKey)
        {
            return _root.GetSection(sectionKey)?.GetChildren();
        }
    }
}