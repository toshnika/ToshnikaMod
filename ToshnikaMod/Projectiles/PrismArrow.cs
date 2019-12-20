using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Projectiles
{
    public class PrismArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 900;
            projectile.light = 0.35f;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.WoodenArrowFriendly;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: 3, SpeedY: 3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
            Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: 3, SpeedY: 3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
            Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: 3, SpeedY: 3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
            Projectile.NewProjectile(target.Center.X, target.Center.Y, SpeedX: 3, SpeedY: 3, Type: mod.ProjectileType("PrismBit"), Damage: damage / 3, KnockBack: 1f, Main.myPlayer);
        }
    }
}
