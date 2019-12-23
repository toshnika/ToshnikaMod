using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Thrown
{
    public class FeatherKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Throws three homing feather knives");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.thrown = true;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1.5f;
            item.shoot = mod.ProjectileType("FeatherKunai");
            item.value = 80;
            item.rare = 4;
            item.shootSpeed = 18f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float angle = (new Vector2(speedX, speedY)).ToRotation();
            float trueSpeed = (new Vector2(speedX, speedY)).Length();
            Projectile.NewProjectile(player.MountedCenter.X, player.MountedCenter.Y, (float)Math.Cos(angle + MathHelper.ToRadians(Main.rand.Next(-5, 6))) * trueSpeed, (float)Math.Sin(angle + MathHelper.ToRadians(Main.rand.Next(-5, 6))) * trueSpeed, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(player.MountedCenter.X, player.MountedCenter.Y, (float)Math.Cos(angle + MathHelper.ToRadians(Main.rand.Next(-5, 6))) * trueSpeed, (float)Math.Sin(angle + MathHelper.ToRadians(Main.rand.Next(-5, 6))) * trueSpeed, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(player.MountedCenter.X, player.MountedCenter.Y, (float)Math.Cos(angle + MathHelper.ToRadians(Main.rand.Next(-5, 6))) * trueSpeed, (float)Math.Sin(angle + MathHelper.ToRadians(Main.rand.Next(-5, 6))) * trueSpeed, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
    

    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}