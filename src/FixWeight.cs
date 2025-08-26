using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace FixGunpowderWeight
{
    internal class AssemblyJoin
    {
        public string Id { get; set; }
        public List<ItemQuantity> RequiredItems { get; set; }

        public List<ItemQuantity> OutputItems { get; set; }

        public ItemTransformationRecord ItemTransformationRecord  { get; set; }

        public AssemblyJoin(string id, List<ItemQuantity> requiredItems, List<ItemQuantity> outputItems, ItemTransformationRecord itemTransformationRecord)
        {
            Id = id;
            RequiredItems = requiredItems;
            OutputItems = outputItems;
            ItemTransformationRecord = itemTransformationRecord;
        }
    }

    internal class FixWeight
    {

        /// <summary>
        /// Changes the powder weight from the incorrect .1 to .01.
        /// Changes all *_ammo disassembly outputs to be no more than the same 
        /// resource that is required to make the item.  Ex:  small_basic_ammo
        /// requires one powder to manufacture, but by default disassembly can produce two powder.
        /// </summary>
        /// <exception cref="BaseDataIssueException"></exception>
        public void Update()
        {

            if(Plugin.Config.FixPowderWeight)
            {
                if (Plugin.Config.DebugLog) { Plugin.Logger.Log("Fixing Powder Weight"); };

                var powder = (Data.Items.GetRecord("powder") as CompositeItemRecord)?.PrimaryRecord as TrashRecord;


                if (powder == null || powder.Weight != 0.1f)
                {
                    throw new BaseDataIssueException($"Source Power Weight was not 0.1.  Value: {powder?.Weight}");
                }

                powder.Weight = 0.01f;
            }

            if(Plugin.Config.FixAmmoDisassemblyToAssemblyCount || Plugin.Config.FixAllDisassemblyToAssemblyCount)
            {
                Func<ItemProduceReceipt, bool> FilterItemTypes(bool fixAll)
                {
                    if (fixAll)
                    {
                        return (ItemProduceReceipt) => { return true; };
                    }
                    else
                    {
                        return (ItemProduceReceipt x) => x.OutputItem.EndsWith("_ammo");
                    }
                }

                //Game "config" data to Data static object's stores.
                //
                //itemreceipts = assembly requirements = Data.ProduceReceipts
                //itemtransformation = disassembly outputs = Data.ItemTransformation

                //Join an item's production requirements to the disassembly outputs for the same item.
                //  Ex item A takes 1 powder to create.  Match to disassembly powder requriement.
                var joined = Data.ProduceReceipts
                    .Where(FilterItemTypes(Plugin.Config.FixAllDisassemblyToAssemblyCount))
                    .Join(Data.ItemTransformation._records.Values, outer => outer.OutputItem, inner => inner.Id,
                        (inner, outer) => new AssemblyJoin( inner.Id, inner.RequiredItems, outer.OutputItems, outer))
                    .ToList();

                foreach (AssemblyJoin item in joined)
                {
                    //Return the list of items where disassembling an item creates more outputs than it takes
                    //  to manufacture the same item.
                    //  Ex:  The current issue is that small_basic_ammo can disassemble to 
                    //  up to 2 powder, but it only takes 1 to manufacture.
                    var produceDisassemblyMismatch = 
                        item.OutputItems
                            .Join(item.RequiredItems, a => a.ItemId, b => b.ItemId, (a, b) =>
                                new { a.ItemId, OutputCount = a.Count, InputCount = b.Count, DisasemblyOutputItem = a })
                            .Where(x => x.OutputCount > x.InputCount)
                            .ToList();

                   //Remove the original disassembly ItemQuantity struct and replace with the adjusted quantity.
                   foreach(var outputMismatch in produceDisassemblyMismatch)
                    {
                        item.OutputItems.Remove(outputMismatch.DisasemblyOutputItem);
                        item.OutputItems.Add(new ItemQuantity(outputMismatch.DisasemblyOutputItem.ItemId, 
                            outputMismatch.InputCount));

                        if(Plugin.Config.DebugLog)
                        {
                            Plugin.Logger.Log($"{item.ItemTransformationRecord.Id} {outputMismatch.ItemId} Assemble {outputMismatch.InputCount} Disassemble: {outputMismatch.OutputCount}");

                        }
                    }
                }
            }

        }

    }
}
