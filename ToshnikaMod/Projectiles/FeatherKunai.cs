using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToshnikaMod.Projectiles
{
    public class FeatherKunai : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feather Kunai");

        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
            aiType = ProjectileID.ChlorophyteBullet;
            projectile.width = 16;
            projectile.height = 16;
            projectile.thrown = true;

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            return base.PreDraw(spriteBatch, lightColor);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            base.PostDraw(spriteBatch, lightColor);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Blue;
        }


    }
}