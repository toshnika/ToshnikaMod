using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.NPCs
{
    public class GNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (!ToshnikaWorld.GotPCave) {
                if (npc.type == NPCID.SkeletronPrime)
                {
                    ToshnikaWorldGen.GenPrismCave();
                    ToshnikaWorld.GotPCave = true;
                    Main.NewText("The Caves Crackle With The Wide Spectrum", 20, 200, 200);
                }
                if (npc.type == NPCID.Spazmatism)
                {
                    ToshnikaWorldGen.GenPrismCave();
                    ToshnikaWorld.GotPCave = true;
                    Main.NewText("The Caves Crackle With The Wide Spectrum", 20, 200, 200);

                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    ToshnikaWorldGen.GenPrismCave();
                    ToshnikaWorld.GotPCave = true;
                    Main.NewText("The Caves Crackle With The Wide Spectrum", 20, 200, 200);

                }
            }
        }
    }
}