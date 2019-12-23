using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips.Armors.Grotto
{
    [AutoloadEquip(EquipType.Head)]
    public class GrottoHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+8% Damage and crit chance\nProvides a small chance to heal a portion of the lost health on being damaged");
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage *= 1.08f;
            player.rangedDamage *= 1.08f;
            player.magicDamage *= 1.08f;
            player.minionDamage *= 1.08f;
            player.thrownDamage *= 1.08f;
            player.thrownCrit += 8;
            player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;

            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.grottoHelm = true;
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 5;
            item.defense = 10;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.CrystalShard, 12);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(mod.ItemType("MotherOfPearl"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}