using System;
using Xunit;
using BatteryDataStreaming;

namespace BatteryDataStreamingTests
{
    public class BatteryDataStreamingTests
    {
        [Fact]
        public void GivenStreamingSourceNull_WhenStreamIsNull_ReturnsArguementNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BatteryDataStreaming.BatteryDataStreaming(null));
        }
        
        [Fact]
        public void GivenFakeStreamingSource_WhenLoadBatteryDataIsCalled_ReturnedTrue()
        {
            IBatteryDataStreamingSource batteryDataStreamingSource = new FakeBatteryDataStreamingSource();
            BatteryDataStreaming.BatteryDataStreaming batteryDataStreaming = new BatteryDataStreaming.BatteryDataStreaming(batteryDataStreamingSource);
            batteryDataStreaming.LoadBatteryData(string.Empty);
            FakeBatteryDataStreamingSource fakeBatteryDataStreamingSource = batteryDataStreamingSource as FakeBatteryDataStreamingSource;
            Assert.True(fakeBatteryDataStreamingSource.isLoadBatteryParametersCalled);
        }

        [Fact]
        public void GivenFakeStreamingSource_WhenGetBatteryDataIsCalled_ReturnedValue()
        {
            IBatteryDataStreamingSource batteryDataStreamingSource = new FakeBatteryDataStreamingSource();
            BatteryDataStreaming.BatteryDataStreaming batteryDataStreaming = new BatteryDataStreaming.BatteryDataStreaming(batteryDataStreamingSource);
            batteryDataStreaming.GetBatteryData(0);
            FakeBatteryDataStreamingSource fakeBatteryDataStreamingSource = batteryDataStreamingSource as FakeBatteryDataStreamingSource;
            Assert.Equal("10;25",fakeBatteryDataStreamingSource.GetBatteryParameterBasedOnIndex(0));
        }
    }
}
