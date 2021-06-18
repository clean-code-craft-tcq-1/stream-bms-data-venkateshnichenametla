using System;
using System.Collections.Generic;
using Xunit;

namespace BatteryStreamReceiver.Test
{
    public class BatteryStreamProcessingTest
    {
        BatteryStatastics batteryStatastics;
        private readonly IStreamInputParser streamParser = new StreamingInputParser();        
        List<string> batteryStreamData = new List<string>() { "27; 33", "2; 24", "6; 45", "26; 51", "30; 26" };
        public List<BatteryParameters> ExpectedList()
        {
            List<BatteryParameters> expectedBatteryParameters = new List<BatteryParameters>();
            BatteryParameters batteryParameter = new BatteryParameters();
            batteryParameter.Temperature = 27;
            batteryParameter.StateOfCharge = 33;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.Temperature = 2;
            batteryParameter.StateOfCharge = 24;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.Temperature = 6;
            batteryParameter.StateOfCharge = 45;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.Temperature = 26;
            batteryParameter.StateOfCharge = 51;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.Temperature = 30;
            batteryParameter.StateOfCharge = 26;
            expectedBatteryParameters.Add(batteryParameter);
            return expectedBatteryParameters;
        }
        [Fact]
        public void GivenParameterList_WhenParameterListIsValid_ThenReturnBatteryParameters()
        {
            List<BatteryParameters> expectedBatteryParameters = ExpectedList();
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            batteryParameters = streamParser.GetBatteryParametersFromStreamingData(batteryStreamData);
            Assert.True(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(expectedBatteryParameters, batteryParameters));
        }
        [Fact]
        public void GivenParameterList_WhenParameterListIsNull_ThenReturnBatteryParametersAsNull()
        {
            List<string> streamingData = null;
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            batteryParameters = streamParser.GetBatteryParametersFromStreamingData(streamingData);
            Assert.Null(batteryParameters);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsValid_ThenReturnMaximumBatteryParameters()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            string inputStream = "10;23";
            batteryStatastics = batteryStreamProcessing.CalculateMaximumandMinimumParametersReading(inputStream);            
            Assert.Equal(10,batteryStatastics.TemperatureStatastics.MinimumTemperatureReading);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsNull_ThenReturnMaximumBatteryParametersAsNull()
        {   
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            string inputStream = "";
            batteryStatastics = batteryStreamProcessing.CalculateMaximumandMinimumParametersReading(inputStream);
            Assert.Equal(double.MaxValue,batteryStatastics.TemperatureStatastics.MinimumTemperatureReading);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsValid_ThenReturnAverageBatteryParameters()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            batteryStatastics = batteryStreamProcessing.CalculateAverageParametersReadings(batteryStreamData);
            Assert.Equal(18.2, batteryStatastics.TemperatureStatastics.TemperatureAverage);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsNull_ThenReturnAverageBatteryParametersAsNull()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            List<string> batteryParameters = null;
            batteryStatastics = batteryStreamProcessing.CalculateAverageParametersReadings(batteryParameters);        
            Assert.Equal(0,batteryStatastics.TemperatureStatastics.TemperatureAverage);
        }
        
    }
}
