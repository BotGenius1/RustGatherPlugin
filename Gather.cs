using Oxide.Core;
using Oxide.Plugins;
using UnityEngine;
using System;


namespace Oxide.Plugins
{
    [Info("Gather Rate Multiplier", "Austin9675", "1.0.0")]
    [Description("Increases the gather rate in Rust.")]
    public class Gather : RustPlugin
    {
        private float dispenserMultiplier = 2f;
        private float pickupMultiplier = 2f;
        private float quarryMultiplier = 2f;
        System.Random random = new System.Random();
        private void Init()
        {
            Puts("Gather plugin has been initialized!");
        }

        void OnDispenserGather(ResourceDispenser dispenser, BaseEntity entity, Item item)
        {
            item.amount = Mathf.CeilToInt(item.amount * dispenserMultiplier);
        }

       void OnItemPickup(Item item, BasePlayer player)
        {
            int randomPickup = random.Next(2, 5);
            item.amount = Mathf.CeilToInt(item.amount * randomPickup);
        }

        void OnCollectiblePickup(Item item, BasePlayer player, CollectibleEntity collectible)
        {
            item.amount = Mathf.CeilToInt(item.amount * pickupMultiplier);
        }

        void OnQuarryGather(MiningQuarry quarry, Item item)
        {
            item.amount = Mathf.CeilToInt(item.amount * quarryMultiplier);
        }
    }
}