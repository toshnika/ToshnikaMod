using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ToshnikaMod.Blocks
{
    public class PrismGrit : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("PrismGrit");
            AddMapEntry(new Color(100, 220, 200));
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.15f;
            g = 0.16f;
            b = 0.16f;
        }
    }
}