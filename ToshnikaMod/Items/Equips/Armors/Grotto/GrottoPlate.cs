using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;

namespace ToshnikaMod.Items.Equips.Armors.Grotto
{
    [AutoloadEquip(EquipType.Body)]
    public class GrottoPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+5% Endurance\nYou release crystal shards on being hit");
        }


        public override void SetDefaults()
        {

            item.value = 10000;
            item.rare = 5;
            item.width = 22;
            item.height = 12;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.05f;
            var modPlayer = player.GetModPlayer<ToshnikaPlayer>();
            modPlayer.grottoPlate = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {

            return head.type == mod.ItemType("GrottoHelm") && legs.type == mod.ItemType("GrottoGreaves");

        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Improves the dash power of the crystal orb, and reduces the duration and effects of shattered crystal";
            var modPlayer = player.GetModPlayer<CDashPlayer>();
            modPlayer.grottoSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.CrystalShard, 16);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(mod.ItemType("MotherOfPearl"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}