using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public interface IProcessStreamingData
    {
        public string ProcessBatteryStreamingData(List<string> streamData);
        public BatteryParameters CalculateMaximumParametersReading(List<BatteryParameters> batteryParameters);
        public BatteryParameters CalculateAverageParametersReadings(List<BatteryParameters> batteryParameters);
    }
}
