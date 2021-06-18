using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public class SOCStatastics
    {
        private double minimumSOC = double.MaxValue;
        public double MinimumSOCReading
        {
            get { return minimumSOC; }
            set { minimumSOC = value; }
        }
        private double maximumSOC = double.MinValue;
        public double MaximumSOCReading
        {
            get { return maximumSOC; }
            set { maximumSOC = value; }
        }
        public double SOCAverage { get; set; }
    }
}
