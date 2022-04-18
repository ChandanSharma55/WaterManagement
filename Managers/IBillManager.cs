
using WaterManagement.Models;

namespace WaterManagement
{
    public interface IBillManager
    {
        Result GetTotalBill(string allocateCommand, List<string> guestCommands);
    }
}