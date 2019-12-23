using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items
{
    public class TruePhilosophersStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Philosopher's Stone");
            Tooltip.SetDefault("Reduces potion cooldown when placed(To all nearby players) and worn\nIncreases max life when worn\nIncreases regen to nearby players while placed");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.consumable = true;
            item.createTile = mod.TileType("TruePStone");
            item.useStyle = 1;
            item.useAnimation = 18;
            item.useTime = 16;
            item.useTurn = true;
            item.autoReuse = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.buyPrice(0, 75, 0, 0);
            item.rare = 6;
            item.accessory = true;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.pStone = true;
            player.statLifeMax2 += 25;
        }

        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PhilosophersStone);
            recipe.AddIngredient(ItemID.Ectoplasm, 6);
            recipe.AddIngredient(ItemID.LifeCrystal, 8);
            recipe.AddIngredient(mod.ItemType("MotherOfPearl"), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}