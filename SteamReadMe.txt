[h1]Quasimorph Powder Weight and Disassembly Fix[/h1]


Fixes a bug where gun powder is 10x the weight of ammo.  For example, 9mm ammo weighs 0.01 each, while powder extracted from that round weighs 0.10.

Additionally, optionally can fix the issue where disassembling an item can create more resources than are required to manufacture the same item.  This is disabled by default and can be changed in the configuration.
Ex:  In the base game, a 9mm round can be made with one powder, but disassembling a round can return up to two powders.

[h2]Disassembly Output Fix[/h2]

The differences in assembly resources needed vs resources created by disassembly may be a design choice by the developers.  Many items follow the 0-1 of X to make and produce 0-2 of X when disassembled.
However, if you feel it is a bit of an exploit, these fixes will be for you.

If the "fix disassembly outputs" is enabled, expect to get about half of the components that the non modded game returns.  As an example, since 9mm ammo can normally create up to two powder (0-2 random), adjusting that recipe to one (0-1 random) will reduce the output. A stack of 9mm x 80 will generally return about 30-50 powder when modded, while the game's default will usually return about 70-100+.

[h2]Mod Life[/h2]

The developers have mentioned that the powder weight issue will be addressed in a coming patch.

[h1]Configuration[/h1]

[h2]MCM[/h2]

This mod supports the MCM, which adds a Mods button to the main menu.  The settings can be found there.
Alternatively, the config file can be directly edited, as indicated in the section below.

[h2]Config File[/h2]

The configuration file will be created on the first game run and can be found at [i]%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\FixGunpowderWeight\config.json[/i].
[table]
[tr]
[td]Name
[/td]
[td]Default
[/td]
[td]Description
[/td]
[/tr]
[tr]
[td]FixPowderWeight
[/td]
[td]true
[/td]
[td]Changes powder to 0.01 from the incorrect 0.10
[/td]
[/tr]
[tr]
[td]FixAmmoDisassemblyToAssemblyCount
[/td]
[td]false
[/td]
[td]If true, will only change any ammo disassembly outputs to not be more than what is required to make the same item.
[/td]
[/tr]
[tr]
[td]FixAllDisassemblyToAssemblyCount
[/td]
[td]false
[/td]
[td]If true, will change all disassembly outputs to not be more than what is required to make the same item.  This includes ammo.
[/td]
[/tr]
[tr]
[td]DebugLog
[/td]
[td]false
[/td]
[td]If true, will log the items' production requirements that were changed.
[/td]
[/tr]
[/table]

[h1]Support My Work[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.  It really helps with motivation to continue to support mods.
This is not expected, but appreciated. Thanks!

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/FixGunpowderWeight

[h1]Credits[/h1]

Special thanks to Crynano for his excellent Mod Configuration Menu.

Icons from:

[url=https://www.flaticon.com/free-icons/law]Law icons created by LAFS - Flaticon[/url]

[url=https://www.flaticon.com/free-icons/question-mark]Question mark icons created by Freepik - Flaticon[/url]

[h1]Change Log[/h1]

[h2]1.2.0[/h2]
[list]
[*]Added option to fix all manufacture resource requirements vs disassemble resource outputs.
[*]FixDisassemblyToAssemblyCount has been removed and replaced with Ammo and All options.
[/list]

[h2]1.1.2[/h2]
[list]
[*]MCM is now optional
[/list]

[h2]1.1.1[/h2]
[list]
[*]Fix for config label.
[/list]

[h2]1.1.0[/h2]
[list]
[*]Supports Crynano's Mod Configuration Menu
[/list]
