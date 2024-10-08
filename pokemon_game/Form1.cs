﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace pokemon_game
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;
        int enemy3speed = 2;

        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            
            txtScore.Text = "Score: " + score;

            player.Top += jumpSpeed;

            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
            }

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {


                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;


                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }


                        }

                        x.BringToFront();

                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }


                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            
                            gameTimer.Stop();
                           
                            MessageBox.Show("you lose!");
                            isGameOver = true;
                           
                            txtScore.Text = "分數: " + score + Environment.NewLine + "You were killed in your journey!!";
                           
                        }
                    }

                }
            }


            horizontalPlatform.Left -= horizontalSpeed;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;

            if (verticalPlatform.Top < 195 || verticalPlatform.Top > 581)
            {
                verticalSpeed = -verticalSpeed;
            }
            enemyOne.Left -= enemyOneSpeed;
            if (   enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyTwo.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }
            

            

            enemyTwo.Left += enemyTwoSpeed;

            if (enemyTwo.Left < pictureBox2.Left || enemyTwo.Left + enemyTwo.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }
            enemy3.Left += enemy3speed;

            if (enemy3.Left < pictureBox3.Left || enemy3.Left + enemy3.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemy3speed = -enemy3speed;
            }


            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                
                gameTimer.Stop();
                
                MessageBox.Show("you lose!");
                isGameOver = true;
                
                txtScore.Text = "分數: " + score + Environment.NewLine + "你跌下去了!";
             
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && score == 26)
            {
                gameTimer.Stop();
                
                MessageBox.Show("you win!");
                isGameOver = true;
                txtScore.Text = "分數: " + score + Environment.NewLine + "恭喜破關!";
              
            }
            else
            {
                txtScore.Text = "分數: " + score + Environment.NewLine + "收集所有寶貝球吧";
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wplayer.URL = "poke.mp3";
            wplayer.controls.play();
        }

       
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            


        }

        private void RestartGame()
        {
           
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            txtScore.Text = "分數: " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }


            // reset the position of player, platform and enemies

            player.Left = 72;
            player.Top = 656;

            enemyTwo.Left = 471;
            enemyTwo.Left = 360;
            enemy3.Left = 250;
            horizontalPlatform.Left = 275;
            verticalPlatform.Top = 581;

            gameTimer.Start();


        }
    }
}
