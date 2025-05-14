using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_4_1
{
    public partial class Form1 : Form
    {
        Form2 form;
        Form3 form3;
        int chang_color1 = 0;
        int chang_color2 = 0;

        int check = 0;

        int x1 = 300;
        int x2 = 20;
        int y = 10;

        Control[,] lbl_group = new Control[108,2];
        
        int lbl_index=0;
        int game = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i <= 7; i++)
            {
                Label lbl1 = new Label();
                Label lbl2 = new Label();
                lbl1.Location = new Point(x1, y);
                lbl1.Text = "";
                lbl2.Location = new Point(x2, y);
                lbl2.Text = "";
                y += 25;
                lbl_group[i,0] = lbl1;
                lbl_group[i, 1] = lbl2;
                lbl_index++;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(@"..\..\pic\button.png");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form3 = new Form3(this);
            form3.Show();
        }

        private void first_chat_DoubleClick(object sender, EventArgs e)
        {
            chang_color1 = 1;
            chang_color2 = 0;
            form = new Form2(this);
            form.Show();
        }

        private void second_chat_DoubleClick(object sender, EventArgs e)
        {
            chang_color1 = 0;
            chang_color2 = 1;
            form = new Form2(this);
            form.Show();
        }

        public void SetNewColor(Color ncolor)
        {
            if (chang_color1 == 1)
            {
                first_chat.BackColor = ncolor;
            }
            else if (chang_color2 == 1)
            {
                second_chat.BackColor = ncolor;
            }
        }

        public void Getpicture(int picture)
        {
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            PictureBox picture1 = new PictureBox();
            PictureBox picture2 = new PictureBox();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            if (check % 2 == 0)
            {
                lbl1.Text = "斗哥:";
                lbl2.Text = "斗哥:";
            }
            else
            {
                lbl1.Text = "楷特:";
                lbl2.Text = "楷特:";
            }

            lbl1.Location = new Point(0, 0);
            lbl2.Location = new Point(0, 0);

            lbl1.AutoSize = true;
            lbl2.AutoSize = true;

            picture1.SizeMode = PictureBoxSizeMode.Zoom;
            picture2.SizeMode = PictureBoxSizeMode.Zoom;

            picture1.Image = Image.FromFile(@"..\..\pic\" + picture.ToString() + ".png");
            picture2.Image = Image.FromFile(@"..\..\pic\" + picture.ToString() + ".png");

            picture1.Size = new Size(15, 15);
            picture2.Size = new Size(15, 15);

            picture1.Location = new Point(lbl1.Width-65, -1); 
            picture2.Location = new Point(lbl2.Width-65, -1); 

            panel1.Size = new Size(lbl1.Width + picture1.Width + 2, 15);
            panel2.Size = new Size(lbl2.Width + picture2.Width + 2, 15);

            panel1.Controls.Add(lbl1);
            panel1.Controls.Add(picture1);
            panel2.Controls.Add(lbl2);
            panel2.Controls.Add(picture2);

            panel1.Location = new Point(x1, y);
            panel2.Location = new Point(x2, y);

            PictureBox pic1 = new PictureBox();
            PictureBox pic2 = new PictureBox();
            
            lbl_group[lbl_index, 0] = panel1;
            lbl_group[lbl_index, 1] = panel2;

            first_chat.Controls.Clear();
            second_chat.Controls.Clear();
            y = 10;
            if (check % 2 == 0)
            {
                for (int i = lbl_index - 7; i <= lbl_index; i++)
                {
                    lbl_group[i, 0].Location = new Point(lbl_group[i, 0].Location.X, y);
                    lbl_group[i, 1].Location = new Point(lbl_group[i, 1].Location.X, y);

                    if (lbl_group[i, 0].Text.Contains("斗哥:") || checkContain(lbl_group[i, 0]))
                    {
                        first_chat.Controls.Add(lbl_group[i, 0]);
                        second_chat.Controls.Add(lbl_group[i, 1]);
                        if (i > 7)
                        {
                            pic1 = new PictureBox();
                            pic1.Image = Image.FromFile(@"..\..\pic\dog.png");
                            pic1.Size = new Size(10, 10);
                            pic1.Location = new Point(x1 - 10, y);
                            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            first_chat.Controls.Add(pic1);
                            pic2 = new PictureBox();
                            pic2.Image = Image.FromFile(@"..\..\pic\dog.png");
                            pic2.Size = new Size(10, 10);
                            pic2.Location = new Point(x2 - 10, y);
                            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                            second_chat.Controls.Add(pic2);
                        }
                    }
                    else
                    {
                        first_chat.Controls.Add(lbl_group[i, 1]);
                        second_chat.Controls.Add(lbl_group[i, 0]);
                        if (i > 7)
                        {
                            pic1 = new PictureBox();
                            pic1.Image = Image.FromFile(@"..\..\pic\cat.png");
                            pic1.Size = new Size(10, 10);
                            pic1.Location = new Point(x1 - 10, y);
                            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            second_chat.Controls.Add(pic1);
                            pic2 = new PictureBox();
                            pic2.Image = Image.FromFile(@"..\..\pic\cat.png");
                            pic2.Size = new Size(10, 10);
                            pic2.Location = new Point(x2 - 10, y);
                            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                            first_chat.Controls.Add(pic2);
                        }
                    }
                    y += 25;
                }
            }
            else
            {
                first_chat.Controls.Clear();
                second_chat.Controls.Clear();
                y = 10;
                for (int i = lbl_index - 7; i <= lbl_index; i++)
                {
                    lbl_group[i, 1].Location = new Point(lbl_group[i, 1].Location.X, y);
                    lbl_group[i, 0].Location = new Point(lbl_group[i, 0].Location.X, y);

                    if (lbl_group[i, 0].Text.Contains("楷特:") || checkContain2(lbl_group[i, 0]))
                    {
                        first_chat.Controls.Add(lbl_group[i, 1]);
                        second_chat.Controls.Add(lbl_group[i, 0]);
                        if (i > 7)
                        {
                            pic1 = new PictureBox();
                            pic1.Image = Image.FromFile(@"..\..\pic\cat.png");
                            pic1.Size = new Size(10, 10);
                            pic1.Location = new Point(x1 - 10, y);
                            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            second_chat.Controls.Add(pic1);
                            pic2 = new PictureBox();
                            pic2.Image = Image.FromFile(@"..\..\pic\cat.png");
                            pic2.Size = new Size(10, 10);
                            pic2.Location = new Point(x2 - 10, y);
                            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                            first_chat.Controls.Add(pic2);
                        }
                    }
                    else
                    {
                        first_chat.Controls.Add(lbl_group[i, 0]);
                        second_chat.Controls.Add(lbl_group[i, 1]);
                        if (i > 7)
                        {
                            pic1 = new PictureBox();
                            pic1.Image = Image.FromFile(@"..\..\pic\dog.png");
                            pic1.Size = new Size(10, 10);
                            pic1.Location = new Point(x1 - 10, y);
                            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            first_chat.Controls.Add(pic1);
                            pic2 = new PictureBox();
                            pic2.Image = Image.FromFile(@"..\..\pic\dog.png");
                            pic2.Size = new Size(10, 10);
                            pic2.Location = new Point(x2 - 10, y);
                            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                            second_chat.Controls.Add(pic2);
                        }
                    }
                    y += 25;
                }
            }
            lbl_index++;
        }

        private void sent_btn_Click(object sender, EventArgs e)
        {
            Label lbl1=new Label();
            Label lbl2 = new Label();
            PictureBox pic1 = new PictureBox();
            PictureBox pic2 = new PictureBox();

            if (textbox.Text == ""  ||   (game==1 &&(textbox.Text!="剪刀" || textbox.Text!="石頭" || textbox.Text!="布") ))
            {
                textbox.Clear();
            }
            else
            {
                if (check % 2 == 0)
                {
                    lbl1.Location = new Point(x1, y);
                    lbl1.Text = "斗哥:" + textbox.Text;

                    lbl2.Location = new Point(x2, y);
                    lbl2.Text = "斗哥:" + textbox.Text;

                    lbl_group[lbl_index, 0] = lbl1;
                    lbl_group[lbl_index, 1] = lbl2;

                    if (game == 1)
                    {
                        if (textbox.Text == "剪刀" && game == 1)
                        {
                            lbl_index++;
                            y += 25;
                            Label lbl3 = new Label();
                            Label lbl4 = new Label();
                            lbl3.Text = "楷特:布";
                            lbl4.Text = "楷特:布";
                            lbl3.Location = new Point(x1, y);
                            lbl4.Location = new Point(x2, y);
                            lbl_group[lbl_index, 0] = lbl3;
                            lbl_group[lbl_index, 1] = lbl4;
                            game = 0;
                        }
                        else if (textbox.Text == "布" && game == 1)
                        {
                            lbl_index++;
                            y += 25;
                            Label lbl3 = new Label();
                            Label lbl4 = new Label();
                            lbl3.Text = "楷特:石頭";
                            lbl4.Text = "楷特:石頭";
                            lbl3.Location = new Point(x1, y);
                            lbl4.Location = new Point(x2, y);
                            lbl_group[lbl_index, 0] = lbl3;
                            lbl_group[lbl_index, 1] = lbl4;
                            game = 0;
                        }
                        else if (textbox.Text == "石頭" && game == 1)
                        {
                            lbl_index++;
                            y += 25;
                            Label lbl3 = new Label();
                            Label lbl4 = new Label();
                            lbl3.Text = "楷特:剪刀";
                            lbl4.Text = "楷特:剪刀";
                            lbl3.Location = new Point(x1, y);
                            lbl4.Location = new Point(x2, y);
                            lbl_group[lbl_index, 0] = lbl3;
                            lbl_group[lbl_index, 1] = lbl4;
                            game = 0;
                        }
                    }

                    if (textbox.Text == "汪!")
                    {
                        lbl_index++;
                        y += 25;
                        Label lbl3 = new Label();
                        Label lbl4 = new Label();
                        lbl3.Text = "楷特:喵";
                        lbl4.Text = "楷特:喵";
                        lbl3.Location = new Point(x1, y);
                        lbl4.Location = new Point(x2, y);
                        lbl_group[lbl_index, 0] = lbl3;
                        lbl_group[lbl_index, 1] = lbl4;
                    }

                    if (textbox.Text == "猜拳")
                    {
                        lbl_index++;
                        y += 25;
                        Label lbl3 = new Label();
                        Label lbl4 = new Label();
                        lbl3.Text = "楷特:遊戲開始";
                        lbl4.Text = "楷特:遊戲開始";
                        lbl3.Location = new Point(x1, y);
                        lbl4.Location = new Point(x2, y);
                        lbl_group[lbl_index, 0] = lbl3;
                        lbl_group[lbl_index, 1] = lbl4;
                        game = 1;
                    }


                    first_chat.Controls.Clear();
                    second_chat.Controls.Clear();
                    y = 10;

                    for (int i = lbl_index - 7; i <= lbl_index; i++)
                    {
                        lbl_group[i, 0].Location = new Point(lbl_group[i, 0].Location.X, y);
                        lbl_group[i, 1].Location = new Point(lbl_group[i, 1].Location.X, y);

                        if (lbl_group[i, 0].Text.Contains("斗哥:") || checkContain(lbl_group[i, 0]))
                        {
                            first_chat.Controls.Add(lbl_group[i, 0]);
                            second_chat.Controls.Add(lbl_group[i, 1]);
                            if (i > 7)
                            {
                                pic1 = new PictureBox();
                                pic1.Image = Image.FromFile(@"..\..\pic\dog.png");
                                pic1.Size = new Size(10, 10);
                                pic1.Location = new Point(x1 - 10, y);
                                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                first_chat.Controls.Add(pic1);
                                pic2 = new PictureBox();
                                pic2.Image = Image.FromFile(@"..\..\pic\dog.png");
                                pic2.Size = new Size(10, 10);
                                pic2.Location = new Point(x2 - 10, y);
                                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                second_chat.Controls.Add(pic2);
                            }
                        }
                        else
                        {
                            first_chat.Controls.Add(lbl_group[i, 1]);
                            second_chat.Controls.Add(lbl_group[i, 0]);
                            if (i > 7)
                            {
                                pic1 = new PictureBox();
                                pic1.Image = Image.FromFile(@"..\..\pic\cat.png");
                                pic1.Size = new Size(10, 10);
                                pic1.Location = new Point(x1 - 10, y);
                                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                second_chat.Controls.Add(pic1);
                                pic2 = new PictureBox();
                                pic2.Image = Image.FromFile(@"..\..\pic\cat.png");
                                pic2.Size = new Size(10, 10);
                                pic2.Location = new Point(x2 - 10, y);
                                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                first_chat.Controls.Add(pic2);
                            }
                        }
                        y += 25;
                    }
                }
                else
                {
                    lbl1.Location = new Point(x1, y);
                    lbl1.Text = "楷特:" + textbox.Text;

                    lbl2.Location = new Point(x2, y);
                    lbl2.Text = "楷特:" + textbox.Text;

                    lbl_group[lbl_index, 0] = lbl1;
                    lbl_group[lbl_index, 1] = lbl2;

                    if (textbox.Text == "喵!")
                    {
                        lbl_index++;
                        y += 25;
                        Label lbl3 = new Label();
                        Label lbl4 = new Label();
                        lbl3.Text = "斗哥:汪";
                        lbl4.Text = "斗哥:汪";
                        lbl3.Location = new Point(x1, y);
                        lbl4.Location = new Point(x2, y);
                        lbl_group[lbl_index, 0] = lbl3;
                        lbl_group[lbl_index, 1] = lbl4;
                    }

                    first_chat.Controls.Clear();
                    second_chat.Controls.Clear();
                    y = 10;
                    for (int i = lbl_index - 7; i <= lbl_index; i++)
                    {
                        lbl_group[i, 1].Location = new Point(lbl_group[i, 1].Location.X, y);
                        lbl_group[i, 0].Location = new Point(lbl_group[i, 0].Location.X, y);

                        if (lbl_group[i, 0].Text.Contains("楷特:") || checkContain2(lbl_group[i, 0]))
                        {
                            first_chat.Controls.Add(lbl_group[i, 1]);
                            second_chat.Controls.Add(lbl_group[i, 0]);
                            if (i > 7)
                            {
                                pic1 = new PictureBox();
                                pic1.Image = Image.FromFile(@"..\..\pic\cat.png");
                                pic1.Size = new Size(10, 10);
                                pic1.Location = new Point(x1 - 10, y);
                                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                second_chat.Controls.Add(pic1);
                                pic2 = new PictureBox();
                                pic2.Image = Image.FromFile(@"..\..\pic\cat.png");
                                pic2.Size = new Size(10, 10);
                                pic2.Location = new Point(x2 - 10, y);
                                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                first_chat.Controls.Add(pic2);
                            }
                        }
                        else
                        {
                            first_chat.Controls.Add(lbl_group[i, 0]);
                            second_chat.Controls.Add(lbl_group[i, 1]);
                            if (i > 7)
                            {
                                pic1 = new PictureBox();
                                pic1.Image = Image.FromFile(@"..\..\pic\dog.png");
                                pic1.Size = new Size(10, 10);
                                pic1.Location = new Point(x1 - 10, y);
                                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                first_chat.Controls.Add(pic1);
                                pic2 = new PictureBox();
                                pic2.Image = Image.FromFile(@"..\..\pic\dog.png");
                                pic2.Size = new Size(10, 10);
                                pic2.Location = new Point(x2 - 10, y);
                                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                second_chat.Controls.Add(pic2);
                            }
                        }
                        y += 25;
                    }
                }
                lbl_index++;
                textbox.Clear();
                textbox.Focus();
            }
        }

        private void chat_SelectedIndexChanged(object sender, EventArgs e)
        {
            check++;
            if (check % 2 == 0)
            {
                sent_btn.Enabled = true;
                pictureBox1.Enabled = true;
            }
            else
            {
                if (game == 1)
                {
                    sent_btn.Enabled = false;
                    pictureBox1.Enabled = false;
                }
                else
                {
                    sent_btn.Enabled = true;
                    pictureBox1.Enabled = true;
                }
            }

        }

        public bool checkContain(Control panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Label lbl)
                {
                    if (lbl.Text.Contains("斗哥:"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool checkContain2(Control panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Label lbl)
                {
                    if (lbl.Text.Contains("楷特:"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
