using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using BlessingsFromAbove.Content.Common.Players;


namespace BlessingsFromAbove.Content.Items.Accessories
{
    public class AriesBlessing : GroupAccessory
    {

        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localization
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noFallDmg = true;
        }
    }

    // Some movement effects are not suitable to be modified in ModItem.UpdateAccessory due to how the math is done.
    // ModPlayer.PostUpdateRunSpeeds is suitable for these modifications.
    public class AriesBlessingPlayer : ModPlayer
    {
        public bool AriesBlessing = false;

        public override void ResetEffects()
        {
            AriesBlessing = false;
        }

        public override void PostUpdateRunSpeeds()
        {
            // We only want our additional changes to apply if ExampleStatBonusAccessory is equipped and not on a mount.
            if (Player.mount.Active || !AriesBlessing)
            {
                return;
            }
        
        }
    }
}    


