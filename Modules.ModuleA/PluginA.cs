using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.ShardLib.Interfaces;

namespace Modules.ModuleA;

public class PluginA : IModule
{
    public void Initialize(IServiceCollection services, IConfiguration configuration)
    {

        var pluginSettings = configuration.GetSection("PluginAConfig").Get<PluginAConfig>();
        services.AddSingleton(pluginSettings!);
        services.AddSingleton<IPluginService, PluginAService>();
    }
}

public class PluginAConfig
{
    public string SettingA { get; set; }
}


public class PluginAService : IPluginService
{
    private readonly PluginAConfig _config;

    public PluginAService(PluginAConfig config)
    {
        _config = config;
    }

    public string Execute()
    {
        return $"Executing PluginA with SettingA: {_config.SettingA}";
    }
}

public interface IPluginService
{
    string Execute();
}