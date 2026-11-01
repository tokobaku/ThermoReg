using ThermoReg.Data.Model;

namespace ThermoReg.Data
{
    internal class DbData
    {
        public List<User> Users { get; set; } = [];
        public List<TemperatureSensor> Sensors { get; set; } = [];
        public List<LoRaKey> LoRaKeys { get; set; } = [];
    }
}
