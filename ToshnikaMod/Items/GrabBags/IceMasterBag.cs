using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ToshnikaMod.Items.GrabBags
{
    public class IceMasterBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 48;
            item.height = 32;
            item.rare = 9;
            item.expert = true;
        }

       

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {   
            player.QuickSpawnItem(mod.ItemType("FrostCoating"));
            player.QuickSpawnItem(mod.ItemType("FeroziumBar"), 20 + Main.rand.Next(10));
            player.QuickSpawnItem(ItemID.GoldCoin, 10);
        }
        public override int BossBagNPC => mod.NPCType("IceMaster");

    }
}
