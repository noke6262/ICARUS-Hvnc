@echo off
pushd "%~dp0"
powershell Compress-7Zip "Update\bin\Release\net472" -ArchiveFileName "birdbrainmofo.zip" -Format Zip
:exit
popd
@echo on
