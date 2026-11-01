namespace ThermoReg.Utils
{
    internal static class Time
    {
        public static bool IsTimeBetween(TimeSpan target, TimeSpan start, TimeSpan end)
        {
            if (start <= end)
            {
                // normal range 08:00 to 17:00
                return target >= start && target <= end;
            }
            else
            {
                // overnight range 22:00 to 04:00
                return target >= start || target <= end;
            }
        }
    }
}
