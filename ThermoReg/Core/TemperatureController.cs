using ThermoReg.Data;
using ThermoReg.Utils;

namespace ThermoReg.Core
{
    internal static class TemperatureController
    {
        public static float CalculateDesiredTemperature()
        {
            var now = DateTime.Now;
            var smallestSpan = now - DateTime.UnixEpoch;

            DataBase.Data.LoRaKeys.ForEach(key =>
            {
                if (key.LastReadAt != null)
                {
                    var span = now - key.LastReadAt;

                    if (span < smallestSpan)
                    {
                        smallestSpan = span ?? smallestSpan;
                    }
                }
            });

            if (smallestSpan > DataBase.Data.Configuration.MinEmptyTime)
            {
                return DataBase.Data.Configuration.EmptyTemp;
            }

            var activeDesiredTemperature = DataBase.Data.DesiredTemperatures.Find(dt => Time.IsTimeBetween(
                new TimeSpan(now.Hour, now.Minute, 0),
                new TimeSpan(dt.StartHour, dt.StartMinute, 0),
                new TimeSpan(dt.EndHour, dt.EndMinute, 0))
            );

            if (activeDesiredTemperature != null)
            {
                return activeDesiredTemperature.Temperature;
            }

            return DataBase.Data.Configuration.EmptyTemp;
        }

        public static float CaluclateTemperatureSentToBoiler(float roomTemperature, float desiredTemperature)
        {
            float minTemp = DataBase.Data.Configuration.MinWaterTemp;
            float maxTemp = DataBase.Data.Configuration.MaxWaterTemp;
            float proportionalBand = DataBase.Data.Configuration.ProportionalBand;

            float diff = desiredTemperature - roomTemperature;

            if (diff <= 0.0f)
            {
                return minTemp;
            }

            float scalingFactor = diff / proportionalBand;
            if (scalingFactor > 1.0f)
            {
                scalingFactor = 1.0f;
            }

            return minTemp + scalingFactor * (maxTemp - minTemp);
        }
    }
}
