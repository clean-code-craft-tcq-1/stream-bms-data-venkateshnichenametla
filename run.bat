pushd "%~dp0"

timeout 1 dotnet run --project Sender\BatteryDataStreaming\BatteryDataStreaming.csproj | dotnet run --project Receiver\BatteryStreamReceiver\BatteryStreamReceiver.csproj

popd
