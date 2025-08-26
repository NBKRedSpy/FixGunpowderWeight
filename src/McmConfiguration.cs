using ModConfigMenu;
using ModConfigMenu.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace FixGunpowderWeight
{
    internal class McmConfiguration
    {

        public ModConfig Config { get; set; }

        public McmConfiguration(ModConfig config)
        {
                Config = config;
        }


        /// <summary>
        /// Attempts to configure the MCM, but logs an error and continues if it fails.
        /// </summary>
        public bool TryConfigure()
        {
            try
            {
                Configure();
                return true;
            }
            catch (FileNotFoundException)
            {

                Plugin.Logger.Log("Bypassing MCM. The 'Mod Configuration Menu' mod is not loaded. ");
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex,"Bypassing MCM");
            }

            return false;

        }

        public void Configure()
        {
            ModConfig defaults = new ModConfig();

            ModConfigMenuAPI.RegisterModConfig("Fix Gunpowder Weight", new List<ConfigValue>()
            {
                new ConfigValue(nameof(ModConfig.FixPowderWeight), Config.FixPowderWeight,"General", 
                    defaults.FixPowderWeight,
                    "Fixes the game's powder weight to be .01 instead of .10", "Fix Powder Weight"),

                new ConfigValue(nameof(ModConfig.FixAllDisassemblyToAssemblyCount), 
                    Config.FixAllDisassemblyToAssemblyCount,"General", 
                    defaults.FixAllDisassemblyToAssemblyCount,
                    "Changes disassembly outputs for all items to not be more than what is required to make the same item.","All Items: Fix Disassembly to Assembly Count"),

                new ConfigValue(nameof(ModConfig.FixAmmoDisassemblyToAssemblyCount), Config.FixAmmoDisassemblyToAssemblyCount,"General", defaults.FixAmmoDisassemblyToAssemblyCount,
                    "Changes any ammmo disassembly outputs to not be more than what is required to make the same item.","Ammo Only:Fix Disassembly to Assembly Count"),

                new ConfigValue(nameof(ModConfig.DebugLog), Config.DebugLog,"General", defaults.DebugLog,
                    "Will log the the changes to the items' production requirements.","Enable Debug Logging"),

                new ConfigValue("__Notice", "The game must be restarted for any changes to take effect","Note"),
            }, OnSave);

        }

        private bool OnSave(Dictionary<string, object> currentConfig, out string feedbackMessage)
        {
            feedbackMessage = "";

            try
            {
                Config.FixAllDisassemblyToAssemblyCount = (bool)currentConfig[nameof(ModConfig.FixAllDisassemblyToAssemblyCount)];
                Config.FixAmmoDisassemblyToAssemblyCount = (bool)currentConfig[nameof(ModConfig.FixAmmoDisassemblyToAssemblyCount)];
                Config.FixPowderWeight = (bool)currentConfig[nameof(ModConfig.FixPowderWeight)];
                Config.DebugLog = (bool)currentConfig[nameof(ModConfig.DebugLog)];

                Config.Save();
                return true;
            }
            catch(Exception ex)
            {
                Plugin.Logger.LogError(ex, "Error saving the configuration");
            }

            return false;
        }
    }
}
