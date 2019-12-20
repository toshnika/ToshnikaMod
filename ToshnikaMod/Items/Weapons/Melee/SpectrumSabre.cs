using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Items.Weapons.Melee
{
    public class SpectrumSabre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Stacks to 99\nHas a 20% chance to shatter on hitting an enemy");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.damage = 64;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 0;
            item.rare = 5;
            item.shootSpeed = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(5))
            {
                item.stack--;
                Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: 3, SpeedY: 3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: 3, SpeedY: -3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: -3, SpeedY: 3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: -3, SpeedY: -3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
            }

        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}