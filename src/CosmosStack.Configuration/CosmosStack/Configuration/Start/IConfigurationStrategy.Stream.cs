using System.IO;

namespace CosmosStack.Configuration.Start
{
    /// <summary>
    /// Stream Strategy <br />
    /// 流策略
    /// </summary>
    public interface IStreamStrategy : IConfigurationStrategy
    {
        void AddStream(ConfigurationStarter starter, Stream stream);
    }
}