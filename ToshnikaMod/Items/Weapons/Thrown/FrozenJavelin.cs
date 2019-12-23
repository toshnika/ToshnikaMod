using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Thrown
{
    public class FrozenJavelin : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Freezes enemies");

        }
        public override void SetDefaults()
        {
            item.shootSpeed = 14f;
            item.damage = 60;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 26;
            item.useTime = 26;
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 4;
            item.value = 30;
            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;

            item.shoot = mod.ProjectileType("FrozenJavelin");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddIngredient(RecipeGroupID.IronBar, 8);
            recipe.AddIngredient(ItemID.IceBlock, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}