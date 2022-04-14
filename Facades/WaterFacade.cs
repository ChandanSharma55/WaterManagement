using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement.Utilities;
using Microsoft.Extensions.Logging;

namespace WaterManagement
{
    public class WaterFacade : IWaterFacade
    {
        private readonly IBillManager _billManager;
        public WaterFacade(IBillManager billManager)
        {
            _billManager = billManager;
        }

        public int[] CalculateBill(String[] commands)
        {
            try
            {
                if (!InputValidation.Validate(commands))
                    throw new Exception("Invalid Argument");

                var allocateCommand = commands[0];
                var guestCommands = new List<String>();
                for (int i = 1; i < commands.Length - 1; i++)
                {
                    guestCommands.Add(commands[i]);
                }

                return _billManager.GetTotalBill(allocateCommand, guestCommands);
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(CalculateBill)}");
                throw ex;
            }
        }
    }
}
