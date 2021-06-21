pushd "%~dp0"

BatteryDataStreaming.exe | BatteryStreamReceiver.exe

popd
