using System;
namespace BatteryDataStreaming
{
    public class BatteryDataStreaming
    {
        private IBatteryDataStreamingSource batteryDataStreaming;
        public BatteryDataStreaming(IBatteryDataStreamingSource streamingSource)
        {
            if (streamingSource == null)
                throw new ArgumentNullException("Streaming source can not be null");
            batteryDataStreaming = streamingSource;
        }
        public void LoadBatteryData(string filePath)
        {
            batteryDataStreaming.LoadBatteryParameters(filePath);
        }
        public string GetBatteryData(int index)
        {
            return batteryDataStreaming.GetBatteryParameterBasedOnIndex(index);
        }
    }
}
