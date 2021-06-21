using System;
using System.IO;
using System.Threading;

namespace BatteryDataStreaming
{
    class Program
    {
        private static bool isDataStreamingCancelled = false;
        private static BatteryDataStreaming batteryDataStreaming;

        static void Main(string[] args)
        {
            batteryDataStreaming = new BatteryDataStreaming(new TextBatteryDataStreamingSource());
            batteryDataStreaming.LoadBatteryData(Path.GetFullPath(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"), "BatteryData/BatteryStreamingData.txt")));

            Console.WriteLine("Streaming the battery data(temperature, StateOfCharge) started. Press Ctrl-C to stop streaming");
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Stopping the battery data streaming...");
                isDataStreamingCancelled = true;
                eventArgs.Cancel = true;
            };

            StartBatteryDataStreaming();
        }

        private static void StartBatteryDataStreaming()
        {
            int streamingCounter = 1;
            while (!isDataStreamingCancelled)
            {
                string data = batteryDataStreaming.GetBatteryData(streamingCounter);
                if (data.Equals("--End--"))
                {
                   break;
                }
                Console.WriteLine(data);
                Thread.Sleep(2000);
                streamingCounter++;
            }
        }
    }
}
