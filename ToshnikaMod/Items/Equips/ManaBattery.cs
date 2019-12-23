using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips
{
    public class ManaBattery : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+25 Max mana");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 12, 0, 0);
            item.rare = 4;
            item.accessory = true;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 25;
        }

        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(RecipeGroupID.IronBar, 4);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}