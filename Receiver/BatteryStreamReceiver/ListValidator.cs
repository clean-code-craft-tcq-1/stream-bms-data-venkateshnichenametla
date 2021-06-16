using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryStreamReceiver
{
    public static class ListValidator
    {
        public static bool IsBatteryParameterListValid(List<BatteryParameters> batteryParameters)
        {
            if (batteryParameters == null)
            {
                return false;
            }
            else if(batteryParameters.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsBatteryStreamingInputListValid(List<string> streamingData)
        {
            if (streamingData == null)
            {
                return false;
            }
            else if(streamingData.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
