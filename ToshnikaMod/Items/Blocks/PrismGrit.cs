using Terraria;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Blocks
{
    internal sealed class PrismGrit : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("A fine powder of radiant sediments");
        }


        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 40;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.createTile = mod.TileType("PrismGrit");
        }
    }
}