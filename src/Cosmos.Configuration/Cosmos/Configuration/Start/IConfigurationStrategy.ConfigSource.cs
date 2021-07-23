using System;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Configuration.Start
{
    public interface IConfigurationSourceStrategy : IConfigurationStrategy
    {
        void AddConfigurationSource<TConfigurationSource>(ConfigurationStarter starter, Action<TConfigurationSource> configureSource) where TConfigurationSource : FileConfigurationSource;
    }
}