using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Magic
{
    public class LightLeech : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires a prismatic blast that steals mana and has a chance to steal life");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.magic = true;
            item.mana = 20;
            item.width = 40;
            item.height = 40;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.knockBack = 5;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 5;
            item.shootSpeed = 12;
            item.shoot = mod.ProjectileType("PrismZap");
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"), 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}