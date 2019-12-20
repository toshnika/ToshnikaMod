using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Ammo
{
    public class PrismaticShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots a powerful, high-velocity piercing round");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;             
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 5;
            item.shoot = mod.ProjectileType("PrismaticShot");   
            item.shootSpeed = 35f;                  
            item.ammo = AmmoID.Bullet;              
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 33);
            recipe.AddRecipe();
        }
    }
}