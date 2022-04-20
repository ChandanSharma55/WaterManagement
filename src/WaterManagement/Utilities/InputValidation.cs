using Microsoft.Extensions.Logging;

namespace WaterManagement.Utilities
{
    public static class InputValidation
    {
        public static bool Validate(string[] commands)
        {
            try
            {
                foreach (var command in commands)
                {
                    if (!Constants.ValidCommands.Contains(command.Split()[0]))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MyLogger.Log.LogError($"Error from {nameof(Validate)} -- Message -- {ex.Message}");
                throw;
            }
        }
    }
}
