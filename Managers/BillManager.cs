using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterManagement
{
    public class BillManager
    {
        
        public int[] GetTotalBill(String allocateCommand, List<String> guestCommands)
        {
            var waterFromCandB = new WaterManager().WaterFromCandB(allocateCommand);
            var waterFromT = new WaterManager().WaterFromT(guestCommands);

            var billFromCandB = BillFromCandB(waterFromCandB,allocateCommand);
            var billFromT = BillFromT(waterFromT);

            int[] result = new int[] {waterFromCandB+waterFromT,billFromCandB+billFromT};
            return result;
        }

        private int BillFromT(int waterFromT)
        {
            int rate = 0;
            int extra = 0;
            if(waterFromT > 3000 )
            {
                extra = waterFromT - 3000;
                rate += extra * 8;
                waterFromT -= extra;
            }
            if (waterFromT > 1500 && waterFromT <= 3000)
            {
                extra = waterFromT - 1500;
                rate += extra * 5;
                waterFromT -= extra;
            }
            if (waterFromT > 500 && waterFromT <= 1500)
            {
                extra = waterFromT - 500;
                rate += extra * 3;
                waterFromT -= extra;
            }
            if (waterFromT > 0 && waterFromT <= 500)
            {
                rate += waterFromT * 2;
            }

            return rate;
        }

        private int BillFromCandB(int waterFromCandB,String allocateCommand)
        {
            var ratio = allocateCommand.Split()[2];
            var c = Convert.ToInt32(ratio.Split(':')[0]);
            var b = Convert.ToInt32(ratio.Split(':')[1]);
            var cwater = waterFromCandB * c / (c + b);
            var bwater = waterFromCandB * b / (c + b);
            return (int)(bwater*1.5 + cwater);
        }
    }
}
