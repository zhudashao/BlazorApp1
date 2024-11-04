using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.ShardLib.Interfaces;

public interface IModule
{
    void Initialize(IServiceCollection services, IConfiguration configuration);
}
