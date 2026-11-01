using ThermoReg.Data;
using ThermoReg.Utils;

namespace ThermoReg.Core
{
    internal class TemperatureController
    {
        public float CalculateDesiredTemperature()
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

            // todo: make this configurable
            if (smallestSpan > TimeSpan.Parse("00:10:00"))
            {
                // todo: default min temp to be configurable
                return 15f;
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

            // todo: use configued value
            return 15f;
        }

        public float CaluclateTemperatureSentToBoiler(float roomTemperature, float desiredTemperature)
        {
            const float minTemp = 40.0f;
            const float maxTemp = 65.0f;
            const float proportionalBand = 2.5f;

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
