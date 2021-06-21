using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public class TemperatureStatastics
    {
        private double minimumTemperature = double.MaxValue;
        public double MinimumTemperatureReading
        {
            get { return minimumTemperature; }
            set { minimumTemperature = value; }
        }
        private double maximumTemperature = double.MinValue;
        public double MaximumTemperatureReading
        {
            get { return maximumTemperature; }
            set { maximumTemperature = value; }
        }
        public double TemperatureAverage { get; set; }
    }
}
