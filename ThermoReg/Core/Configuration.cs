using ThermoReg.Data;
using ThermoReg.Data.Model;
using ThermoReg.Utils;

namespace ThermoReg.Core
{
    internal static class Configuration
    {
        public static event EventHandler? ConfigUpdated;

        public static void AddNewDesiredTemperature(DesiredTemperature dt)
        {
            var newStart = new TimeSpan(dt.StartHour, dt.StartMinute, 0);
            var newEnd = new TimeSpan(dt.EndHour, dt.EndMinute, 0);

            var overlapping = DataBase.Data.DesiredTemperatures.Find(t =>
            {
                var existingStart = new TimeSpan(t.StartHour, t.StartMinute, 0);
                var existingEnd = new TimeSpan(t.EndHour, t.EndMinute, 0);

                // Robust overlap check (handles nesting, partial overlaps, and overnight ranges)
                return Time.IsTimeBetween(existingStart, newStart, newEnd) ||
                       Time.IsTimeBetween(existingEnd, newStart, newEnd) ||
                       Time.IsTimeBetween(newStart, existingStart, existingEnd);
            });

            if (overlapping != null)
            {
                // Fixed: Single-line interpolated string to prevent compilation error
                throw new Exception($"This overlaps with temperature range {overlapping.StartHour:D2}:{overlapping.StartMinute:D2} - {overlapping.EndHour:D2}:{overlapping.EndMinute:D2}");
            }

            if (dt.Temperature >= 30)
            {
                // todo: move 30 to constant
                throw new Exception("Temperature too high");
            }

            DataBase.Data.DesiredTemperatures.Add(dt);
            ConfigUpdated?.Invoke(null, new EventArgs());
        }
    }
}