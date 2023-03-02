namespace P02.CarSalesman.Utility
{
    // Point of this class is to check whether optional properties have been set trough instance of Car and/or Engine classes for printing relevant object in ToString() method.
    public static class ValueAssigner
    {
        public static string ReturnStringOrNotFound(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "n/a";
            }
            else
            {
                return value;
            }
        }

        public static string ReturnDoubleOrNotFound(double value)
        {
            if (value == 0.0)
            {
                return "n/a";
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
