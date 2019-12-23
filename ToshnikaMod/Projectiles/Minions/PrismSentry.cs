using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.World.Generation;
namespace ToshnikaMod.Projectiles.Minions
{
    public class PrismSentry : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Sentry");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {

            projectile.sentry = true;
            projectile.width = 40;
            projectile.height = 40;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.knockBack = 10f;
            projectile.penetrate = -1;
            projectile.light = 0.6f;
            projectile.tileCollide = false;
            projectile.sentry = true;
            projectile.minion = true;
            projectile.usesLocalNPCImmunity = true;

        }
        NPC target;

        float maxDistance = 1000f;
        int timer;


        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            player.UpdateMaxTurrets();
            timer++;

            if (ToshnikaMethods.ClosestNPC(ref target, maxDistance, projectile.Center, false, player.MinionAttackTargetNPC))
            {

                projectile.rotation = (target.Center - projectile.Center).ToRotation();
                if (timer % 7 == 0 && player.whoAmI == Main.myPlayer)
                { 
                Projectile s = Main.projectile[Projectile.NewProjectile(projectile.Center, ToshnikaMethods.PolarVector(Main.rand.NextFloat(7, 9), projectile.rotation - (float)Math.PI / 8 + Main.rand.NextFloat((float)Math.PI / 4)), mod.ProjectileType("PrismSentryProj"), projectile.damage, projectile.knockBack, player.whoAmI)];

                }


            }

        }


    }
}
