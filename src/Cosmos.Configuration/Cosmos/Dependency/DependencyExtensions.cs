using Cosmos.Configuration;

namespace Cosmos.Dependency;

/// <summary>
/// Dependency Extensions
/// </summary>
public static class DependencyExtensions
{
    /// <summary>
    /// Add Configuration Support
    /// </summary>
    /// <param name="register"></param>
    /// <typeparam name="TRegister"></typeparam>
    /// <returns></returns>
    public static TRegister AddConfiguration<TRegister>(this TRegister register)
        where TRegister : DependencyProxyRegister
    {
        register.AddSingleton<IConfigurationGetter, ConfigurationGetter>();
        return register;
    }
}