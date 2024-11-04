using System.Reflection;
using Modules.ShardLib.Interfaces;

namespace MainApp.Services
{
    public class PluginLoader
    {
        private readonly string _pluginFolderPath;
        private readonly List<string> _loadedPlugins = new List<string>();
        private readonly IConfigurationRoot _pluginConfiguration;

        public PluginLoader(string pluginFolderPath, IConfiguration configuration)
        {
            _pluginFolderPath = pluginFolderPath;

            // Load plugin configurations into a separate configuration root
            var configBuilder = new ConfigurationBuilder().AddConfiguration(configuration);
            LoadPluginJsonFiles(configBuilder);
            _pluginConfiguration = configBuilder.Build();
        }

        public void LoadPlugins(IServiceCollection services)
        {
            Directory.CreateDirectory(_pluginFolderPath);

            var pluginAssemblies = Directory.GetFiles(_pluginFolderPath, "*.dll")
                                            .Select(Assembly.LoadFrom);

            foreach (var assembly in pluginAssemblies)
            {
                try
                {
                    if (!ShouldLoadPlugin(assembly))
                    {
                        Console.WriteLine($"Skipping plugin: {assembly.FullName}");
                        continue;
                    }

                    // Initialize each plugin's modules with the global configuration
                    InitializePluginModules(assembly, services);

                    services.AddControllers().AddApplicationPart(assembly);
                    _loadedPlugins.Add(assembly.FullName);
                    Console.WriteLine($"Successfully loaded plugin: {assembly.FullName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading plugin {assembly.FullName}: {ex.Message}");
                }
            }
        }

        private void LoadPluginJsonFiles(IConfigurationBuilder configBuilder)
        {
            foreach (var pluginFile in Directory.GetFiles(_pluginFolderPath, "*.json"))
            {
                // Add each plugin's configuration JSON to the configuration builder
                configBuilder.AddJsonFile(pluginFile, optional: true, reloadOnChange: true);
                Console.WriteLine($"Added plugin configuration file: {pluginFile}");
            }
        }

        private bool ShouldLoadPlugin(Assembly assembly) => true;

        private void InitializePluginModules(Assembly assembly, IServiceCollection services)
        {
            var moduleTypes = assembly.GetTypes()
                .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var moduleType in moduleTypes)
            {
                var moduleInstance = (IModule)Activator.CreateInstance(moduleType);
                moduleInstance.Initialize(services, _pluginConfiguration);
                Console.WriteLine($"Initialized module: {moduleType.FullName} from {assembly.FullName}");
            }
        }

        public IEnumerable<string> GetLoadedPlugins() => _loadedPlugins;
    }
}
