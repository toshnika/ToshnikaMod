using Terraria;
using Terraria.ModLoader;
using ToshnikaMod.Items.Equips;

namespace ToshnikaMod.Buffs
{
    public class TruePStoneBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("True Philosopher's Stone");
            Description.SetDefault("Reduces heal potion cooldown, increases life regeneration");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.pStone = true;
            player.lifeRegen += 2;
        }
    }
}