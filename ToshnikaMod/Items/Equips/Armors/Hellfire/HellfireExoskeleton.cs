using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;

namespace ToshnikaMod.Items.Equips.Armors.Hellfire
{
    [AutoloadEquip(EquipType.Body)]
    public class HellfireExoskeleton : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Throwing speed and velocity");
        }


        public override void SetDefaults()
        {
            item.value = 10000;
            item.rare = 5;
            item.width = 22;
            item.height = 12;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity *= 1.2f;
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.HFSkeleton = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {

            return head.type == mod.ItemType("HellfireMask") && legs.type == mod.ItemType("HellfireBoots");

        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You leave flames while moving";
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.HFSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.FossilShirt);
            recipe.AddIngredient(ItemID.NecroBreastplate);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.LivingFireBlock, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}