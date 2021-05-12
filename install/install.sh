#!/usr/bin/bash
# Note: This should be placed IN THE LINUX RELEASE DIRECTORY
# This script will not work if it is not

if [[ $EUID -ne 0 ]]; then
	echo "This script must be run as root"
	exit 1
fi

mkdir -p /opt/speedcube/
cp ./Speedcube.x86_64 /opt/speedcube/
chmod +x /opt/speedcube/Speedcube.x86_64
cp ./speedcube /usr/bin/
chmod +x /usr/bin/speedcube
cp -r ./Speedcube_Data /opt/speedcube/
echo "Installation complete! Run the command \"speedcube\" to play the game!"
