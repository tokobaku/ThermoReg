namespace ThermoReg.Data.Model
{
    internal class DesiredTemperature
    {
        public int StartHour { get; set; } = 0;
        public int StartMinute { get; set; } = 0;
        public int EndHour { get; set; } = 0;
        public int EndMinute { get; set; } = 0;
        public float Temperature = 22;

        public string GetTag()
        {
            return StartHour.ToString() + ":" + StartMinute.ToString() + "-" + EndHour.ToString() + ":" + EndMinute.ToString();
        }
    }
}
