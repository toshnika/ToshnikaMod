using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips.Armors.Hellfire
{
    [AutoloadEquip(EquipType.Head)]
    public class HellfireMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Throwing damage and crit");
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage *= 1.2f;
            player.thrownCrit += 20;
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 4;
            item.defense = 7;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.FossilHelm);
            recipe.AddIngredient(ItemID.NecroHelmet);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.LivingFireBlock, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}