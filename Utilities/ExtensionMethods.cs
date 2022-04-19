using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement.Models;

namespace WaterManagement.Utilities
{
    public static class ExtensionMethods
    {
        public static Ratio GetRatio(this String allocateCommand)
        {
            try
            {
                var ratioString = allocateCommand.Split()[2];
                var ratio = new Ratio()
                {
                    Corporation = Convert.ToInt32(ratioString.Split(':')[0]),
                    Borewell = Convert.ToInt32(ratioString.Split(':')[1])
                };
                return ratio;
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(GetRatio)} -- Message -- {ex.Message}");
                throw;
            }
        }
    }
}
