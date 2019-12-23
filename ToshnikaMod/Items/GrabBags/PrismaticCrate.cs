using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace ToshnikaMod.Items.GrabBags
{
    public class PrismaticCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Crate");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 48;
            item.height = 32;
            item.rare = 2;
            item.useStyle = 1;
            item.useAnimation = 18;
            item.useTime = 16;
            item.createTile = mod.TileType("PrismaticCrate");
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.NextBool(8))
            {
                player.QuickSpawnItem(mod.ItemType("PrismSoil"), 20 + Main.rand.Next(10));
                player.QuickSpawnItem(mod.ItemType("PrismGrit"), 20 + Main.rand.Next(10));
                player.QuickSpawnItem(mod.ItemType("PrismOre"), 20 + Main.rand.Next(10));
                player.QuickSpawnItem(mod.ItemType("SpectrumPrism"), 5 + Main.rand.Next(5));
            }
            if (Main.rand.Next(1) == 0)
            {
                if (Main.rand.Next(2) == 0)
                {
                    player.QuickSpawnItem(ItemID.MasterBait, 5);
                }
                else if (Main.rand.Next(2) == 1)
                {
                    player.QuickSpawnItem(ItemID.JourneymanBait, 8);
                }
                else if (Main.rand.Next(2) == 2)
                {
                    player.QuickSpawnItem(ItemID.ApprenticeBait, 10);
                }
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(ItemID.GoldCoin, 5);
            }
            else if (Main.rand.Next(2) == 1)
            {
                player.QuickSpawnItem(ItemID.SilverCoin, 50);
            }
            else if (Main.rand.Next(2) == 2)
            {
                player.QuickSpawnItem(ItemID.CopperCoin, 80);
            }
        }
    }
}
