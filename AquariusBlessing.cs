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
    public class AquariusBlessing : GroupAccessory
    {
        public static readonly int AdditiveDamageBonus = 25;
        public static readonly int MultiplicativeDamageBonus = 12;
        public static readonly int BaseDamageBonus = 4;
        public static readonly int FlatDamageBonus = 5;
        public static readonly int MeleeCritBonus = 10;
        public static readonly int RangedAttackSpeedBonus = 15;
        public static readonly int MagicArmorPenetration = 5;
        public static readonly int ExampleKnockback = 100;
        public static readonly int AdditiveCritDamageBonus = 20;
        public static readonly int MoveSpeedBonus = 8;

        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveDamageBonus, MultiplicativeDamageBonus, BaseDamageBonus, FlatDamageBonus, MeleeCritBonus, RangedAttackSpeedBonus, MagicArmorPenetration, ExampleKnockback, AdditiveCritDamageBonus);

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.IsItRaining || Main.IsItStorming)
            {

                player.GetDamage(DamageClass.Generic) += AdditiveDamageBonus / 100f;
                player.GetDamage(DamageClass.Generic) *= 1 + MultiplicativeDamageBonus / 100f;
                player.GetDamage(DamageClass.Generic).Base += BaseDamageBonus;
                player.GetDamage(DamageClass.Generic).Flat += FlatDamageBonus;
                player.GetCritChance(DamageClass.Melee) += MeleeCritBonus;
                player.GetAttackSpeed(DamageClass.Ranged) += RangedAttackSpeedBonus / 100f;
                player.GetArmorPenetration(DamageClass.Magic) += MagicArmorPenetration;
                player.moveSpeed += MoveSpeedBonus / 100f;
                player.accRunSpeed = 6.75f;
            }
        }
    }

    // Some movement effects are not suitable to be modified in ModItem.UpdateAccessory due to how the math is done.
    // ModPlayer.PostUpdateRunSpeeds is suitable for these modifications.
    public class AquariusBlessingAccessoryPlayer : ModPlayer
    {
        public bool AquariusBlessingAccessory = false;

        public override void ResetEffects()
        {
            AquariusBlessingAccessory = false;
        }

        public override void PostUpdateRunSpeeds()
        {
            // We only want our additional changes to apply if ExampleStatBonusAccessory is equipped and not on a mount.
            if (Player.mount.Active || !AquariusBlessingAccessory)
            {
                return;
            }

            // The following modifications are similar to Shadow Armor set bonus
            Player.runAcceleration *= 1.75f; // Modifies player run acceleration
            Player.maxRunSpeed *= 1.15f;
            Player.accRunSpeed *= 1.15f;
            Player.runSlowdown *= 1.75f;
        }
    }
}    


