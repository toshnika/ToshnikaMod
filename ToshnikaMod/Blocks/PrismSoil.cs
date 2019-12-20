using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ToshnikaMod.Blocks
{
    public class PrismSoil : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("PrismSoil");
            AddMapEntry(new Color(100, 220, 200));
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.12f;
            g = 0.22f;
            b = 0.20f;
        }
    }
}