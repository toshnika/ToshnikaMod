using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ToshnikaMod.Items.Weapons.Summon
{
    public class PrismStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a powerful prism\nThe prism shoots light bolts that ignore defense and immunity frames");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.mana = 10;
            item.damage = 8;
            item.shoot = mod.ProjectileType("PrismSentry");
            item.shootSpeed = 0;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.knockBack = 0.2f;
            item.rare = 3;
            item.UseSound = SoundID.Item44;
            item.sentry = true;
            item.noMelee = true;
            item.autoReuse = false;
            item.summon = true;
            item.value = Item.buyPrice(0, 10, 0, 0);

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SpectrumPrism"), 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}