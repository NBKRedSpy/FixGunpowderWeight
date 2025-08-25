# Quasimorph Fix Gunpowder Weight

Fixes an issue with the game where powder is 10x the weight of ammo.  For example, 9mm ammo weighs 0.01 each, while powder extracted from that round weighs 0.10.

Disabled by Default - This optionally adjusts the disassembly outputs of all ammo so that a single round cannot disassembly into more items then it takes to create the item. This can be changed in the mod configuration.

## Disassembly Output Fix 
If the "fix disassembly outputs" is enabled, expect to get about half of the components that the non modded game returns.  For instance, the game's 9mm ammo can actually produce up to two powder per round, but takes only one powder to create.  Since the disassembly is random, the unmodded game can produce more powder than there are rounds that are being disassembled.  Ex: 80 9mm rounds can easily turn into 100 or more powder.

![thumbnail icon](media/thumbnail.png)

## Mod Life
It is unknown how quickly the developers will address the "bug" in the game.  However it may be fairly soon; therefore it is unknown how long this mod will be needed.  This mod will be removed when the bugs are addressed.

# Configuration

The configuration file will be created on the first game run and can be found at `%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\FixGunpowderWeight\config.json`.

|Name|Default|Description|
|--|--|--|
|FixPowderWeight|true|Changes powder to 0.01 from the incorrect 0.10|
|FixDisassemblytoAssemblyCount|false|If true, will change any disassembly outputs to not be more than what is required to make the same item.|

# Support My Work
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.  It really helps with motivation to continue to support mods.
This is not expected, but appreciated. Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/FixGunpowderWeight

# Credits

Icons from:

[Law icons created by LAFS - Flaticon](https://www.flaticon.com/free-icons/law)

[Question mark icons created by Freepik - Flaticon](https://www.flaticon.com/free-icons/question-mark)
