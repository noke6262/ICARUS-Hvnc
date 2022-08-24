@echo off
pushd "%~dp0"
powershell Compress-7Zip "Update\Binaries\Release" -ArchiveFileName "birdbrainmofo.zip" -Format Zip
:exit
popd
@echo on
