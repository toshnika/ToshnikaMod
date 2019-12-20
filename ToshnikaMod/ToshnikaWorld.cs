using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
namespace ToshnikaMod
{
    public class ToshnikaWorldGen : ModWorld
    {
        public static bool prismCave = false;
        public override void Initialize()
        {
            prismCave = false;
        }
        public static void GenPrismCave()
        {
            int startPositionX = WorldGen.genRand.Next(0, Main.maxTilesX - 2);
            int startPositionY = 700;
            int size = 0;
            if (Main.maxTilesX == 4200 && Main.maxTilesY == 1200)
            {
                size = 120;
            }
            if (Main.maxTilesX == 6300 && Main.maxTilesY == 1800)
            {
                size = 120;
            }
            if (Main.maxTilesX == 8400 && Main.maxTilesY == 2400)
            {
                size = 120;
            }

                var startX = startPositionX;
                var startY = startPositionY;
                for (int x = startX - size; x <= startX + size; x++)
                {
                    for (int y = startY - size; y <= startY + size; y++)
                    {
                        if (Vector2.Distance(new Vector2(startX, startY), new Vector2(x, y)) <= size)
                        {
                            if (Main.tile[x, y].wall == 40 || Main.tile[x, y].wall == 71)
                            {
                                Main.tile[x, y].wall = (ushort)WallID.Stone;
                            }
                            if (Main.tile[x, y].type == TileID.Stone || Main.tile[x, y].type == TileID.Granite || Main.tile[x, y].type == TileID.Marble || Main.tile[x, y].type == TileID.Ebonstone || Main.tile[x, y].type == TileID.Crimstone || Main.tile[x, y].type == TileID.Pearlstone || Main.tile[x, y].type == TileID.IceBlock)
                            {
                                Main.tile[x, y].type = (ushort)ToshnikaMod.instance.TileType("PrismOre");
                            }
                            if (Main.tile[x, y].type == TileID.Sand || Main.tile[x, y].type == TileID.Silt)
                            {
                                Main.tile[x, y].type = (ushort)ToshnikaMod.instance.TileType("PrismGrit");

                            }
                            if (Main.tile[x, y].type == TileID.Dirt || Main.tile[x, y].type == TileID.Mud || Main.tile[x, y].type == TileID.SnowBlock)
                            {
                                Main.tile[x, y].type = (ushort)ToshnikaMod.instance.TileType("PrismSoil");
                            }
                        }
                    }
                }
                for (int k = 0; k < 1000; k++)
                {
                    int positionX = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int positionY = WorldGen.genRand.Next(0, Main.maxTilesY-1200);
                    if (Main.tile[positionX, positionY].type == ToshnikaMod.instance.TileType("PrismOre"))
                    {
                        WorldGen.TileRunner(positionX, positionY, WorldGen.genRand.Next(2, 8), WorldGen.genRand.Next(2, 8), (ushort)ToshnikaMod.instance.TileType("PrismGrit"), false, 0f, 0f, false, true);
                    }
                }
                for (int k = 0; k < Main.maxTilesX; k++)
                {
                    for (int i = 0; i < Main.maxTilesY; i++)
                    {
                        if (Main.tile[k, i].type == ToshnikaMod.instance.TileType("PrismOre"))
                        {
                            if (Main.tile[k + 1, i].active() && Main.tile[k, i - 1].active() && Main.tile[k - 1, i].active() && Main.tile[k, i + 1].active())
                            {
                            }
                            else
                            {
                                Main.tile[k, i].type = (ushort)ToshnikaMod.instance.TileType("PrismSoil");
                            }
                        }
                    }
                }

                for (int k = 0; k < 16; k++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        WorldGen.KillTile(startX - k, startY - l, false, false, true);
                    }
                }

                for (int k = 0; k < 16; k++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        WorldGen.KillTile(startX - k, startY - l, false, false, true);
                    }
                }

                for (int k = 0; k < 16; k++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        WorldGen.KillTile(startX - k, startY - l, false, false, true);
                    }
                }
        }
    }
    public class ToshnikaWorld : ModWorld
    {
        public static int prismCave = 0;
        public static bool GotPCave = false;
        public override void Initialize()
        {
            GotPCave = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (GotPCave) downed.Add("Got Prism Cave");
            return new TagCompound {
                {"downed", downed}
            };
        }
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            GotPCave = downed.Contains("Got Prism Cave");
        }
        public override void TileCountsAvailable(int[] tileCounts)
        {
            prismCave = tileCounts[mod.TileType("PrismOre")];
            prismCave = tileCounts[mod.TileType("PrismGrit")];
            prismCave = tileCounts[mod.TileType("PrismSoil")];

        }
    }
}
