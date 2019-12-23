using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Equips.Armors.Grotto
{
    [AutoloadEquip(EquipType.Legs)]
    public class GrottoGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+6% Movement speed\nSlightly boosted flighttime");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 5;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.06f;
            if(player.wingTimeMax >= 20)
            {
                player.wingTimeMax += 10;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.CrystalShard, 14);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(mod.ItemType("MotherOfPearl"), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}