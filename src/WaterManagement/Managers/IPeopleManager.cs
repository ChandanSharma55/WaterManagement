using WaterManagement.Models;

namespace WaterManagement
{
    public interface IPeopleManager
    {
        People GetPeopleAndGuests(string allocateCommand, List<string> guestCommands);
    }
}