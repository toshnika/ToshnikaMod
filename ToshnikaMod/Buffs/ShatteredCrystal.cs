using Terraria;
using Terraria.ModLoader;
using ToshnikaMod.Items.Equips;

namespace ToshnikaMod.Buffs
{
    public class ShatteredCrystal : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shattered Crystal");
            Description.SetDefault("Your dash orb can't perform to the max");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            var modPlayer = player.GetModPlayer<CDashPlayer>();
            if (!modPlayer.grottoSet)
            {
                player.lifeRegen -= 1;
            }
        }
    }
}