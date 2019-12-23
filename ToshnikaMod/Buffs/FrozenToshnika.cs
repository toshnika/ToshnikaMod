using Terraria;
using Terraria.ModLoader;
using ToshnikaMod.Items.Equips;

namespace ToshnikaMod.Buffs
{
    public class FrozenToshnika : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frozen");
            Description.SetDefault("Frozen");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss)
            {
                npc.velocity.X *= 0.85f;
                npc.velocity.Y *= 0.85f;
            }
            else
            {
                npc.velocity.X *= 0.08f;
                npc.velocity.Y *= 0.08f;
            }
        }
    }
}