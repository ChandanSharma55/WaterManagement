using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WaterManagement.DependenciesInjection
{
    public static class ServiceRegistration
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<WaterManagementMain>();
                    services.AddScoped<IWaterFacade,WaterFacade>();
                    services.AddScoped<IWaterManager,WaterManager>();
                    services.AddScoped<IBillManager,BillManager>();
                    services.AddScoped<IPeopleManager, PeopleManager>();
                });
        }
    }
}
