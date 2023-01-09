#!/bin/bash

tempDir="/tmp/libbass-temp"
mkdir $tempDir
cd $tempDir || exit
echo "Downloading libbass.so"
wget -qO- -O libbass.so https://github.com/Raivizz/CritSounds/raw/1.4_port/lib_external/libbass.so
sudo cp libbass.so /usr/local/lib
sudo chmod a+rx /usr/local/lib/libbass.so
sudo ldconfig
rm -r $tempDir
