using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_5_1
{
    public partial class Form1 : Form
    {

        List<Control> g=new List<Control>();
        int get=0, loss=0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;  
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            score.Visible = true;
            board.Visible = true;

            start_btn.Visible = false;

            timer1.Enabled = true;
            timer2.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            PictureBox pictureBox = new PictureBox();
            int type = random.Next(0, 2);

            if (type == 1)
            {
                pictureBox.Image = Image.FromFile(@"..\..\pic\g1.png");

            }
            else
            {
                pictureBox.Image = Image.FromFile(@"..\..\pic\g2.png");
            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(30, 30);
            pictureBox.Location = new Point(random.Next(30+pictureBox.Width, this.Width-pictureBox.Width-30), 0);
            this.Controls.Add(pictureBox);
            g.Add(pictureBox);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            List<Control> controlsToRemove = new List<Control>();
            score.Text = get + "/" + loss;
            foreach (Control control in g)
            {
                control.Top+=5;
                if (control.Location.X+control.Width>= board.Location.X &&
                    board.Location.X + board.Width >= control.Location.X &&
                    control.Location.Y + control.Height >= board.Location.Y &&
                    board.Location.Y + board.Height >= control.Location.Y)
                        
                {
                    get += 1;
                    this.Controls.Remove(control);
                    control.Dispose();
                    controlsToRemove.Add(control);
                }
                else if(control.Bottom ==250 )
                {
                    loss += 1;
                    this.Controls.Remove(control);
                    control.Dispose();
                    controlsToRemove.Add(control);
                }
            }

            foreach (Control control in controlsToRemove)
            {
                this.Controls.Remove(control);
                control.Dispose();
                g.Remove(control);  
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int s;

            if (e.Shift == true)
            {
                s = 10;
            }
            else
            {
                s = 2;
            }

            switch (e.KeyCode) {
                case Keys.Left:
                case Keys.A:
                    if (board.Left <= 0)
                    {
                        board.Left = 0;
                    }
                    else
                    {
                        board.Left -= s;
                    }
                    break;
                case Keys.Right:
                case Keys.D:
                    if (board.Left >= this.Width - board.Width-20)
                    {
                        board.Left=this.Width-board.Width - 20;
                    }
                    else
                    {
                        board.Left += s;
                    }

                    break;
            }
        }
    }
}
