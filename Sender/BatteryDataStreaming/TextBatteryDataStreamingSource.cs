using System.IO;
namespace BatteryDataStreaming
{
    public class TextBatteryDataStreamingSource : IBatteryDataStreamingSource
    {
        private string[] batteryData;
        public string GetBatteryParameterBasedOnIndex(int index)
        {
            if(batteryData != null && batteryData.Length > 0)
                return batteryData[index];
            return string.Empty;
        }

        public void LoadBatteryParameters(string filepath)
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException();
            batteryData  = File.ReadAllLines(filepath);
        }
    }
}
