using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Materials
{
    public class MotherOfPearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shiny!");

        }
        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.width = item.height = 32;
            item.maxStack = 999;
            item.rare = 3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 2);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
}