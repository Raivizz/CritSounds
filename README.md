# CritSounds 1.4
Welcome to the 1.4 tModLoader Crit Sounds repository!

This repository contains a version of Crit Sounds tempered for the 1.4 tModLoader-stable branch.

# Removed features

- No more "other dlls for all these crazy audio file formats".
	
- Enumeration removed, mod now depends entirely on DamageClass

# Current features

- Full support for built-in crit sounds

- Support for custom crit sounds

- Linux support (currently requires user intervention)

- Major code rewrite once again, hopefully makes code more readable and less "wow noob-tier"

# Potential future plans

- Automated library installation for Linux
	- By default, ManagedBass looks for libbass.so in /usr/lib. Perhaps there's alternative ways to implement user libraries? Needs research.
	- Before that, proper informing of users is required. Arch users can just install libbass from the AUR (confirmed as working from my side), alternative distribs might need specific instructions.
