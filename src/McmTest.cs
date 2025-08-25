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
                new ConfigValue("blahKey", false,"foo header", false, "this si a toolstip", "this is a label"),
                new ConfigValue("blah2", "valuetest2","Filled in header", "Foovalue", "this is a toolstip 2", "this is a label 2"),
            }, OnSave);

        }


        private bool OnSave(Dictionary<string, object> currentConfig, out string feedbackMessage)
        {
            Debug.LogWarning("test");
            feedbackMessage = "huh";

            return true;
        }
    }
}
