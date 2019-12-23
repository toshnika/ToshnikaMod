using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Materials
{
    public class TranslucentFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("You can see through this fish\nSpooky and kinda gross");

        }
        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.width = item.height = 32;
            item.maxStack = 999;
            item.rare = 3;
        }
    }
}