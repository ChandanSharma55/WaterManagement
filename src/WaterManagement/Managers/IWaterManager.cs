
using WaterManagement.Models;

namespace WaterManagement
{
    public interface IWaterManager
    {
        Water GetWaterUsed(People people, Ratio ratio);
    }
}