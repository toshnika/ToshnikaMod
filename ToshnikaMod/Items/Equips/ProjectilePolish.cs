using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips
{
    public class ProjectilePolish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+15% Throwing damage");
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
            player.thrownDamage *= 1.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Blinkroot, 3);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}