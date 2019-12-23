using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Equips
{
    [AutoloadEquip(EquipType.Shield)]
    public class ShieldOfResilience : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Immune to knockback and many debuffs\nYou can dash\nBoosted defense and regen below 66% life\nReduces damage taken by projectiles, even more so while standing still");
        }

        public override void SetDefaults()
        {
            item.defense = 12;
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(1, 80, 0, 0);
            item.rare = 7;
            item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.noKnockback = true;

            var modPlayer = player.GetModPlayer<SORPlayer>();
            modPlayer.dashS = true;
        }
        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 8);
            recipe.AddIngredient(mod.ItemType("CrystalOrb"));
            recipe.AddIngredient(mod.ItemType("MotherOfPearl"), 10);
            recipe.AddIngredient(mod.ItemType("MagicShard"), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
    public class SORPlayer : ModPlayer
    {
        public float customDashSpeed = 0;
        public float customDashBonusSpeed = 0;
        public bool dashS = false;
        public bool grottoSet = false;

        public override void ResetEffects()
        {
            customDashSpeed = 0;
            customDashBonusSpeed = 0;
            grottoSet = false;
            dashS = false;
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (dashS) 
            {
                if (player.velocity.X == 0f && player.velocity.Y == 0f)
                {
                    player.statLife += damage / 4;
                }
                else
                {
                    player.statLife += damage / 10;
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if (dashS == true)
            {
                if (player.statLife < player.statLifeMax2 * 0.66f)
                {
                    player.lifeRegen += 4;
                    player.statDefense += 40;
                }
                if (player.dash <= 0 && player.dashDelay == 0 && !player.mount.Active)
                {

                    int num21 = 0;
                    bool flag2 = false;
                    if (player.dashTime > 0)
                        player.dashTime--;
                    if (player.dashTime < 0)
                        player.dashTime++;

                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num21 = 1;
                            flag2 = true;
                            player.dashTime = 0;
                        }
                        else
                        {
                            player.dashTime = 15;
                        }
                    }
                    else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num21 = -1;
                            flag2 = true;
                            player.dashTime = 0;
                        }
                        else
                        {
                            player.dashTime = -15;
                        }
                    }

                    if (flag2)
                    {
                        player.velocity.X = 21f * num21;
                        Point point3 = (player.Center + new Vector2(num21 * player.width / 2 + 2, player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
                        Point point4 = (player.Center + new Vector2(num21 * player.width / 2 + 2, 0f)).ToTileCoordinates();
                        if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = -1;
                    }
                }
                if (player.dashDelay < 0)
                {
                    for (int l = 0; l < 0; l++)
                    {
                        int num14;
                        if (player.velocity.Y == 0f)
                        {
                            num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4f), player.width, 8, 59, 0f, 0f, 100, default(Color), 1.4f);
                        }
                        else
                        {
                            num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (player.height / 2) - 8f), player.width, 16, 59, 0f, 0f, 100, default(Color), 1.4f);
                        }
                        Main.dust[num14].velocity *= 0.1f;
                        Main.dust[num14].scale *= 1f + Main.rand.Next(20) * 0.01f;
                        Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(player.shoe, player);
                    }

                    float maxSpeed = Math.Max(player.accRunSpeed, player.maxRunSpeed);

                    player.vortexStealthActive = false;
                    if (player.velocity.X > 12f || player.velocity.X < -12f)
                    {
                        player.velocity.X = player.velocity.X * 0.985f;
                        return;
                    }
                    if (player.velocity.X > maxSpeed || player.velocity.X < -maxSpeed)
                    {
                        player.velocity.X = player.velocity.X * 0.94f;
                        return;
                    }
                    player.dashDelay = 48;
                    if (player.velocity.X < 0f)
                    {
                        player.velocity.X = -maxSpeed;
                        return;
                    }
                    if (player.velocity.X > 0f)
                    {
                        player.velocity.X = maxSpeed;
                    }
                }
            }
        }
    }
}