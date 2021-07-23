using Cosmos.Configuration;

namespace Cosmos.Dependency
{
    public static class DependencyExtensions
    {
        public static TRegister AddConfiguration<TRegister>(this TRegister register)
            where TRegister : DependencyProxyRegister
        {
            register.AddSingleton<IConfigurationGetter, ConfigurationGetter>();
            return register;
        }
    }
}