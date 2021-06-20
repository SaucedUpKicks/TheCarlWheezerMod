using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CarlWheezerMod.Items
{
	public class TrueCactusSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Cactus Sword");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 700;
			item.noMelee = true;
			item.magic = true;
			item.width = 74;
			item.height = 74;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 689998;
			item.rare = 10;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.mana = 20;
			item.shootSpeed = 10;
			item.shoot = mod.ProjectileType("Cactus");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 5;
			float rotation = MathHelper.ToRadians(10);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1.2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CactusSword, 6);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 9);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}