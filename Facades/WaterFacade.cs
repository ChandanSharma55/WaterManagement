using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement.Utilities;
using Microsoft.Extensions.Logging;
using WaterManagement.Models;

namespace WaterManagement
{
    public class WaterFacade : IWaterFacade
    {
        private readonly IBillManager _billManager;
        public WaterFacade(IBillManager billManager)
        {
            _billManager = billManager;
        }

        public Result CalculateTotalBill(string[] commands)
        {
            try
            {
                if (!InputValidation.Validate(commands))//Validating the inputs
                    throw new Exception("Invalid Arguments");

                var allocateCommand = commands[0];//first command will always be allocation command
                var guestCommands = new List<String>();
                for (int i = 1; i < commands.Length - 1; i++)
                {
                    guestCommands.Add(commands[i]);//all commands after allocation will be about guests except the last one
                }

                return _billManager.GetTotalBill(allocateCommand, guestCommands);
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from -- {nameof(CalculateTotalBill)} -- Message -- {ex.Message}");
                throw;
            }
        }
    }
}
