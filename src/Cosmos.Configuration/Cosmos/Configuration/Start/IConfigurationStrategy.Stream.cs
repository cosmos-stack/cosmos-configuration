using System.IO;

namespace Cosmos.Configuration.Start
{
    public interface IStreamStrategy : IConfigurationStrategy
    {
        void AddStream(ConfigurationStarter starter, Stream stream);
    }
}