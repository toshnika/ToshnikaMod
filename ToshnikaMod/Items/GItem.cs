using System;
using Terraria;
using Terraria.ModLoader;

namespace ToshnikaMod.Items
{
    public class GItem : GlobalItem
    {
        public override float UseTimeMultiplier(Item item, Player player)
        {
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            if (modPlayer.HFSkeleton == true && item.thrown)
            {
                return 1.2f;
            }
            return 1f;
        }
    }
}