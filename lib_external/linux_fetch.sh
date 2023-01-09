#!/bin/bash

tempDir="/tmp/libbass-temp"
echo "Creating temporary directory"
mkdir $tempDir
echo "Moving to temporary directory"
cd $tempDir || exit
echo "Downloading libbass.so"
wget -qO- -O libbass.so https://github.com/Raivizz/CritSounds/raw/1.4_port/lib_external/libbass.so
echo "Copying libbass.so to /usr/lib"
sudo cp libbass.so /usr/lib
echo "Adding required permissions to libbass.so"
sudo chmod a+rx /usr/local/lib/libbass.so
echo "Running ldconfig"
sudo ldconfig
echo "All done. Removing temporary directory."
rm -r $tempDir
