using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace FixGunpowderWeight
{
    public class ModConfig
    {

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };

        /// <summary>
        /// If true, will set the powder weight to .01 from the current value of .1
        /// </summary>
        public bool FixPowderWeight { get; set; } = true;
        
        /// <summary>
        /// If true, will change any disassembly outputs to not be more than what is required to make the same item.
        /// Ex: small_basic_ammo currently can be disassembled to a max of 2, but requires 1 to make.
        /// </summary>
        public bool FixDisassemblytoAssemblyCount { get; set; } = false; 

        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;


            if (File.Exists(configPath))
            {
                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, SerializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, SerializerSettings);

                    if (upgradeConfig != sourceJson)
                    {
                        Plugin.Logger.Log("Updating config with missing elements");
                        //re-write
                        File.WriteAllText(configPath, upgradeConfig);
                    }

                    return config;
                }
                catch (Exception ex)
                {
                    Plugin.Logger.LogError("Error parsing configuration.  Ignoring config file and using defaults");
                    Plugin.Logger.LogError(ex);

                    //Not overwriting in case the user just made a typo.
                    config = new ModConfig();
                    return config;
                }
            }
            else
            {
                config = new ModConfig();
                
                string json = JsonConvert.SerializeObject(config, SerializerSettings);
                File.WriteAllText(configPath, json);

                return config;
            }
        }

        public void Save()
        {
            //Add any new elements that have been added since the last mod version the user had.
            string configText = JsonConvert.SerializeObject(this, SerializerSettings);

            //re-write
            File.WriteAllText(Plugin.ConfigDirectories.ConfigPath, configText);
        }
    }
}
