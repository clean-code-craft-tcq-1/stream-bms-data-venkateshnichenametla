using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BatteryStreamReceiver
{
    class Program
    {       
        static void Main(string[] args)
        {
            BatteryStatastics batteryStatastics;
            IStreamInputParser streamInputParser = new StreamingInputParser();
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamInputParser);
            string streamingInput;
            List<string> batteryStreamingInputSet = new List<string>();
            while ((streamingInput = Console.ReadLine()) != null && (streamingInput = Console.ReadLine())!="Streaming the battery data(temperature, StateOfCharge) started. Press Ctrl-C to stop streaming")
            {
                Console.WriteLine(streamingInput);
                batteryStreamingInputSet.Add(streamingInput);
                batteryStatastics = batteryStreamProcessing.CalculateMaximumandMinimumParametersReading(streamingInput);
                DisplayResult.DisplayMaximumAndMinimumResult(batteryStatastics);
                GetMovingAverage(batteryStreamingInputSet, batteryStreamProcessing, batteryStatastics);                
            }
        }
        private static void GetMovingAverage(List<string> streamingInput,BatteryStreamProcessing batteryStreamProcessing,BatteryStatastics batteryStatastics)
        {            
            if (streamingInput.Count >= 5)
            {
                batteryStatastics = batteryStreamProcessing.CalculateAverageParametersReadings(streamingInput.GetRange(streamingInput.Count - 5, 5));
                DisplayResult.DisplayAverageResult(batteryStatastics);
            }
        }
    }
}
