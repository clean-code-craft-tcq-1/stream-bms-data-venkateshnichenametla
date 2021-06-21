pushd "%~dp0"

dotnet run --project Sender\BatteryDataStreaming\BatteryDataStreaming.exe | dotnet run --project Receiver\BatteryStreamReceiverBatteryStreamReceiver.exe

popd
