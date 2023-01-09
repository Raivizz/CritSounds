#!/bin/bash

tempDir="/tmp/bass24-temp"
cpuArchitecture=$(uname -m)

zipUrls=(
  "https://www.un4seen.com/files/bass24-linux.zip"
)
zipDirectory="."

if [[ $cpuArchitecture == arm* ]]
then
  zipUrls=(
    "http://www.un4seen.com/stuff/bass24-linux-arm.zip"
  )
  zipDirectory="hardfp"
fi

# Create a temp dir
mkdir $tempDir

# Go to temp
cd $tempDir || exit

# Download zip files and extract
for zipUrl in "${zipUrls[@]}"
do
  echo "Downloading $zipUrl file ..."

  wget -qO- -O tmp.zip "$zipUrl" && unzip tmp.zip && rm tmp.zip
done

# Go to zip directory
cd $zipDirectory || exit

# Install .so files
for file in $(find . -maxdepth 1 -name "*.so"); do
  echo "Installing $file file ..."

  sudo cp "$file" /usr/local/lib

  echo "/usr/local/lib/$file"

  sudo chmod a+rx /usr/local/lib/"$file"

  sudo ldconfig
done

# Remove tempDir
rm -r $tempDir
