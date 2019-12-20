using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips
{
    public class CrystalOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grants a short range, high speed crystal dash \nYou leave damaging crystal shards after dashing");

            //Being hit gives you the 'shattered crystal' debuff
            //This debuff removes the crystal shards from your dash, and reduces your life regen by 1
        }

        public override void SetDefaults()
        {

            item.value = 100000;
            item.rare = 5;
            item.width = 32;
            item.height = 28;
            item.accessory = true;
            item.value = Item.buyPrice(0, 8, 0, 0);

        }

        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<CDashPlayer>();
            modPlayer.dashC = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 10);
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class CDashPlayer : ModPlayer
    {
        public float customDashSpeed = 0;
        public float customDashBonusSpeed = 0;
        public bool dashC = false;
        public override void ResetEffects()
        {
            customDashSpeed = 0;
            customDashBonusSpeed = 0;
	    dashC = false;
        }
        public override void PostUpdateEquips()
        {
            if (dashC == true)
            {
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
                        player.velocity.X = 18f * num21;
                        Point point3 = (player.Center + new Vector2(num21 * player.width / 2 + 2, player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
                        Point point4 = (player.Center + new Vector2(num21 * player.width / 2 + 2, 0f)).ToTileCoordinates();
                        if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = -1;
                        for (int num22 = 0; num22 < 100; num22++)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, SpeedX: 0, SpeedY: 0, Type: ProjectileID.CrystalStorm, Damage: 18, KnockBack: 1f, Main.myPlayer);
                            Projectile.NewProjectile(player.Center.X, player.Center.Y +1, SpeedX: 0, SpeedY: 0, Type: ProjectileID.CrystalStorm, Damage: 18, KnockBack: 1f, Main.myPlayer);
                            Projectile.NewProjectile(player.Center.X, player.Center.Y -1, SpeedX: 0, SpeedY: 0, Type: ProjectileID.CrystalStorm, Damage: 18, KnockBack: 1f, Main.myPlayer);

                        }
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
                    player.dashDelay = 60;
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
    
