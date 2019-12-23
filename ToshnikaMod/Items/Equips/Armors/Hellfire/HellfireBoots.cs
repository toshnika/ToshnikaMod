using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips.Armors.Hellfire
{
    [AutoloadEquip(EquipType.Legs)]
    public class HellfireBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces thrown item usage rate \n+6% Movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 4;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.06f;
            player.thrownCost33 = true;
        }

        public override bool DrawLegs()
        {
            return base.DrawLegs();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.FossilPants);
            recipe.AddIngredient(ItemID.NecroGreaves);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(ItemID.LivingFireBlock, 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}