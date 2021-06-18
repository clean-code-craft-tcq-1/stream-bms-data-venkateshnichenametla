using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryStreamReceiver
{
    public class BatteryStreamProcessing : IProcessStreamingData
    {
        private BatteryStatastics batteryStatastics;
        private IStreamInputParser _streamInputParser;
        public BatteryStreamProcessing(IStreamInputParser streamInputParser)
        {
            _streamInputParser = streamInputParser;
            batteryStatastics = new BatteryStatastics();

        }
        public BatteryStatastics CalculateAverageParametersReadings(List<string> batteryStreamingData)
        {
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            batteryParameters = _streamInputParser.GetBatteryParametersFromStreamingData(batteryStreamingData);            
            if (ListValidator.IsBatteryParameterListValid(batteryParameters))
            {
                double sumTemperatureValue = 0, sumStateOfChargeValue = 0, averageTemperature = 0, averageStateOfCharge = 0;                
                for (int i = 0; i < batteryParameters.Count(); i++)
                {
                    sumTemperatureValue += batteryParameters[i].Temperature;
                    sumStateOfChargeValue += batteryParameters[i].StateOfCharge;
                }
                averageTemperature = sumTemperatureValue / batteryParameters.Count();
                averageStateOfCharge = sumStateOfChargeValue / batteryParameters.Count();
                batteryStatastics.TemperatureStatastics.TemperatureAverage = averageTemperature;
                batteryStatastics.SOCStatastics.SOCAverage = averageStateOfCharge;                
            }
            else
            {
                batteryStatastics.TemperatureStatastics.TemperatureAverage = 0;
                batteryStatastics.SOCStatastics.SOCAverage = 0;
            }
            return batteryStatastics;
        }

        public BatteryStatastics CalculateMaximumandMinimumParametersReading(string inputParameters)
        {
            if (!string.IsNullOrEmpty(inputParameters))
            {
                List<BatteryParameters> batteryParameters = _streamInputParser.GetBatteryParametersFromStreamingData(new List<string>() { inputParameters });
                batteryStatastics.TemperatureStatastics.MinimumTemperatureReading = Math.Min(batteryStatastics.TemperatureStatastics.MinimumTemperatureReading, batteryParameters[0].Temperature);
                batteryStatastics.SOCStatastics.MinimumSOCReading = Math.Min(batteryStatastics.SOCStatastics.MinimumSOCReading, batteryParameters[0].StateOfCharge);
                batteryStatastics.TemperatureStatastics.MaximumTemperatureReading = Math.Max(batteryStatastics.TemperatureStatastics.MaximumTemperatureReading, batteryParameters[0].Temperature);
                batteryStatastics.SOCStatastics.MaximumSOCReading = Math.Max(batteryStatastics.SOCStatastics.MaximumSOCReading, batteryParameters[0].StateOfCharge);
                return batteryStatastics;
            }
            else
            {
                return batteryStatastics;
            }
        }       

       
    }
}
