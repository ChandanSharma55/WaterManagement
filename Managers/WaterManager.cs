using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement.Models;
using WaterManagement.Utilities;

namespace WaterManagement
{
    public class WaterManager : IWaterManager
    {
        public Water GetWaterUsed(People people, Ratio ratio)
        {
            try
            {
                var totalWaterForBorewellAndCorporation = people.PeopleCount * Constants.WATER_NEEDED_PER_DAY_PER_PERSON * Constants.MONTH_DAYS;
                var water = new Water()
                {
                    CorporationWater = WaterFromCorporation(totalWaterForBorewellAndCorporation, ratio),
                    BorewellWater = WaterFromBorewell(totalWaterForBorewellAndCorporation, ratio),
                    TankerWater = WaterFromTanker(people.GuestCount)
                };
                return water;
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(GetWaterUsed)} -- Message -- {ex.Message}");
                throw;
            }
        }

        private int WaterFromCorporation(int totalWaterForBorewellAndCorporation, Ratio ratio)
        {
            try
            {
                return (totalWaterForBorewellAndCorporation * ratio.Corporation) / (ratio.Corporation + ratio.Borewell);
            }
            catch (ArithmeticException ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(WaterFromCorporation)}");
                throw ex;
            }
        }
        private int WaterFromBorewell(int totalWaterForBorewellAndCorporation, Ratio ratio)
        {
            try
            {
                return (totalWaterForBorewellAndCorporation * ratio.Borewell) / (ratio.Corporation + ratio.Borewell);
            }
            catch (ArithmeticException ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(WaterFromBorewell)}");
                throw ex;
            }
        }

        private int WaterFromTanker(int guests)
        {
            try
            {
                return guests * Constants.WATER_NEEDED_PER_DAY_PER_PERSON * Constants.MONTH_DAYS;
            }
            catch (ArithmeticException ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(WaterFromTanker)}");
                throw ex;
            }
        }
    }
}
