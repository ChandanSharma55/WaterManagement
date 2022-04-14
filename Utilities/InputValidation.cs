namespace WaterManagement.Utilities
{
    public static class InputValidation
    {
        public static bool Validate(String[] commands)
        {
            foreach (var command in commands)
            {
                if (!Constants.ValidCommand.Contains(command.Split()[0]))
                    return false;
            }
            return true;
        }
    }
}
