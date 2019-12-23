using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ToshnikaMod.Items.Tools
{
    public class PrismPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                Tooltip.SetDefault("Can mine chlorophyte");

            }
            else
            {
                Tooltip.SetDefault("Upgrades after defeating mech bosses");
            }
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                item.pick = 205;
            }
            else
            {
                item.pick = 190;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"),28);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}