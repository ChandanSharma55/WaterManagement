using WaterManagement.Models;

namespace WaterManagement
{
    public interface IWaterFacade
    {
        Result CalculateTotalBill(string[] commands);
    }
}