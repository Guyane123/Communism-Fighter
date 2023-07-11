using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SpaceFighter
{
 
    public partial class Form1 : Form
    {
        WindowsMediaPlayer backgroundMusic;
        WindowsMediaPlayer[] shoot;
        WindowsMediaPlayer boom;

        PictureBox[] ennemiesBullets;
        int ennemiesBulletSpeed;

        PictureBox[] ennemies;
        int ennemieSpeed;

        PictureBox[] stars;
        int backgroundspeed;
        Random rnd;

        int PlayerSpeed;

        PictureBox[] bullets;
        int bulletsspeed;

        int difficulty;
        int level;
        int score;
        bool pause;
        bool gameIsOver;
        
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesactivateMenu();
            //BackGround
            difficulty = 9;
            level = 1;
            score = 0;
            pause = false;
            gameIsOver = false;
            backgroundspeed = 4;
            stars = new PictureBox[10];
            rnd = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }
                else
                {
                    stars[i].Size = new Size(4, 4);
                    stars[i].BackColor = Color.Black;
                }
                this.Controls.Add(stars[i]);
            }


            //Player
            PlayerSpeed = 4;

            //Ennemies
            Image ennemie = Image.FromFile(@"assets/E1.png");
            ennemies = new PictureBox[10];
            ennemieSpeed = 4;

            for (int i = 0; i < ennemies.Length; i++)
            {
                ennemies[i] = new PictureBox();
                ennemies[i].Size = new Size(60, 60);
                ennemies[i].Visible = false;
                ennemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                ennemies[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(ennemies[i]);
                ennemies[i].Location = new Point((i + 1) * 50, -50);
                ennemies[i].Image = ennemie;
            }

            //Bullet

            bulletsspeed = 20;
            bullets = new PictureBox[3];
            Image bullet = Image.FromFile(@"assets\bullet.png");

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].Visible = true;
                bullets[i].BorderStyle = BorderStyle.None;
                bullets[i].Image = bullet;
                bullets[i].Size = new Size(20, 20);
                bullets[i].SizeMode = PictureBoxSizeMode.Zoom;

                this.Controls.Add(bullets[i]);
            }

            ennemiesBulletSpeed = 20;
            ennemiesBullets = new PictureBox[5];
            Image ennemiesBullet = Image.FromFile(@"assets\NewEnnemiesBullet.png");
            int x = rnd.Next(0, 10);
            for(int i = 0; i < ennemiesBullets.Length; i++)
            {
                ennemiesBullets[i] = new PictureBox();
                ennemiesBullets[i].Image = ennemiesBullet;
                ennemiesBullets[i].BorderStyle= BorderStyle.None;
                ennemiesBullets[i].Size= new Size(20, 20);
                ennemiesBullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                ennemiesBullets[i].Location = new Point(ennemies[x].Location.X, ennemies[x].Location.Y - 20);

                this.Controls.Add(ennemiesBullets[i]);
            }

            //Songs

            backgroundMusic = new WindowsMediaPlayer();
            backgroundMusic.URL = @"songs\Main.mp3";
            shoot = new WindowsMediaPlayer[3];
            boom = new WindowsMediaPlayer();
            boom.URL = @"songs\boom.mp3";
            boom.controls.stop();
            for (int i = 0; i < shoot.Length; i++)
            {
                shoot[i] = new WindowsMediaPlayer();

                if(i == 0)
                {
                    shoot[0].URL = @"songs\M1.mp3";
                }else if(i == 1)
                {
                    shoot[1].URL = @"songs\M2.mp3";
                }
                else
                {
                    shoot[2].URL = @"songs\M3.mp3";
                }
                shoot[i].controls.stop();
            }



            backgroundMusic.settings.setMode("loop", true);
            backgroundMusic.settings.volume = 5;




            backgroundMusic.controls.play();
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed;
                if (stars[i].Top > this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }

            }
            for(int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;
                if (stars[i].Top > this.Height) 
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

        }

        private void MoveDownTimer_Tick(object sender, EventArgs e)
        {
            if(Player.Top < 400)
            {
                Player.Top += PlayerSpeed;
            }
        }

        private void MoveUpTimer_Tick(object sender, EventArgs e)
        {
            if(Player.Top > 10)
            {
                Player.Top -= PlayerSpeed;
            }
        }

        private void MoveLeftTimer_Tick(object sender, EventArgs e)
        {
            if(Player.Left > 10)
            {
                Player.Left -= PlayerSpeed;
            }
        }

        private void MoveRightTimer_Tick(object sender, EventArgs e)
        {
            if(Player.Left < 500)
            {
                Player.Left += PlayerSpeed;
            }
        }

        private void Communism_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Up) { MoveUpTimer.Start(); }
                else if (e.KeyCode == Keys.Down) { MoveDownTimer.Start(); }
                else if (e.KeyCode == Keys.Left) { MoveLeftTimer.Start(); }
                else if (e.KeyCode == Keys.Right) { MoveRightTimer.Start(); }
            }


        }

        private void Communism_KeyUp(object sender, KeyEventArgs e)
        {
            MoveRightTimer.Stop();
            MoveLeftTimer.Stop();
            MoveDownTimer.Stop();
            MoveUpTimer.Stop();

            if(e.KeyCode == Keys.Space)
            {
                if(!gameIsOver)
                {
                    if (pause)
                    {
                        startTimers();
                        label1.Visible = false;
                        button1.Visible = false;
                        button2.Visible = false;
                        backgroundMusic.controls.play();
                        pause = false;
                    }
                    else
                    {
                        stopTimers();
                        label1.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                        button1.Text = "Continue";
                        label1.Text = "Communism Fighter";
                        pause = true;
                    }
                }
            }

        }
        private void DesactivateMenu()
        {
            startTimers();
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            pause = false;
        }

        private void MoveBulletTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Top > 0)
                {
                    bullets[i].Visible = true;
                    bullets[i].Top -= bulletsspeed;

                    Collision();
                }else
                {
                    bullets[i].Visible = false;
                    bullets[i].Location = new Point(Player.Location.X + 40, Player.Location.Y - i * 30);
                }
            }
        }

        private void MoveEnnemieTimer_Tick(object sender, EventArgs e)
        {
            MoveEnnemie(ennemies, ennemieSpeed);
        }

        private void MoveEnnemie(PictureBox[] array, int speed)
        {
            for(int i = 0; i < array.Length;i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top >this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void Collision()
        {
            for(int i = 0; i < ennemies.Length;i++)
            {
                if (bullets[0].Bounds.IntersectsWith(ennemies[i].Bounds) || bullets[1].Bounds.IntersectsWith(ennemies[i].Bounds) || bullets[2].Bounds.IntersectsWith(ennemies[i].Bounds))
                {
                    shoot[0].controls.play();
                    if (rnd.Next(3) == 0)
                    {
                        shoot[0].controls.play();
                    }else if(rnd.Next(3) == 1)
                    {
                        shoot[1].controls.play();
                    }else
                    {
                        shoot[2].controls.play();
                    }
                    ennemies[i].Location = new Point((i + 1) * 50, -200);
                }
                if (Player.Bounds.IntersectsWith((ennemies[i].Bounds)))
                {
                    gameOver();
                }
            }
        }
        private void CollisionWithEnnemiesBullets()
        {
            for(int i = 0; i < ennemiesBullets.Length; i++)
            {
                if (ennemiesBullets[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    gameOver();
                }
            }
        }
        private void gameOver()
        {
            gameIsOver = true;
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button1.Text = "Retry";
            label1.Text = "Game Over !";
            pause = true;
            Player.Visible = false;
            boom.settings.volume = 20;
            boom.controls.play();
            boom.settings.setMode("loop", false);
            backgroundMusic.controls.stop();
            stopTimers();
        }
        private void stopTimers()
        {
            MoveBulletTimer.Stop();
            MoveEnnemieTimer.Stop();
            MoveBgTimer.Stop();
            /*MoveDownTimer.Stop();
            MoveLeftTimer.Stop();
            MoveRightTimer.Stop();
            MoveUpTimer.Stop();*/
            MoveBulletEnnemieTimer.Stop();
        }
        private void startTimers()
        {
            MoveBulletTimer.Start();
            MoveEnnemieTimer.Start();
            MoveBgTimer.Start();
            /*MoveDownTimer.Start();
            MoveLeftTimer.Start();
            MoveRightTimer.Start();
            MoveUpTimer.Start();*/
            MoveBulletEnnemieTimer.Start();
        }
        private void MoveBulletEnnemieTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ennemiesBullets.Length; i++)
            {
                if (ennemiesBullets[i].Top < this.Height)
                {
                    ennemiesBullets[i].Visible = true;
                    ennemiesBullets[i].Top += ennemiesBulletSpeed;

                    CollisionWithEnnemiesBullets();
                }
                else
                {
                    ennemiesBullets[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    ennemiesBullets[i].Location = new Point(ennemies[x].Location.X, ennemies[x].Location.Y);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(gameIsOver)
            {
                this.Controls.Clear();
                InitializeComponent();
                Communism_KeyDown(null, null);
                Form1_Load(e, e);
            }else
            {
                DesactivateMenu();
            }
            gameIsOver = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
