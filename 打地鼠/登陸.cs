using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace 打地鼠
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e) { }


        private void button1_Click(object sender, EventArgs e)
        {

            // IsNullOrEmpty()    判断字符串是否为空的方法
            if (String.IsNullOrEmpty(textBox1.Text))        //如果字符串为空
            {
                MessageBox.Show("帳號不能空");          //弹出窗口
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("密码不能为空");

            }
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {          //如果字符串不为空
                if (textBox1.Text == "123456" && textBox2.Text == "123456")
                {
                    MessageBox.Show("成功");
                    Form2 digit = new Form2();
                    digit.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登录失败");

                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)          //重置
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // IsNullOrEmpty()    判断字符串是否为空的方法
            if (String.IsNullOrEmpty(textBox1.Text))        //如果字符串为空
            {
                MessageBox.Show("帳號不能空");          //弹出窗口
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("密码不能为空");

            }
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {          //如果字符串不为空
                if (textBox1.Text == "123456" && textBox2.Text == "123456")
                {
                    MessageBox.Show("成功,進入打地鼠");
                    Form1 digit3 = new Form1();
                    digit3.Show();
                    this.Hide();
                }
                //如果字符串不为空
                else if (textBox1.Text == "123" && textBox2.Text == "123")
                {
                    MessageBox.Show("成功,進入神奇寶貝");
                    pokemon_game.Form1 digit2 = new pokemon_game.Form1();
                    digit2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登录失败");

                }
            }
        }
    }
}
