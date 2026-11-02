namespace ThermoReg.Data.Model
{
    internal class Configuration
    {
        public float MinWaterTemp { get; set; } = 40.0f;
        public float MaxWaterTemp { get; set; } = 65.0f;
        public float ProportionalBand { get; set; } = 3.0f;
        // time after last read key to consider house as empty
        public TimeSpan MinEmptyTime { get; set; } = TimeSpan.Parse("00:10:00");
        public float EmptyTemp { get; set; } = 15.0f;
        public float MaxAllowedRoomTemp { get; set; } = 30.0f;
    }
}
