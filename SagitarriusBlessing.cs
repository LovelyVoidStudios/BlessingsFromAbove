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
    public class SagittariusBlessing : GroupAccessory
    {
        public static readonly int AdditiveDamageBonus = 25;
        public static readonly int MultiplicativeDamageBonus = 12;
        public static readonly int BaseDamageBonus = 4;
        public static readonly int FlatDamageBonus = 5;
        public static readonly int RangedAttackSpeedBonus = 15;
        public static readonly int ExampleKnockback = 100;
        public static readonly int AdditiveCritDamageBonus = 20;

        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveDamageBonus, MultiplicativeDamageBonus, BaseDamageBonus, FlatDamageBonus, RangedAttackSpeedBonus, ExampleKnockback, AdditiveCritDamageBonus);

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += AdditiveDamageBonus / 100f;
            player.GetDamage(DamageClass.Ranged) *= 1 + MultiplicativeDamageBonus / 100f;
            player.GetDamage(DamageClass.Ranged).Base += BaseDamageBonus;
            player.GetDamage(DamageClass.Ranged).Flat += FlatDamageBonus;
            player.GetAttackSpeed(DamageClass.Ranged) += RangedAttackSpeedBonus / 100f;
              
               
              
            
        }
    }

    // Some movement effects are not suitable to be modified in ModItem.UpdateAccessory due to how the math is done.
    // ModPlayer.PostUpdateRunSpeeds is suitable for these modifications.
    public class SagittariusBlessingPlayer : ModPlayer
    {
        public bool SagittariusBlessing = false;

        public override void ResetEffects()
        {
            SagittariusBlessing = false;
        }

        public override void PostUpdateRunSpeeds()
        {
            // We only want our additional changes to apply if ExampleStatBonusAccessory is equipped and not on a mount.
            if (Player.mount.Active || !SagittariusBlessing)
            {
                return;
            }
        }
    }
}    


