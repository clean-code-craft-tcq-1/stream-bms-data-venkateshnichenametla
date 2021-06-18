using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryStreamReceiver
{
    public class StreamingInputParser : IStreamInputParser
    {
        public List<BatteryParameters> GetBatteryParametersFromStreamingData(List<string> streamInput)
        {
            string temperatureValue = string.Empty;
            string socValue = string.Empty;
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            if (ListValidator.IsBatteryStreamingInputListValid(streamInput))
            {
                string readingInput = string.Empty;
                for (int i = 0; i < streamInput.Count(); i++)
                {
                    BatteryParameters batteryParameterValues = new BatteryParameters();
                    readingInput = streamInput[i];
                    temperatureValue = readingInput.Split(";")[0];
                    socValue = readingInput.Split(";")[1];
                    batteryParameterValues.Temperature = ParseInputValue(temperatureValue);
                    batteryParameterValues.StateOfCharge = ParseInputValue(socValue);
                    batteryParameters.Add(batteryParameterValues);
                }
            }
            else
            {
                batteryParameters = null;
            }
            return batteryParameters;
        }
        private double ParseInputValue(string input)
        {
            double resultValue = 0;
            if (double.TryParse(input, out resultValue))
            {
                return resultValue;
            }
            else
            {
                return 0;
            }
        }
    }
}