using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CarlWheezerMod.Items
{
	public class DemonPorch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Porch");
			Tooltip.SetDefault("50% increase to all damage\nSets your defense to 0\nIncreases your maximum mana by 420");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.allDamage *= 1.5f;
			player.statDefense = 0;
			player.statManaMax2 += 420;
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = 469000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemonTorch, 7);
			recipe.AddIngredient(ItemID.DemonTorch, 3);
			recipe.AddIngredient(ItemID.DemonTorch, 5);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
