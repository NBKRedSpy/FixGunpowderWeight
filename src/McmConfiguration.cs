using ModConfigMenu;
using ModConfigMenu.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
            ModConfigMenuAPI.RegisterModConfig("Fix Gunpowder Weight", new List<ConfigValue>()
            {
                new ConfigValue(nameof(ModConfig.FixPowderWeight), Config.FixPowderWeight,"General", true, 
                    "Fixes the game's powder weight to be .01 instead of .10", "Fix Powder Weight"),
                new ConfigValue(nameof(ModConfig.FixDisassemblytoAssemblyCount), Config.FixDisassemblytoAssemblyCount,"General", false, 
                    "Changes any disassembly outputs to not be more than what is required to make the same item.","Fix Disassembly to Assembly Count"),
                new ConfigValue("__Notice", "The game must be restarted for any changes to take effect","Note"),
            }, OnSave);
        }

        private bool OnSave(Dictionary<string, object> currentConfig, out string feedbackMessage)
        {
            feedbackMessage = "";

            try
            {
                Config.FixDisassemblytoAssemblyCount = (bool)currentConfig[nameof(ModConfig.FixDisassemblytoAssemblyCount)];
                Config.FixPowderWeight = (bool)currentConfig[nameof(ModConfig.FixPowderWeight)];

                Config.Save();
                return true;
            }
            catch(Exception ex)
            {
                Plugin.Logger.LogError("Error saving the configuration");
                Plugin.Logger.LogError(ex);
            }

            return false;
        }
    }
}
