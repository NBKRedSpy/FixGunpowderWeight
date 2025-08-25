using ModConfigMenu;
using ModConfigMenu.Objects;
using System;
using System.Collections.Generic;
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

        public void Test()
        {
            ModConfigMenuAPI.RegisterModConfig("Fix Gunpowder Weight", new List<ConfigValue>()
            {
                new ConfigValue("FixPowderWeight", Config.FixPowderWeight,"General", true, "Fixes the game's powder weight to be .01 instead of .10", "FixPowderWeight"),
                new ConfigValue("FixDisassemblytoAssemblyCount", Config.FixDisassemblytoAssemblyCount,"General", false, "Changes any disassembly outputs to not be more than what is required to make the same item.","Fix Disassembly to Assembly Count"),
                new ConfigValue("__Notice", "The game must be restarted for any changes to take effect","Note"),
            }, OnSave);
        }


        private bool OnSave(Dictionary<string, object> currentConfig, out string feedbackMessage)
        {
            feedbackMessage = "";

            try
            {
                Config.FixDisassemblytoAssemblyCount = (bool)currentConfig["FixDisassemblytoAssemblyCount"];
                Config.FixPowderWeight = (bool)currentConfig["FixPowderWeight"];

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
