
namespace WaterManagement
{
    public class WaterManagementMain
    {
        public static void Main()
        {
            var list_of_commands = File.ReadAllLines(@"C:\Users\csharma\OneDrive - Hyland Software\Desktop\WaterManagement\input.txt");
            var result = new WaterFacade().CalculateBill(list_of_commands);
            Console.WriteLine(result[0]+" "+result[1]);
            //var allotment = file[0];
            //var strings = allotment.Split();
            //var room = strings[1];
            //var corp = strings[2].Split(':')[0];
            //var bore = strings[2].Split(':')[1];

        }
    }
}