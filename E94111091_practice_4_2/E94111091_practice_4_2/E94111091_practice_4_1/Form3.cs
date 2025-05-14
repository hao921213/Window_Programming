using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_4_1
{
    public partial class Form3 : Form
    {
        Form1 form;

        int picture=0;
        public Form3(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            picture1.SizeMode = PictureBoxSizeMode.Zoom;
            picture2.SizeMode = PictureBoxSizeMode.Zoom;
            picture3.SizeMode = PictureBoxSizeMode.Zoom;
            picture4.SizeMode = PictureBoxSizeMode.Zoom;
            picture5.SizeMode = PictureBoxSizeMode.Zoom;
            picture6.SizeMode = PictureBoxSizeMode.Zoom;

            picture1.Image = Image.FromFile(@"..\..\pic\0.png");
            picture2.Image = Image.FromFile(@"..\..\pic\1.png");
            picture3.Image = Image.FromFile(@"..\..\pic\2.png");
            picture4.Image = Image.FromFile(@"..\..\pic\3.png");
            picture5.Image = Image.FromFile(@"..\..\pic\4.png");
            picture6.Image = Image.FromFile(@"..\..\pic\5.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.form1.Show();
            if (checkBox1.Checked == true)
            {
                picture = 0;
            }
            else if(checkBox2.Checked == true)
            {
                picture = 1;
            }
            else if (checkBox3.Checked == true)
            {
                picture = 2;
            }
            else if (checkBox4.Checked == true)
            {
                picture = 3;
            }
            else if (checkBox5.Checked == true)
            {
                picture = 4;
            }
            else if (checkBox6.Checked == true)
            {
                picture = 5;
            }
            form.Getpicture(picture);
        }

        private void picture1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void picture2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void picture3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = true;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void picture4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = true;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void picture5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = true;
            checkBox6.Checked = false;
        }

        private void picture6_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = true;
        }
    }
}
