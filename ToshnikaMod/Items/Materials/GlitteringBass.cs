using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Materials
{
    public class GlitteringBass : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");

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