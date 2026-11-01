namespace ThermoReg.Data.Model
{
    internal class LoRaKey
    {
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime? LastReadAt = null;
    }
}
