using System;
using System.Collections.Generic;

namespace BatteryStreamReceiver
{
    class Program
    {       
        static void Main(string[] args)
        {
            IStreamInputParser streamInputParser = new StreamingInputParser();
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamInputParser);
            string streamingInput;
            int i = 1;
            List<string> batteryStreamingInputSet = new List<string>();
            while ((streamingInput = Console.ReadLine()) != null && (streamingInput = Console.ReadLine())!="Streaming the battery data(temperature, StateOfCharge) started. Press Ctrl-C to stop streaming")
            {
                Console.WriteLine(streamingInput);
                batteryStreamingInputSet.Add(streamingInput);
                if (i == 5)
                {
                    string resultSet = batteryStreamProcessing.ProcessBatteryStreamingData(batteryStreamingInputSet);
                    batteryStreamingInputSet.Clear();
                    Console.WriteLine(resultSet);
                    i = 1;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
