using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Thrown
{
    public class PrismGauntlet : ModItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Throws prism daggers with great power");
        }

        public override void SetDefaults()
        {



            item.thrown = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 12;
            item.useAnimation = 12;
            item.shoot = 1;
            item.useAmmo = mod.ItemType("CrystallineKnife");
            item.shootSpeed = 3f;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.damage = 8;
            item.knockBack = 0.2f;
            item.rare = 7;
            item.noMelee = true;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }



    }
}