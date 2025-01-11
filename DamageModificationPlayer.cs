using BlessingsFromAbove.Content.Items.Accessories;
using BlessingsFromAbove.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BlessingsFromAbove.Content.Common.Players
{
    internal class DamageModificationPlayer : ModPlayer
    {
        public float AdditiveCritDamageBonus;



        public override void PreUpdate()
        {
            // Timers and cooldowns should be adjusted in PreUpdate

        }

        public override void ResetEffects()
        {
            AdditiveCritDamageBonus = 0f;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (AdditiveCritDamageBonus > 0)
            {
                modifiers.CritDamage += AdditiveCritDamageBonus;
            }
        }


        public static void SendExampleDodgeMessage(int whoAmI)
        {
            // This code is called by both the initial 
            ModPacket packet = ModContent.GetInstance<BlessingsFromAbove>().GetPacket();
            packet.Write((byte)whoAmI);
            packet.Send(ignoreClient: whoAmI);
        }
    }
}
