using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using Terraria.GameInput;
using Terraria.ModLoader.IO;
namespace ToshnikaMod
{
    public class ToshnikaPlayer : ModPlayer
    {
        public bool PrismCave = false;
        public override void UpdateBiomes()
        {
            PrismCave = (ToshnikaWorld.prismCave > 0);
        }
    }
}
