namespace BatteryDataStreaming
{
    public interface IBatteryDataStreamingSource
    {
        void LoadBatteryParameters(string filepath);

        string GetBatteryParameterBasedOnIndex(int index);
    }
}
