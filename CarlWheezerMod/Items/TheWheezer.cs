using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CarlWheezerMod.Items
{
	public class TheWheezer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Wheezer");
			Tooltip.SetDefault("69% chance to not consume ammo");
		}

		public override void SetDefaults() 
		{
			item.damage = 300;
			item.noMelee = true;
			item.ranged = true;
			item.width = 62;
			item.height = 38;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 5;
			item.knockBack = 8;
			item.value = 690000;
			item.rare = 10;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shootSpeed = 15;
			item.shoot = 242;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .69f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; i++)

			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HolyWater, 1);
			recipe.AddIngredient(ItemID.LunarBar, 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}