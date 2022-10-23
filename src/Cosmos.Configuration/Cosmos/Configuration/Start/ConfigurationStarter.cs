using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Cosmos.Configuration.Start;

/// <summary>
/// Configuration Starter <br />
/// 配置扩展入口
/// </summary>
public class ConfigurationStarter
{
    private IConfigurationBuilder _builder;
    private bool _hasBuilt;

    private readonly Dictionary<Type, IConfigurationStrategy> _strategyCache;
    private readonly object _strategyLockObj = new object();

    private ConfigurationStarter(ConfigurationBuilder builder, bool setBasePath, string basePath)
    {
        _builder = builder ?? new ConfigurationBuilder();

        if (setBasePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                basePath = Directory.GetCurrentDirectory();
            _builder = _builder.SetBasePath(basePath);
        }

        _strategyCache = new Dictionary<Type, IConfigurationStrategy>();
    }

    #region Add

    public ConfigurationStarter AddConfig(Func<IConfigurationBuilder, IConfigurationBuilder> configUpdater)
    {
        if (configUpdater is null)
            throw new ArgumentNullException(nameof(configUpdater));
        if (_hasBuilt)
            throw new InvalidOperationException("Configuration has been initialized.");
        _builder = configUpdater.Invoke(_builder);
        return this;
    }

    public ConfigurationStarter AddConfig<TFileStrategy>(string path) where TFileStrategy : class, IFileStrategy, new()
    {
        var instance = new TFileStrategy();
        instance.AddFile(this, null, path, false, false);
        return this;
    }

    public ConfigurationStarter AddConfig<TFileStrategy>(string path, bool optional) where TFileStrategy : class, IFileStrategy, new()
    {
        var instance = GetStrategy<TFileStrategy>();
        instance.AddFile(this, null, path, optional, false);
        return this;
    }

    public ConfigurationStarter AddConfig<TFileStrategy>(string path, bool optional, bool reloadOnChange) where TFileStrategy : class, IFileStrategy, new()
    {
        var instance = GetStrategy<TFileStrategy>();
        instance.AddFile(this, null, path, optional, reloadOnChange);
        return this;
    }

    public ConfigurationStarter AddConfig<TFileStrategy>(IFileProvider provider, string path, bool optional, bool reloadOnChange) where TFileStrategy : class, IFileStrategy, new()
    {
        var instance = GetStrategy<TFileStrategy>();
        instance.AddFile(this, provider, path, optional, reloadOnChange);
        return this;
    }

    public ConfigurationStarter AddConfigurationSource<TConfigurationSourceStrategy, TConfigurationSource>(Action<TConfigurationSource> configureSource)
        where TConfigurationSourceStrategy : class, IConfigurationSourceStrategy, new()
        where TConfigurationSource : FileConfigurationSource
    {
        var instance = GetStrategy<TConfigurationSourceStrategy>();
        instance.AddConfigurationSource(this, configureSource);
        return this;
    }

    public ConfigurationStarter AddConfigStream<TStreamStrategy>(Stream stream) where TStreamStrategy : class, IStreamStrategy, new()
    {
        var instance = GetStrategy<TStreamStrategy>();
        instance.AddStream(this, stream);
        return this;
    }

    #endregion

    #region Build

    public void Build()
    {
        ConfigurationManager.SetRoot(_builder.Build());
        _hasBuilt = true;
    }

    public IConfigurationRoot BuildAndReturn()
    {
        Build();
        return ConfigurationManager.GetRoot();
    }

    public bool HasBuilt() => _hasBuilt;

    #endregion

    #region Factory

    public static ConfigurationStarter Create()
    {
        return new ConfigurationStarter(new ConfigurationBuilder(), false, string.Empty);
    }

    public static ConfigurationStarter Create(string basePath)
    {
        return new ConfigurationStarter(new ConfigurationBuilder(), true, basePath);
    }

    public static ConfigurationStarter Create(ConfigurationBuilder builder)
    {
        return new ConfigurationStarter(builder, false, string.Empty);
    }

    public static ConfigurationStarter Create(ConfigurationBuilder builder, bool setBasePath)
    {
        return new ConfigurationStarter(builder, setBasePath, string.Empty);
    }

    public static ConfigurationStarter Create(ConfigurationBuilder builder, string basePath)
    {
        return new ConfigurationStarter(builder, true, basePath);
    }

    public static ConfigurationStarter Create(ConfigurationBuilder builder, bool setBasePath, string basePath)
    {
        return new ConfigurationStarter(builder, setBasePath, basePath);
    }

    #endregion

    #region Internal helpers

    private TStrategy GetStrategy<TStrategy>() where TStrategy : class, IConfigurationStrategy, new()
    {
        var type = typeof(TStrategy);
        lock (_strategyLockObj)
        {
            if (_strategyCache.ContainsKey(type))
                return _strategyCache[type] as TStrategy;
            var instance = new TStrategy();
            _strategyCache.Add(type, instance);
            return instance;
        }
    }

    #endregion
}