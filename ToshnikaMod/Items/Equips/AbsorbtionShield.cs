using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ToshnikaMod.Items.Equips
{
    public class AbsorbtionShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces immunity frames by 70%\n+50% Endurance\nRemoves any and all knockback immunity");
        }

        public override void SetDefaults()
        {
            item.defense = 10;
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 6;
            item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.5f;
            player.noKnockback = false;
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.absorbtionShield = true;
        }
        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.AdamantiteBar, 8);
            recipe.AddIngredient(ItemID.Deathweed, 4);
            recipe.AddIngredient(mod.ItemType("MagicShard"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.TitaniumBar, 8);
            recipe.AddIngredient(ItemID.Deathweed, 4);
            recipe.AddIngredient(mod.ItemType("MagicShard"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}