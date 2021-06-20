using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CarlWheezerMod.Items
{
	public class RawCoal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raw Coal");
			Tooltip.SetDefault("Grants unlimited flight\n+3600 max life\nMassively increases life regen");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax += 999999;
			player.statLifeMax2 += 3600;
			player.lifeRegen += 100;
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = 420000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 3);
			recipe.AddIngredient(ItemID.Bunny, 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
