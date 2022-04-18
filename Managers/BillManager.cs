using Microsoft.Extensions.Logging;
using WaterManagement.Models;
using WaterManagement.Utilities;
using System;
namespace WaterManagement
{
    public class BillManager : IBillManager
    {
        private readonly IWaterManager _waterManager;
        private readonly IPeopleManager _peopleManager;
        public BillManager(IWaterManager waterManager, IPeopleManager peopleManager)
        {
            _waterManager = waterManager;
            _peopleManager = peopleManager;
        }
        public Result GetTotalBill(String allocateCommand, List<String> guestCommands)
        {
            try
            {
                var peopleTypes = _peopleManager.GetPeopleAndGuests(allocateCommand, guestCommands);
                var ratio = allocateCommand.GetRatio();
                var waterTypes = _waterManager.GetWaterUsed(peopleTypes, ratio);

                var bill = new Bill()
                {
                    CorporationWater = BillFromCorporation(waterTypes.CorporationWater),
                    BorewellWater = BillFromBorewell(waterTypes.BorewellWater),
                    TankerWater = BillFromTanker(waterTypes.TankerWater)
                };
                var result = new Result()
                {
                    TotalCost = bill.TankerWater + bill.BorewellWater + bill.CorporationWater,
                    TotalWater = waterTypes.TankerWater + waterTypes.BorewellWater + waterTypes.CorporationWater
                };
                return result;

            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(GetTotalBill)} -- Message -- {ex.Message}");
                throw;
            }
        }

        private int BillFromTanker(int waterFromT)
        {
            try
            {
                int rate = 0;
                int extra = 0;
                if (waterFromT > Constants.HIGHEST_VALUE)
                {
                    extra = waterFromT - Constants.HIGHEST_VALUE;
                    rate += extra * Constants.TANKER_RATE_ABOVE_HIGHEST;
                    waterFromT -= extra;
                }
                if (waterFromT > Constants.MID_VALUE && waterFromT <= Constants.HIGHEST_VALUE)
                {
                    extra = waterFromT - Constants.MID_VALUE;
                    rate += extra * Constants.TANKER_RATE_HIGHER_MID;
                    waterFromT -= extra;
                }
                if (waterFromT > Constants.LOWEST_VALUE && waterFromT <= Constants.MID_VALUE)
                {
                    extra = waterFromT - Constants.LOWEST_VALUE;
                    rate += extra * Constants.TANKER_RATE_LOWER_MID;
                    waterFromT -= extra;
                }
                if (waterFromT > 0 && waterFromT <= Constants.LOWEST_VALUE)
                {
                    rate += waterFromT * Constants.TANKER_RATE_LOWEST;
                }

                return rate;
            }
            catch (ArithmeticException ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(BillFromTanker)}");
                throw ex;
            }
        }

        private int BillFromCorporation(int waterFromCorporation)
        {
            try
            {
                return waterFromCorporation * Constants.CORPORATION_RATE;
            }
            catch (ArithmeticException ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(BillFromCorporation)}");
                throw ex;
            }
        }
        private int BillFromBorewell(int waterFromBorewell)
        {
            try
            {
                return (int)Math.Round(waterFromBorewell * Constants.BOREWELL_RATE);
            }
            catch (ArithmeticException ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(BillFromBorewell)}");
                throw ex;
            }
        }
    }
}