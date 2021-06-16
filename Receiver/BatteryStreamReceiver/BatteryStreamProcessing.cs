using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryStreamReceiver
{
    public class BatteryStreamProcessing : IProcessStreamingData
    {
        IStreamInputParser _streamInputParser;
        public BatteryStreamProcessing(IStreamInputParser streamInputParser)
        {
            _streamInputParser = streamInputParser;
        }

        public BatteryParameters CalculateAverageParametersReadings(List<BatteryParameters> batteryParameters)
        {
            BatteryParameters averageParametersReading = new BatteryParameters();
            if (ListValidator.IsBatteryParameterListValid(batteryParameters))
            {
                double sumTemperatureValue = 0, sumStateOfChargeValue = 0, averageTemperature = 0, averageStateOfCharge = 0;
                
                for (int i = 0; i < batteryParameters.Count(); i++)
                {
                    sumTemperatureValue += batteryParameters[i].temperature;
                    sumStateOfChargeValue += batteryParameters[i].stateOfCharge;
                }
                averageTemperature = sumTemperatureValue / batteryParameters.Count();
                averageStateOfCharge = sumStateOfChargeValue / batteryParameters.Count();
                averageParametersReading.temperature = averageTemperature;
                averageParametersReading.stateOfCharge = averageStateOfCharge;
                
            }
            else
            {
                averageParametersReading = null;
            }
            return averageParametersReading;
        }

        public BatteryParameters CalculateMaximumParametersReading(List<BatteryParameters> batteryParameters)
        {
            BatteryParameters maximumParametersReading = new BatteryParameters();
            if (ListValidator.IsBatteryParameterListValid(batteryParameters))
            {
                double maxTemperatureValue = 0;
                double maxStateOfChargeValue = 0;                
                for (int i = 0; i < batteryParameters.Count(); i++)
                {
                    if (batteryParameters[i].temperature > maxTemperatureValue)
                    {
                        maxTemperatureValue = batteryParameters[i].temperature;
                    }
                    if (batteryParameters[i].stateOfCharge > maxStateOfChargeValue)
                    {
                        maxStateOfChargeValue = batteryParameters[i].stateOfCharge;
                    }
                }
                maximumParametersReading.temperature = maxTemperatureValue;
                maximumParametersReading.stateOfCharge = maxStateOfChargeValue;
            }
            else
            {
                maximumParametersReading = null;
            }
            return maximumParametersReading;
        }

        public string ProcessBatteryStreamingData(List<string> streamData)
        {
            if (ListValidator.IsBatteryStreamingInputListValid(streamData))
            {
                List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
                BatteryParameters maximumBatteryReadings = new BatteryParameters();
                BatteryParameters averageBatteryReadings = new BatteryParameters();
                batteryParameters = _streamInputParser.GetBatteryParametersFromStreamingData(streamData);
                maximumBatteryReadings = CalculateMaximumParametersReading(batteryParameters);
                averageBatteryReadings = CalculateAverageParametersReadings(batteryParameters);
                return DisplayData(maximumBatteryReadings, averageBatteryReadings);
            }
            else
            {
                return null;
            }
        }

        public string DisplayData(BatteryParameters maximumBatteryReadings,BatteryParameters averageBatteryReadings)
        {
            string displayResult = string.Empty;
            displayResult="Maximum Temperature - "+maximumBatteryReadings.temperature+" & Maximum State Of Charge - " + maximumBatteryReadings.stateOfCharge;
            displayResult += "\nAverage Temperature - " + averageBatteryReadings.temperature + " & Average State Of Charge - " + averageBatteryReadings.stateOfCharge;

            return displayResult;
        }
       
    }
}
