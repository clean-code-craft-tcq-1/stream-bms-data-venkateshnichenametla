using System;
using System.Collections.Generic;
using Xunit;

namespace BatteryStreamReceiver.Test
{
    public class BatteryStreamProcessingTest
    {
        private readonly IStreamInputParser streamParser = new StreamingInputParser();
        List<string> batteryStreamData = new List<string>() { "27; 33", "2; 24", "6; 45", "26; 51", "30; 26" };
        public List<BatteryParameters> ExpectedList()
        {
            List<BatteryParameters> expectedBatteryParameters = new List<BatteryParameters>();
            BatteryParameters batteryParameter = new BatteryParameters();
            batteryParameter.temperature = 27;
            batteryParameter.stateOfCharge = 33;            
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.temperature = 2;
            batteryParameter.stateOfCharge = 24;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.temperature = 6;
            batteryParameter.stateOfCharge = 45;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.temperature = 26;
            batteryParameter.stateOfCharge = 51;
            expectedBatteryParameters.Add(batteryParameter);
            batteryParameter = new BatteryParameters();
            batteryParameter.temperature = 30;
            batteryParameter.stateOfCharge = 26;
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
            List<BatteryParameters> expectedBatteryParameters = ExpectedList();
            BatteryParameters batteryParameters = new BatteryParameters();
            batteryParameters = batteryStreamProcessing.CalculateMaximumParametersReading(expectedBatteryParameters);
            BatteryParameters maximumBatteryDetails = new BatteryParameters();
            maximumBatteryDetails.temperature = 30;
            maximumBatteryDetails.stateOfCharge = 51;
            Assert.Equal(maximumBatteryDetails.temperature, batteryParameters.temperature);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsNull_ThenReturnMaximumBatteryParametersAsNull()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            List<BatteryParameters> batteryParameters = null;
            BatteryParameters maximumBatteryDetails = new BatteryParameters();
            maximumBatteryDetails = batteryStreamProcessing.CalculateMaximumParametersReading(batteryParameters);
            Assert.Null(maximumBatteryDetails);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsValid_ThenReturnAverageBatteryParameters()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            List<BatteryParameters> expectedBatteryParameters = ExpectedList();
            BatteryParameters averagebatteryParameters = new BatteryParameters();
            averagebatteryParameters = batteryStreamProcessing.CalculateAverageParametersReadings(expectedBatteryParameters);
            BatteryParameters expectedAverageBatteryDetails = new BatteryParameters();
            expectedAverageBatteryDetails.temperature = 18.2;
            expectedAverageBatteryDetails.stateOfCharge = 35.8;
            Assert.Equal(expectedAverageBatteryDetails.temperature, averagebatteryParameters.temperature);
        }
        [Fact]
        public void GivenBatteryParameterReadings_WhenBatteryParameterListIsNull_ThenReturnAverageBatteryParametersAsNull()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            List<BatteryParameters> batteryParameters = null;
            BatteryParameters averagebatteryParameters = new BatteryParameters();
            averagebatteryParameters = batteryStreamProcessing.CalculateAverageParametersReadings(batteryParameters);
            BatteryParameters expectedAverageBatteryDetails = new BatteryParameters();            
            Assert.Null(averagebatteryParameters);
        }
        [Fact]
        public void GivenStreamingInoutList_WhenListIsValid_ThenReturnStringWithMaximunAndAverageResult()
        {
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            string resultData = string.Empty;
            resultData = batteryStreamProcessing.ProcessBatteryStreamingData(batteryStreamData);
            Assert.NotNull(resultData);
        }
        [Fact]
        public void GivenStreamingInoutList_WhenListIsNull_ThenReturnNull()
        {
            List<string> streamData = null;
            BatteryStreamProcessing batteryStreamProcessing = new BatteryStreamProcessing(streamParser);
            string resultData = string.Empty;
            resultData = batteryStreamProcessing.ProcessBatteryStreamingData(streamData);
            Assert.Null(resultData);
        }
    }
}
