# Sender

There are basically 2 projects

1.BatteryDataStreaming
2.BatteryDataStreamingTests

## BatteryDataStreaming
BatteryDataStreaming is an console application which sends the battery parameters data by reading the 'BatteryStreamingData.txt' file.

The temperature and StateOfCharge will be sent separated by ';'.

Ex :

0;22

2;24

Once it finds '--End--' then the streaming the data will be stopped
To stop streaming data at any point of time 'Press Ctrl-C'

## BatteryDataStreamingTests
BatteryDataStreamingTests.cs class contains the tests for BatteryDataStreaming project

FakeBatteryDataStreamingSource.cs is used to fake the battery data.
