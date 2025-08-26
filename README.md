# Quasimorph Powder Weight and Disassembly Fix
![thumbnail icon](media/thumbnail.png)

Fixes a bug where gun powder is 10x the weight of ammo.  For example, 9mm ammo weighs 0.01 each, while powder extracted from that round weighs 0.10.

Additionally, optionally can fix the issue where disassembling an item can create more resources than are required to manufacture the same item.  This is disabled by default and can be changed in the configuration.
Ex:  In the base game, a 9mm round can be made with one powder, but disassembling a round can return up to two powders.  

## Disassembly Output Fix
The differences in assembly resources needed vs resources created by disassembly may be a design choice by the developers.  Many items follow the 1 of X to make and produce 0-2 of X when disassembled.
However, if you feel it is a bit of an exploit, these fixes will be for you.

If the "fix disassembly outputs" is enabled, expect to get about half of the components that the non modded game returns.  As an example, since 9mm ammo can normally create up to two powder (0-2 random), adjusting that recipe to one (0-1 random) will reduce the output. A stack of 9mm x 80 will generally return about 30-50 powder when modded, while the game's default will usually return about 70-100+.




## Mod Life
The developers have mentioned that the powder weight issue will be addressed in a coming patch.  

# Configuration

## MCM
This mod supports the MCM, which adds a Mods button to the main menu.  The settings can be found there.
Alternatively, the config file can be directly edited, as indicated in the section below.

## Config File

The configuration file will be created on the first game run and can be found at `%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\FixGunpowderWeight\config.json`.

|Name|Default|Description|
|--|--|--|
|FixPowderWeight|true|Changes powder to 0.01 from the incorrect 0.10|
|FixAmmoDisassemblyToAssemblyCount|false|If true, will only change any ammo disassembly outputs to not be more than what is required to make the same item.|
|FixAllDisassemblyToAssemblyCount|false|If true, will change all disassembly outputs to not be more than what is required to make the same item.  This includes ammo.|
|DebugLog|false|If true, will log the items' production requirements that were changed.|

# Support My Work
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.  It really helps with motivation to continue to support mods.
This is not expected, but appreciated. Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/FixGunpowderWeight

# Credits
Special thanks to Crynano for his excellent Mod Configuration Menu.

Icons from:

[Law icons created by LAFS - Flaticon](https://www.flaticon.com/free-icons/law)

[Question mark icons created by Freepik - Flaticon](https://www.flaticon.com/free-icons/question-mark)

# Change Log 
## 1.2.0
* Added option to fix all manufacture resource requirements vs disassemble resource outputs.
* FixDisassemblyToAssemblyCount has been removed and replaced with Ammo and All options.

## 1.1.2
* MCM is now optional

## 1.1.1

* Fix for config label.

## 1.1.0

* Supports Crynano's Mod Configuration Menu