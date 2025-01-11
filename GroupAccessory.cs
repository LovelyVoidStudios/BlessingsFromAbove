using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BlessingsFromAbove.Content.Common.Players
{
    public abstract class GroupAccessory : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true; // Mark as an accessory
        }

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            // Check if any other accessory from the group is already equipped
            for (int i = 0; i < player.armor.Length; i++)
            {
                if (i == slot) continue; // Skip the current slot being checked
                if (player.armor[i].ModItem is GroupAccessory)
                {
                    return false; // Deny equipping if another GroupAccessory is equipped
                }
            }
            return base.CanEquipAccessory(player, slot, modded);
        }
    }
}
