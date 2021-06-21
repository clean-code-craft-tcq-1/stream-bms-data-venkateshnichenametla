using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public class BatteryStatastics
    {
        public BatteryStatastics()
        {
            TemperatureStatastics = new TemperatureStatastics();
            SOCStatastics = new SOCStatastics();
        }
        public TemperatureStatastics TemperatureStatastics { get; set; }
        public SOCStatastics SOCStatastics { get; set; }
    }
}
