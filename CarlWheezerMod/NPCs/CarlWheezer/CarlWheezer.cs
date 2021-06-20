using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.Utilities;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Security;

namespace CarlWheezerMod.NPCs.CarlWheezer
{
    [AutoloadBossHead]
    public class CarlWheezer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carl Wheezer");
        }

        public override void SetDefaults()
        {
            npc.width = 1358;
            npc.height = 921;
            npc.value = 999000;
            npc.lifeMax = 3000000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.npcSlots = 15f;
            npc.scale = 0.5f;
            npc.buffImmune[31] = true;
            npc.buffImmune[36] = true;
            npc.buffImmune[144] = true;
            music = MusicID.Boss1;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath10;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.defense = 69;
            npc.direction = -1;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override bool PreAI()
        {
            Lighting.AddLight(new Vector2(npc.Center.X, npc.Center.Y - 15), 255 * 0.005f, 255 * 0.005f, 230 * 0.005f);
            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
            if (player.dead)
            {
                npc.active = false;
            }
            return true;
        }


        private float EyeRotation;
        private float PhantRotation;
        private int BeamTimer;
        private int LaserTimer;
        private int PortalTimer;
        public override void AI()
        {
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.TargetClosest(true);

            npc.netUpdate = true;
            Player P = Main.player[npc.target];

            if (Main.expertMode)
            {
                npc.ai[1]++;
            }

            if (npc.ai[1] == 1)
            {
                npc.lifeMax = 4200000;
                npc.life = 4200000;
            }

                if (Main.player[npc.target].position.X < npc.position.X + 900)
                {
                    if (npc.velocity.X > -15) npc.velocity.X -= 1.5f;
                }

                if (Main.player[npc.target].position.X > npc.position.X + 900)
                {
                    if (npc.velocity.X < 15) npc.velocity.X += 1.5f;
                }

                if (Main.player[npc.target].position.Y - 200 < npc.position.Y)
                {
                    if (npc.velocity.Y < 0)
                    {
                        if (npc.velocity.Y > -4) npc.velocity.Y -= 1f;
                    }
                    else npc.velocity.Y -= 0.5f;
                }

                if (Main.player[npc.target].position.Y - 200 > npc.position.Y)
            {
                if (npc.velocity.Y > 0)
                {
                    if (npc.velocity.Y < 4) npc.velocity.Y += 1f;
                }
                else npc.velocity.Y += 0.5f;
            }



            npc.ai[0]++;

            #region SicklePhase
            if (npc.ai[0] >= 120)
            {
                if (npc.ai[0] <= 240)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(-10);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(-5);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(5);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(10);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                }
            }
            #endregion

            #region IchorPhase
            if (npc.ai[0] >= 300)
            {
                if (npc.ai[0] <= 360)
                {
                    float Speed = 15f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 150;
                    int type = 288;
                    float rotation = MathHelper.ToRadians(50);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 21);
                }
                if (npc.ai[0] <= 360)
                {
                    float Speed = 15f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 150;
                    int type = 288;
                    float rotation = MathHelper.ToRadians(130);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
                if (npc.ai[0] <= 360)
                {
                    float Speed = 15f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 150;
                    int type = 288;
                    float rotation = MathHelper.ToRadians(90);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
            }
            #endregion

            #region TridentPhase
                    if (npc.ai[0] >= 400)
            {
                if (npc.ai[0] <= 460)
                {
                    float Speed = 8f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 115;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }

                if (npc.ai[0] <= 460)
                {
                    float Speed = 8f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 115;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(10);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }

                if (npc.ai[0] <= 460)
                {
                    float Speed = 8f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 115;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) - MathHelper.ToRadians(10);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
            }
            #endregion

            #region BeamPhase
            if (npc.ai[0] >= 480)
            {
                BeamTimer++;
                if (BeamTimer >= 5)
                {
                    if (npc.ai[0] <= 540)
                    {
                        float Speed = 8f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 150;
                        int type = 438;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                    }

                    if (npc.ai[0] <= 540)
                    {
                        float Speed = 12f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 259;
                        float rotation = MathHelper.ToRadians(315);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                    }

                    if (npc.ai[0] <= 540)
                    {
                        float Speed = 12f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 259;
                        float rotation = MathHelper.ToRadians(135);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    }

                    if (npc.ai[0] <= 540)
                    {
                        float Speed = 12f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 259;
                        float rotation = MathHelper.ToRadians(225);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    }

                    if (npc.ai[0] <= 540)
                    {
                        float Speed = 12f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 259;
                        float rotation = MathHelper.ToRadians(45);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    }
                    BeamTimer = 0;
                }
            }
            #endregion

            #region ScythePhase


            if (npc.ai[0] >= 600)
            {
                if (npc.ai[0] <= 720)
                {
                    LaserTimer++;
                    if (LaserTimer >= 15)
                    {
                        float Speed = 8f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 150;
                        int type = 83;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                        LaserTimer = 0;
                    }
                }
            }

            #region I
            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(0);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(45);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(90);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(135);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(225);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(270);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 600)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(315);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }
            #endregion

            #region II
            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(0);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(45);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(90);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(135);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(225);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(270);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 660)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(315);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }
            #endregion

            #region III
            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(0);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(45);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(90);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(135);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(225);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(270);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }

            if (npc.ai[0] == 720)
            {
                float Speed = 3f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 329;
                float rotation = MathHelper.ToRadians(315);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 71);
            }
            #endregion

            #endregion

            #region SpiralPhase

            if (npc.ai[0] == 800)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
            }

            if (npc.ai[0] >= 800)
            {
                if (npc.ai[0] <= 1210)
                {
                    npc.velocity.X = 0;
                    npc.velocity.Y = 0;
                }
            }

            if (npc.ai[0] >= 860)
            {
                if (npc.ai[0] <= 1180)
                {
                    EyeRotation += 0.5f;
                    float Speed = 2f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 150;
                    int type = 462;
                    float rotation = EyeRotation + MathHelper.ToRadians(0);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 125); 
                }
            }

            #endregion

            #region EyePhase

            if (npc.ai[0] >= 1320)
            {
                if (npc.ai[0] <= 1380)
                {
                    PhantRotation = (float)Main.rand.Next(-50, 50);
                    float Speed = 6f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 452;
                    float rotation = PhantRotation + (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 6);
                }
            }
            #endregion

            #region PortalPhase

            if (npc.ai[0] >= 1580)
            {
                if (npc.ai[0] <= 1640)
                {
                    PortalTimer++;
                    if (PortalTimer >= 20)
                    {
                        PhantRotation = (float)Main.rand.Next(-150, 150);
                        float Speed = 5f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 465;
                        float rotation = PhantRotation + (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 123);
                        PortalTimer = 0;
                    }
                }
            }
            #endregion

            #region WavePhase
            if (npc.ai[0] >= 1960)
            {
                if (npc.ai[0] <= 2080)
                {
                    PhantRotation = (float)Main.rand.Next(-150, 150);
                    float Speed = 3f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 348;
                    float rotation = PhantRotation + (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                }
            }
            #endregion

            if (npc.ai[0] >= 2200)
            {
                npc.ai[0] = 0;
            }
        }


        public override void NPCLoot()
        {
            Gore.NewGore(npc.position, npc.position, 73, 15f);
            Gore.NewGore(npc.position, npc.position, 74, 15f);
            Gore.NewGore(npc.position, npc.position, 75, 15f);
            Gore.NewGore(npc.position, npc.velocity, 73, 15f);
            Gore.NewGore(npc.position, npc.velocity, 74, 15f);
            Gore.NewGore(npc.position, npc.velocity, 75, 15f);
            Gore.NewGore(npc.position, npc.velocity, 73, 15f);
            Gore.NewGore(npc.position, npc.velocity, 74, 15f);
            Gore.NewGore(npc.position, npc.velocity, 75, 15f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
    }
}