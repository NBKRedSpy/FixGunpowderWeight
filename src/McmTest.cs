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
    internal class McmTest
    {

        public void Test()
        {
            ModConfigMenuAPI.RegisterModConfig("test", new List<ConfigValue>()
            {
                new ConfigValue("blah", "valuetest","headertest", "false", "this si a toolstip", "this is a label"),
                new ConfigValue("blah2", false,"headertest 2", true, "also tooltip", "this is a label as well")
            }, OnSave);



            //ModConfigMenuAPI.RegisterModConfig("test", new List<ConfigValue>(), (ModConfigMenu.ModConfigMenuAPI.ConfigStoredDelegate) OnSave);

        }


        private bool OnSave(Dictionary<string, object> currentConfig, out string feedbackMessage)
        {
            Debug.LogWarning("test");
            feedbackMessage = "huh";

            return true;
        }
    }
}
