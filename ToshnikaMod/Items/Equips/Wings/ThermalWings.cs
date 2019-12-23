using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class ThermalWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strong Ascent \nHorizontal Speed: 10.5 \nAcceleration: 2.25");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 10000;
            item.rare = 9;
            item.accessory = true;
            item.expert = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 135;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.2f;
            maxCanAscendMultiplier = 1.15f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.16f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 10.5f;
            acceleration *= 2.25f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddIngredient(ItemID.FlameWings);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}