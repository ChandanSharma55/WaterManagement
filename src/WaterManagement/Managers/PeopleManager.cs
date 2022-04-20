using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement.Models;
using WaterManagement.Utilities;

namespace WaterManagement
{
    public class PeopleManager : IPeopleManager
    {
        public People GetPeopleAndGuests(string allocateCommand, List<string> guestCommands)
        {
            try
            {
                var people = new People()
                {
                    PeopleCount = GetPeople(allocateCommand),//Get total number of people as per room type
                    GuestCount = GetGuests(guestCommands)//Get total number of guests added later
                };
                return people;
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(GetPeopleAndGuests)} -- Message -- {ex.Message}");
                throw;
            }
        }

        private int GetPeople(string allocateCommand)
        {
            try
            {
                var room = Convert.ToInt32(allocateCommand.Split()[1]);
                int people;
                if (room == Constants.ROOM_TYPE_A)
                    people = Constants.PEOPLE_COUNT_A;
                else
                    people = Constants.PEOPLE_COUNT_B;
                return people;
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(GetPeople)} -- Message -- {ex.Message}");
                throw;
            }
        }
        private int GetGuests(List<string> guestCommands)
        {
            try
            {
                int guests = 0;
                foreach (var guestCommand in guestCommands)
                {
                    guests += Convert.ToInt32(guestCommand.Split()[1]);
                }
                return guests;
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(GetGuests)} -- Message -- {ex.Message}");
                throw;
            }
        }
    }
}
