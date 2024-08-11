using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

using WMPLib;
using System.Messaging;

namespace 打地鼠
{
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {

            InitializeComponent();
        }

        



        Random r = new Random();
        int time;
        int count = 0;
        int flag = 0;
        int ti = 1;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        SoundPlayer boom = new SoundPlayer("poke.wav");
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            timerchushu.Enabled = true;
            time = 30;
            timerjishi.Enabled = true;
            labeltime.Text = "遊戲時間：" + time;
            
        } 
        private void Randomchushu()
        {
            int num = r.Next(1, 9);
            switch (num)
            {
                case 1:
                    Invisible();
                    pictureBox1.Visible = true;
                    break;
                case 2:
                    Invisible();
                    pictureBox2.Visible = true;
                    break;
                case 3:
                    Invisible();
                    pictureBox3.Visible = true;
                    break;
                case 4:
                    Invisible();
                    pictureBox4.Visible = true;
                    break;
                case 5:
                    Invisible();
                    pictureBox5.Visible = true;
                    break;
                case 6:
                    Invisible();
                    pictureBox6.Visible = true;
                    break;
                case 7:
                    Invisible();
                    pictureBox7.Visible = true;
                    break;
                case 8:
                    Invisible();
                    pictureBox8.Visible = true;
                    break;
                case 9:
                    Invisible();
                    pictureBox9.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void Invisible()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType()==typeof(PictureBox))
                {
                    PictureBox a = pictureBox1;
                    a.Visible = false;
                    a.Image = imageList1.Images[0];

                    PictureBox p =  pictureBox2 ;
                    p.Visible = false;
                    p.Image = imageList1.Images[0];

                    PictureBox b = pictureBox3;
                    b.Visible = false;
                    b.Image = imageList1.Images[0];

                    PictureBox c = pictureBox4;
                    c.Visible = false;
                    c.Image = imageList1.Images[0];

                    PictureBox d = pictureBox5;
                    d.Visible = false;
                    d.Image = imageList1.Images[0];

                    PictureBox e = pictureBox6;
                    e.Visible = false;
                    e.Image = imageList1.Images[0];

                    PictureBox f = pictureBox7;
                    f.Visible = false;
                    f.Image = imageList1.Images[0];

                    PictureBox g = pictureBox8;
                    g.Visible = false;
                    g.Image = imageList1.Images[0];
                    PictureBox h = pictureBox9;
                    h.Visible = false;
                    h.Image = imageList1.Images[0];
                    flag = 0;
                }
            }
        }

        private void timerchushu_Tick(object sender, EventArgs e)
        {
            Randomchushu();
        }

        private void timerjishi_Tick(object sender, EventArgs e)
        {
            if(time==0)
            { string word;
                timerchushu.Enabled = false;
                timerjishi.Enabled = false;
                MessageBox.Show("遊戲結束");
                word=(count+ "   第" + ti + "次 ");
                listBox1.Items.Add(word);
               button1.Visible = true;
                button1.Text = "再来一次";
                count = 0;
               
            }
            else
            {
                time--;
                labeltime.Text = "遊戲時間：" + time + "秒";
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pd = (PictureBox)sender;
            pd.Image = imageList1.Images[1];
            boom.Play();
            if (flag==0)
            {
                flag = 1;

                count++;
                labelscore.Text = "遊戲得分：" + count;
            }
        }

        private void labeltime_Click(object sender, EventArgs e)
        {

        }

        private void 简单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 中等ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 困难ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 简单ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            简单ToolStripMenuItem.Checked = true;
            中等ToolStripMenuItem.Checked = false;
            困难ToolStripMenuItem.Checked = false;
            timerjishi.Interval = 1200;
            timerchushu.Interval = 2400;
        }

        private void 中等ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            简单ToolStripMenuItem.Checked = false;
            中等ToolStripMenuItem.Checked = true;
            困难ToolStripMenuItem.Checked = false;
            timerjishi.Interval = 1000;
            timerchushu.Interval = 2000;
        }

        private void 困难ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            简单ToolStripMenuItem.Checked = false;
            中等ToolStripMenuItem.Checked = false;
            困难ToolStripMenuItem.Checked = true;
            timerjishi.Interval = 750;
            timerchushu.Interval = 1500;
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wplayer.URL = "01.mp3";
            wplayer.controls.play();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        
        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
