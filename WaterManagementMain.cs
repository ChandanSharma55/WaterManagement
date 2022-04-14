using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WaterManagement.DependenciesInjection;
using WaterManagement.Utilities;

namespace WaterManagement
{
    public class WaterManagementMain
    {
        private readonly IWaterFacade _waterFacade;
        public WaterManagementMain(ILogger<WaterManagementMain> logger, IWaterFacade waterFacade)
        {
            _waterFacade = waterFacade;
            MyLogger.Log = logger;
        }
        public static void Main(String[] args)
        {
            var host = ServiceRegistration.CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<WaterManagementMain>().RunApplication();
        }

        public void RunApplication()
        {
            try
            {
                var list_of_commands = File.ReadAllLines(Path.GetFullPath("input.txt"));
                var result = _waterFacade.CalculateBill(list_of_commands);
                MyLogger.Log.LogInformation($"{result[0]} {result[1]}");
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError(ex.Message);
                return;
            }
        }
    }
}