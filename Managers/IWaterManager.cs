
using WaterManagement.Models;

namespace WaterManagement
{
    public interface IWaterManager
    {
        int WaterFromCandB(string allocateCommand);
        int WaterFromT(List<string> guestCommands);
        Water GetWaterUsed(string allocateCommand, List<string> guestCommands);
    }
}