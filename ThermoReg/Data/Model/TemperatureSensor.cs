namespace ThermoReg.Data.Model
{
    internal class TemperatureSensor
    {
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public float? LastMeasuredTemperature = null;
        public DateTime? LastReadAt = null;
    }
}
