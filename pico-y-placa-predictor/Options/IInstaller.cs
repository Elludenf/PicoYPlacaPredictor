using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PicoYPlacaPredictor.Options
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
