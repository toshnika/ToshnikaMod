using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Equips
{
    public class FrostCoating : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Attacks have a chance to briefly freeze enemies");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.expert = true;
            item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.frostCoating = true;
        }
    }
}