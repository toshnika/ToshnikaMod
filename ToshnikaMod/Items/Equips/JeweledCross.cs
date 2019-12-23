using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Equips
{
    [AutoloadEquip(EquipType.Neck)]
    public class JeweledCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Greatly boosts immunity frames\nStar cloak effect");
        }

        public override void SetDefaults()
        {
            item.defense = 4;
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 6;
            item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.starCloak = true;
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.jeweledCross = true;
        }
        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.ChlorophyteOre);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}