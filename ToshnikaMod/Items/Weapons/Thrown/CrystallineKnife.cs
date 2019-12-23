using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Thrown
{
    public class CrystallineKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can be used by prism gauntlet too");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.thrown = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 0.8f;
            item.value = 10;
            item.rare = 5;
            item.shoot = mod.ProjectileType("CrystallineKnife");
            item.shootSpeed = 15f;
	    item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 49);
            recipe.AddRecipe();
        }
    }
}