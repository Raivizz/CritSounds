# CritSounds 1.4
Welcome to the 1.4 tModLoader Crit Sounds repository!

This repository contains a version of Crit Sounds tempered for the 1.4 tModLoader-stable branch.

Sorry, Dark Assassin, but there's no FLAC support here.

# Removed features

- No more "other dlls for all these crazy audio file formats it wants to support for some reason".
	- Sorry, jopojelly! While it was fun to implement, I do agree that it was ultimately worthless. Much love for the indirect criticism, though!
	
- Enumeration removed, mod now depends entirely on DamageClass (custom damage class support to be added once major mods get ported to 1.4)

# Current features

- Full support for built-in crit sounds

- Support for custom crit sounds

- Linux support (currently requires user intervention)

- Major code rewrite once again, hopefully makes code more readable and less "wow noob-tier"

# Potential future plans

- Implementation of BassFX for features like pitch shifting
	- Mostly for parity with tMod's custom audio implementation having a pitch attribute
	
- Automated library installation for Linux
	- By default, ManagedBass looks for libbass.so in /usr/lib. Perhaps there's alternative ways to implement user libraries? Needs research.
	- Before that, proper informing of users is required. Arch users can just install libbass from the AUR (confirmed as working from my side), alternative distribs might need specific instructions.
