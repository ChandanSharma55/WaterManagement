using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterManagement.Utilities
{
    public static class Constants
    {
        public static readonly string ALLOT_WATER = "ALLOT_WATER";
        public static readonly string ADD_GUESTS = "ADD_GUESTS";
        public static readonly string BILL = "BILL";
        public static readonly List<String> ValidCommand = new(){ALLOT_WATER,ADD_GUESTS,BILL};
    }
}
