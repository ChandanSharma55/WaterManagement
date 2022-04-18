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
        public static readonly List<string> ValidCommands = new(){ALLOT_WATER,ADD_GUESTS,BILL};

        public static readonly int ROOM_TYPE_A = 2;
        public static readonly int ROOM_TYPE_B = 3;
        public static readonly int PEOPLE_COUNT_A = 3;
        public static readonly int PEOPLE_COUNT_B = 5;
        public static readonly int WATER_NEEDED_PER_DAY_PER_PERSON = 10;
        public static readonly int MONTH_DAYS = 30;
        public static readonly int CORPORATION_RATE = 1;
        public static readonly double BOREWELL_RATE = 1.5;
        public static readonly int HIGHEST_VALUE = 3000;
        public static readonly int MID_VALUE = 1500;
        public static readonly int LOWEST_VALUE = 500;
        public static readonly int TANKER_RATE_ABOVE_HIGHEST = 8;
        public static readonly int TANKER_RATE_HIGHER_MID = 5;
        public static readonly int TANKER_RATE_LOWER_MID = 3;
        public static readonly int TANKER_RATE_LOWEST = 2;
    }
}
