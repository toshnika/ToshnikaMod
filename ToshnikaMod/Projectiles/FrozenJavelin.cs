using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Projectiles
{
    public class FrozenJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Javelin");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.boss)
            {
                target.AddBuff(mod.BuffType("FrozenToshnika"), 12);

            }
            else
            {
                target.AddBuff(mod.BuffType("FrozenToshnika"), 40);
            }
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.thrown = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 1800;
            projectile.light = 0.2f;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.WoodenArrowFriendly;
        }
    }
}
