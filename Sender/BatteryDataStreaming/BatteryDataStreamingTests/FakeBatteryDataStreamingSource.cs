using BatteryDataStreaming;
namespace BatteryDataStreamingTests
{
    public class FakeBatteryDataStreamingSource : IBatteryDataStreamingSource
    {
        internal bool isLoadBatteryParametersCalled = false;
        internal bool isGetBatteryParameterCalled = false;
        public string GetBatteryParameterBasedOnIndex(int index)
        {
            isGetBatteryParameterCalled = true;
            return "10;25";
        }
        public void LoadBatteryParameters(string filepath)
        {
            isLoadBatteryParametersCalled = true;
        }
    }
}
