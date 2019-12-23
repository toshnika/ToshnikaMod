using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Materials
{
    public class MagicShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Used for various magical recipes");

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
            ModRecipe 
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"));
            recipe.AddIngredient(ItemID.CrystalShard, 2);
            recipe.AddIngredient(ItemID.LivingFireBlock, 2);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"));
            recipe.AddIngredient(ItemID.CrystalShard, 2);
            recipe.AddIngredient(mod.ItemType("FeroziumBar"));
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
}