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
        public static void Main(string[] args)
        {
            try
            {
                var host = ServiceRegistration.CreateHostBuilder(args).Build();//Registration of Services for Dependecy Injection
                host.Services.GetRequiredService<WaterManagementMain>().RunApplication();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error from {nameof(Main)} -- Message -- {ex.Message}");
                return;
            }
        }

        public void RunApplication()
        {
            try
            {
                var list_of_commands = File.ReadAllLines(Path.GetFullPath("input.txt"));//input file, can be changed as per testcase
                var finalResult = _waterFacade.CalculateTotalBill(list_of_commands);
                Console.WriteLine($"{finalResult.TotalWater} {finalResult.TotalCost}");
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(RunApplication)} -- Message -- {ex.Message}");
                return;
            }
        }
    }
}