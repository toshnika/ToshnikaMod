using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Misc
{

    public class IcyArms : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons the Ice Master");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 2;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = false;

        }


        public override bool CanUseItem(Player player)
        {

            return !NPC.AnyNPCs(mod.NPCType("IceMaster"));
            return Main.hardMode = true;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("IceMaster"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddIngredient(ItemID.IceBlade, 2);
            recipe.AddIngredient(ItemID.IceBlock, 500);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddIngredient(ItemID.IceBlade,2);
            recipe.AddIngredient(ItemID.IceBlock,500);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}