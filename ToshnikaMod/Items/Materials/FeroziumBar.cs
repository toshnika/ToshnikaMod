using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Materials
{
    public class FeroziumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A bar of an ancient alloy\nIt contains iron, that's for sure\nThe rest of the alloy is unknown\nDon't lick it...");

        }
        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 4, 0, 0);
            item.width = item.height = 32;
            item.maxStack = 999;
            item.rare = 5;
            item.consumable = true;
            item.createTile = mod.TileType("FeroziumBar");
            item.useStyle = 1;
            item.useAnimation = 18;
            item.useTime = 16;
            item.useTurn = true;
            item.autoReuse = true;
        }      
    }
}