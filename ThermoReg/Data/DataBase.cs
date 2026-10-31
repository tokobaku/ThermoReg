using System.Text.Json;

namespace ThermoReg.Data
{
    internal class DataBase
    {
        private static DbData _dbData = new();
        public static DbData Data
        {
            get => _dbData;
            set => _dbData = value;
        }

        public static void Init()
        {
            if (!File.Exists("db.json"))
            {
                Save();
            }

            var jsonData = File.ReadAllText("db.json");
            var jsonDoc = JsonDocument.Parse(jsonData);

            _dbData = JsonSerializer.Deserialize<DbData>(jsonDoc) ?? throw new Exception("Could not serialize db data");
        }

        public static void Save()
        {
            File.WriteAllText("db.json", JsonSerializer.Serialize(Data));
        }
    }
}
