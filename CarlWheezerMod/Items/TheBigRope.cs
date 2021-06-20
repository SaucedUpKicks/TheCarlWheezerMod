using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CarlWheezerMod.Items
{
	public class TheBigRope : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Big Rope");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
			item.damage = 800;
			item.melee = true;
			item.width = 62;
			item.height = 62;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 1;
			item.scale = 8f;
			item.knockBack = 8;
			item.value = 689999;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Rope, 420);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}