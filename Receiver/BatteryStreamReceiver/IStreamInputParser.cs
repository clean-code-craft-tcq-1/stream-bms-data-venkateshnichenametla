using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryStreamReceiver
{
    public interface IStreamInputParser
    {
        List<BatteryParameters> GetBatteryParametersFromStreamingData(List<string> streamInput);
    }
}
