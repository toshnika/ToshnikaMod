using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips
{
    public class PunchCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased ranged velocity and knockback");
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
            player.velocity *= 1.1f;
            player.kbBuff = true;
        }

        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneSlab,5);
            recipe.AddIngredient(ItemID.Rope, 5);
            recipe.AddIngredient(ItemID.WoodenArrow, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}