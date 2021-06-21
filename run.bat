pushd "%~dp0"

dotnet run --project Sender\BatteryDataStreaming\BatteryDataStreaming.csproj | dotnet run --project Receiver\BatteryStreamReceiver\BatteryStreamReceiver.csproj

cmd /c exit -1073741510

popd
