using ThermoReg.Data;
using ThermoReg.Data.Model;

namespace ThermoReg.Core
{
    internal static class SignalsReceiver
    {
        public static event EventHandler? StateUpdated;

        public static void AddSensor(TemperatureSensor sensor)
        {
            var id = sensor.Identifier.Trim();
            var name = sensor.Identifier.Trim();

            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Can not have sensor with empty id");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Can not have sensor with empty name");
            }

            if (DataBase.Data.Sensors.Find(s => id == s.Identifier) is not null)
            {
                throw new Exception($"Sensor with id `{id}` already exists");
            }

            if (DataBase.Data.Sensors.Find(s => name == s.Name) is not null)
            {
                throw new Exception($"Sensor with name `{name}` already exists");
            }

            DataBase.Data.Sensors.Add(sensor);

            StateUpdated?.Invoke(null, new EventArgs());
        }

        public static void ReadTemperature(string id, float temp, DateTime time)
        {
            var sensor = DataBase.Data.Sensors.Find(s => s.Identifier == id) ?? throw new Exception($"Could not find sensor with id {id}");

            // todo: validate time > LastReadAt
            sensor.LastMeasuredTemperature = temp;
            sensor.LastReadAt = time;

            StateUpdated?.Invoke(null, new EventArgs());
        }

        public static void AddKey(LoRaKey key)
        {
            var id = key.Identifier.Trim();
            var name = key.Identifier.Trim();

            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Can not have key with empty id");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Can not have key with empty name");
            }

            if (DataBase.Data.LoRaKeys.Find(k => k.Identifier == id) is not null)
            {
                throw new Exception($"Key with identifier `{id}` already exists");
            }

            if (DataBase.Data.LoRaKeys.Find(k => k.Name == name) is not null)
            {
                throw new Exception($"Key with name `{name}` already exists");
            }

            DataBase.Data.LoRaKeys.Add(key);

            StateUpdated?.Invoke(null, new EventArgs());
        }

        public static void RecieveKeySignal(string identifier, DateTime datetime)
        {
            var key = DataBase.Data.LoRaKeys.Find(k => k.Identifier == identifier) ?? throw new Exception($"Key with identifier {identifier} not found");
            key.LastReadAt = datetime;

            // todo datetime > LastReadAt

            StateUpdated?.Invoke(null, new EventArgs());
        }
    }
}
