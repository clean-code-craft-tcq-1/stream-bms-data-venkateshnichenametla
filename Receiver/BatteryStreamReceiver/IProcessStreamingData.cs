using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public interface IProcessStreamingData
    {
        public BatteryStatastics CalculateMaximumandMinimumParametersReading(string batteryParametersInput);
        public BatteryStatastics CalculateAverageParametersReadings(List<string> batteryStreamingInput);
    }
}
