using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterManagement
{
    public class WaterManager
    {
        public int WaterFromCandB(String allocateCommand)
        {
            var room = Convert.ToInt32(allocateCommand.Split()[1]);
            var people = 0;
            if (room == 2)
                people = 3;
            else
                people = 5;
            return people * 10 * 30;

        }

        public int WaterFromT(List<String> guestCommands)
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
