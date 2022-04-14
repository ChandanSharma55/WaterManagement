using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement.Models;

namespace WaterManagement
{
    public class WaterManager : IWaterManager
    {
        public Water GetWaterUsed(string allocateCommand, List<string> guestCommands)
        {
            var ratio = allocateCommand.Split()[2];
            var c = Convert.ToInt32(ratio.Split(':')[0]);
            var b = Convert.ToInt32(ratio.Split(':')[1]);
            var totalWater = 
            var water = new Water()
            {
                CorporationWater = 
            };
            return water;
        }

        private int WaterFromC(String allocateCommand)
        {

        }
        private int WaterFromB(String allocateCommand)
        {
            var room = Convert.ToInt32(allocateCommand.Split()[1]);
            var people = 0;
            if (room == 2)
                people = 3;
            else
                people = 5;
            return people * 10 * 30;

        }

        private int WaterFromT(List<String> guestCommands)
        {
            int guests = 0;
            foreach (var guestCommand in guestCommands)
            {
                guests += Convert.ToInt32(guestCommand.Split()[1]);
            }

            return guests * 10 * 30;
        }
    }
}
