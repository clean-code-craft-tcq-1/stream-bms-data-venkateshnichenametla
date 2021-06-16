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
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            if (ListValidator.IsBatteryStreamingInputListValid(streamInput))
            {
                string readingInput = string.Empty;
                for (int i = 0; i < streamInput.Count(); i++)
                {
                    BatteryParameters batteryParameterValues = new BatteryParameters();
                    readingInput = streamInput[i];
                    batteryParameterValues.temperature = Convert.ToDouble(readingInput.Split(";")[0]);
                    batteryParameterValues.stateOfCharge = Convert.ToDouble(readingInput.Split(";")[1]);
                    batteryParameters.Add(batteryParameterValues);
                }
            }
            else
            {
                batteryParameters = null;
            }
            return batteryParameters;
        }
    }
}
