using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterManagement
{
    public class WaterFacade
    {

        //public bool Validate(String command)
        //{
        //    List<String> valid = new List<String>() { "ALLOT_WATER", "ADD_GUESTS", "BILL" };
        //    if (!valid.Contains(command.Split()[0]))
        //        return false;
        //    return true;
        //}
        public int[] CalculateBill(String[] commands)
        {
            //foreach (var command in commands)
            //{
            //    if(!Validate(command))
            //        return null; // Exception
            //}

            var allocateCommand = commands[0];
            var guestCommands = new List<String>();
            for(int i=1;i<commands.Length-1;i++)
            {
                guestCommands.Add(commands[i]);
            }

            return new BillManager().GetTotalBill(allocateCommand, guestCommands);
        }
    }
}
