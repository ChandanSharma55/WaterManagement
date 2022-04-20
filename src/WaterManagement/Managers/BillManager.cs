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
        public Result GetTotalBill(string allocateCommand, List<string> guestCommands)
        {
            try
            {
                var peopleTypes = _peopleManager.GetPeopleAndGuests(allocateCommand, guestCommands);//Get total number of people and total number of guests
                var ratio = allocateCommand.GetRatio();//Get the ratio for corporation : borewell
                var waterTypes = _waterManager.GetWaterUsed(peopleTypes, ratio);//Get the total water used by each source

                var bill = new Bill()
                {
                    CorporationWater = BillFromCorporation(waterTypes.CorporationWater), //Get the bill generated from Corporation Water
                    BorewellWater = BillFromBorewell(waterTypes.BorewellWater),//Get the bill generated from Borewell Water
                    TankerWater = BillFromTanker(waterTypes.TankerWater)//Get the bill generated from Tanker Water
                };
                var result = new Result()
                {
                    TotalCost = bill.TankerWater + bill.BorewellWater + bill.CorporationWater,//Total cost from all 3 sources
                    TotalWater = waterTypes.TankerWater + waterTypes.BorewellWater + waterTypes.CorporationWater//Total water from all 3 sources
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

        private int BillFromCorporation(int waterFromCorporation)
        {
            return waterFromCorporation * Constants.CORPORATION_RATE;
        }
        private int BillFromBorewell(int waterFromBorewell)
        {
            return (int)Math.Round(waterFromBorewell * Constants.BOREWELL_RATE);
        }
    }
}