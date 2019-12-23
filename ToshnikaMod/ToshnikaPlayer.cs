using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using Terraria.GameInput;
using Terraria.ModLoader.IO;
namespace ToshnikaMod
{
    public class ToshnikaPlayer : ModPlayer
    {
        public bool PrismCave = false;
        public bool woodCross = false;
        public bool jeweledCross = false;
        public bool grottoHelm = false;
        public bool grottoPlate = false;
        public bool absorbtionShield = false;
        public bool HFSkeleton = false;
        public bool HFSet = false;



        public override void ResetEffects()
        {
            woodCross = false;
            jeweledCross = false;
            grottoHelm = false;
            grottoPlate = false;
            absorbtionShield = false;
            HFSkeleton = false;
            HFSet = false;
        }
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }
            if(PrismCave && Main.rand.Next(5) == 0)
            {
                caughtType = ItemID.Prismite;
            }
            if (PrismCave && Main.rand.Next(10) == 0)
            {
                caughtType = mod.ItemType("PrismaticCrate");
            }
            if (PrismCave && Main.rand.Next(3) == 0)
            {
                caughtType = mod.ItemType("GlitteringBass");
            }
            if (PrismCave && Main.rand.Next(8) == 0)
            {
                caughtType = mod.ItemType("TranslucentFish");
            }
        }
        public override void PostUpdateMiscEffects()
        { 
            if(HFSet == true)
            {
                if (player.velocity.X > 0 || player.velocity.Y > 0)
                {
                    if (Main.rand.NextBool(45))
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 0, SpeedY: 1, Type: ProjectileID.MolotovFire, Damage: 30, KnockBack: 0.1f, Main.myPlayer);
                    }
                }
            }
        }
        public override void UpdateBiomes()
        {
            PrismCave = (ToshnikaWorld.prismCave > 0);
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (grottoHelm)
            {
                if (Main.rand.NextBool(8))
                {
                    player.statLife += damage / 6;
                }
            }
            if (grottoPlate)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 1, SpeedY: 1, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 1, SpeedY: -1, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: -1, SpeedY: 1, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: -1, SpeedY: -1, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 0, SpeedY: 1, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 1, SpeedY: 0, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: -1, SpeedY: 0, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 0, SpeedY: -1, Type: ProjectileID.CrystalStorm, Damage: 25, KnockBack: 0.2f, Main.myPlayer);
            }
            if (absorbtionShield)
            {
                player.immune = true;
                player.immuneTime = 18;

                if (player.longInvince)
                {
                    player.immuneTime -= 20;
                }

                for (int i = 0; i < player.hurtCooldowns.Length; i++)
                {
                    player.hurtCooldowns[i] = player.immuneTime;
                }
            }
            if (woodCross)
            {
                player.immune = true;
                player.immuneTime = 55;

                if (player.longInvince)
                {
                    player.immuneTime += 40;
                }

                for (int i = 0; i < player.hurtCooldowns.Length; i++)
                {
                    player.hurtCooldowns[i] = player.immuneTime;
                }
            }
            if (jeweledCross)
            {
                player.immune = true;
                player.immuneTime = 120;

                if (player.longInvince)
                {
                    player.immuneTime += 105;
                }

                for (int i = 0; i < player.hurtCooldowns.Length; i++)
                {
                    player.hurtCooldowns[i] = player.immuneTime;
                }
            }
            return true;
        }
    }
}
