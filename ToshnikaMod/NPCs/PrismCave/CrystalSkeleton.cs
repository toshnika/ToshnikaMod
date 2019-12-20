using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.NPCs.PrismCave
{
    public class CrystalSkeleton : ModNPC
    {

        public override void SetStaticDefaults()
        {
                    Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Skeleton];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 100;
            npc.defense = 6;
            npc.lifeMax = 600;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.3f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (spawnInfo.player.GetModPlayer<ToshnikaPlayer>().PrismCave) 
            {
                return 100f;
            }
            return 0f;
        }
        public override void NPCLoot()
        {
            if (Main.rand.NextBool(2))
            {
                Item.NewItem(npc.getRect(), mod.ItemType("SpectrumPrism"));
            }
            Item.NewItem(npc.getRect(), ItemID.CrystalShard);
            if (Main.rand.NextBool(2))
            {
                Item.NewItem(npc.getRect(), ItemID.CrystalShard);
            }
        }
    }
}