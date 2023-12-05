# TheUsualPlaces

This project has been archived:
Originally developed as a proof of concept late 2022, the project was close to completion as Team Resurgent released Pandora.
Go check out their work @ https://theusualplaces.co.uk

Long Live the Homebrew Console Modding Communities and Retro Enthusiasts!


About:
An Open Source IRC + FTP based client, designed to replace Auto-XBINS.

FTP Client: Implemented using FluentFTP
IRC Client: Implemented using IrcDotNet

What does it do?
An automated IRC Bot will "Phone Home" to EFNET and join the XBINS Server.
It will then gather credentials to connect to the XBINS FTP Server.
If this fails, it will automatically retry, and has detections for IRC Bans and other potential hiccups.
The FTP Server should automatically reconnect if timed out, and if the credentials don't work, the IRC bot should retry for credentials.

Also included is the minature Credits library written by me as a throwback to the old school days of the scene.



Original Idea:
Going one step further from the original Auto-XBINS client, TUP was supposed to have a "Dual FTP" mode.
The Dual FTP Mode could be used to connect to both XBINS and your Original Xbox or Console of choice to transfer things directly to it.
This was never implemented before the project was shelved, but the selected libraries should allow for it.

