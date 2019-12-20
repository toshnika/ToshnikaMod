using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.NPCs.PrismCave
{
    public class PrismaticSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            npc.width = 22;
            npc.height = 22;
            npc.damage = 100;
            npc.defense = 6;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.3f;
            npc.aiStyle = 1;
            aiType = NPCID.GreenSlime;
            animationType = NPCID.GreenSlime;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) //changes spawn rates must return a float
        {
            if (spawnInfo.player.GetModPlayer<ToshnikaPlayer>().PrismCave) 
            {
                return 120f;
            }
            return 0f;

        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, 2);
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(npc.getRect(), mod.ItemType("PrismOre"), 2 + Main.rand.Next(3));
            }
        }
    }
}