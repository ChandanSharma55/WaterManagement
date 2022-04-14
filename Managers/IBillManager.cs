
namespace WaterManagement
{
    public interface IBillManager
    {
        int[] GetTotalBill(string allocateCommand, List<string> guestCommands);
    }
}