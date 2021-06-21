pushd "%~dp0"

timeout /t 100 dotnet run --project Sender\BatteryDataStreaming\BatteryDataStreaming.csproj | dotnet run --project Receiver\BatteryStreamReceiver\BatteryStreamReceiver.csproj

popd
