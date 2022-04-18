using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterManagement.Models
{
    public class Bill
    {
        public int CorporationWater { get; set; }
        public int BorewellWater { get; set; }
        public int TankerWater { get; set; }
    }
}
