using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public static class DisplayResult
    {
        public static void DisplayMaximumAndMinimumResult(BatteryStatastics batteryStatastics)
        {
            Console.WriteLine(
            "Maximum Temperature - " + batteryStatastics.TemperatureStatastics.MaximumTemperatureReading + " & Minimum Temperature - " + batteryStatastics.TemperatureStatastics.MinimumTemperatureReading
            + "\nMaximum State Of Charge - " + batteryStatastics.SOCStatastics.MaximumSOCReading + " & Minimum State Of Charge - " + batteryStatastics.SOCStatastics.MinimumSOCReading
            );
        }
        public static void DisplayAverageResult(BatteryStatastics batteryStatastics)
        {
            Console.WriteLine(
            "Average Temperature - " + batteryStatastics.TemperatureStatastics.TemperatureAverage + " & Average State Of Charge - " + batteryStatastics.SOCStatastics.SOCAverage
            );
        }
    }
}
