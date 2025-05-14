using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_6_1
{
    public partial class Form1 : Form
    {
        List<Panel> panelList = new List<Panel>();
        PictureBox s = new PictureBox();
        int s_x = 3;
        int s_y = 3;
        int row = 15;
        int col = 30;
        int bag_index = 0;
        int temp_location;
        int h_ovalue = 0;
        int v_ovalue = 0;
        int jump = 0;
        int jump_speed = -30;
        int gravity = 5;
        int fall_speed = 0;
        int has_fall = 0;
        int i_y;
        int delta_x;
        int delta_y;

        char[,] map = new char[15, 30];


        public Form1()
        {
            InitializeComponent();

            vScrollBar1.Visible = false;
            hScrollBar1.Visible = false;
            bag.Visible = false;
            pictureBox5.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            tableLayoutPanel1.AllowDrop = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            background.Image = Image.FromFile(@"..\..\pic\background.png");
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            this.KeyPreview = true;
            tableLayoutPanel1.Padding = new Padding(0, 0, 0, 0);
            tableLayoutPanel1.Margin = new Padding(0, 0, 0, 0);
            hScrollBar1.Maximum = tableLayoutPanel1.Width - this.Width;
            vScrollBar1.Maximum = tableLayoutPanel1.Height - this.Height;

            s.Image = Image.FromFile(@"..\..\pic\steve.png");
            s.SizeMode = PictureBoxSizeMode.StretchImage;
            s.Anchor = AnchorStyles.None;
            s.Margin = new Padding(0);
            s.Padding = new Padding(0);
            s.Tag = "steve";

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            background.Visible = false;
            start_btn.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            vScrollBar1.Visible = true;
            hScrollBar1.Visible = true;
            bag.Visible = true;
            pictureBox5.Visible = true;
            pictureBox5.BringToFront();
            pictureBox5.Location = new Point(bag.Left, bag.Top - 2);
            temp_location = bag.Left;
            tableLayoutPanel1.Visible = true;
            s.Visible = true;

            this.BackColor = Color.Black;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    map[i, j] = '0';
                }
            }

            for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
            {
                PictureBox panel = new PictureBox();
                panel.Image = Image.FromFile(@"..\..\pic\block1.png");
                panel.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Margin = new Padding(0, 0, 0, 0);
                panel.Padding = new Padding(0, 0, 0, 0);
                panel.Tag = "block1";
                map[5, j] = '1';
                panel.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
                tableLayoutPanel1.Controls.Add(panel, j, 5);
            }
            for (int i = 6; i < 11; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    PictureBox panel = new PictureBox();
                    panel.Image = Image.FromFile(@"..\..\pic\block2.png");
                    panel.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel.Margin = new Padding(0, 0, 0, 0);
                    panel.Padding = new Padding(0, 0, 0, 0);
                    panel.Tag = "block2";
                    map[i, j] = '2';
                    panel.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
                    tableLayoutPanel1.Controls.Add(panel, j, i);
                }
            }

            for (int i = tableLayoutPanel1.RowCount - 1; i > 10; i--)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    PictureBox panel = new PictureBox();
                    panel.Image = Image.FromFile(@"..\..\pic\block3.png");
                    panel.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel.Margin = new Padding(0, 0, 0, 0);
                    panel.Padding = new Padding(0, 0, 0, 0);
                    panel.Dock = DockStyle.Fill;
                    panel.AutoSize = false;
                    panel.Tag = "block3";
                    map[i, j] = '3';
                    panel.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
                    tableLayoutPanel1.Controls.Add(panel, j, i);
                }
            }


            s.Size = new Size(tableLayoutPanel1.GetColumnWidths()[0], 2 * tableLayoutPanel1.GetRowHeights()[0]);
            s.Location = new Point(3 * tableLayoutPanel1.GetColumnWidths()[0], 3 * tableLayoutPanel1.GetRowHeights()[0]);
            this.Controls.Add(s);
            s.BringToFront();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && bag_index > 0)
            {
                temp_location -= bag.GetColumnWidths()[0];
                pictureBox5.Location = new Point(temp_location, bag.Top - 2);
                bag_index--;
            }
            else if (e.KeyCode == Keys.Right && bag_index < 8)
            {
                temp_location += bag.GetColumnWidths()[0];
                pictureBox5.Location = new Point(temp_location, bag.Top - 2);
                bag_index++;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                vScrollBar1.Enabled = false;
                hScrollBar1.Enabled = false;
                tableLayoutPanel1.Enabled = false;
                s.Visible = false;
            }
            if (e.KeyCode == Keys.A)
            {
                int s_row = GetRow(s.Location, tableLayoutPanel1);
                int s_column = GetColumn(s.Location, tableLayoutPanel1);
                if (s_column > 0 && map[s_row, s_column - 1] == '0' && map[s_row + 1, s_column - 1] == '0')
                {
                    s.Location = new Point(s.Location.X - tableLayoutPanel1.GetColumnWidths()[0], s.Location.Y);
                    fall();
                }
            }
            if (e.KeyCode == Keys.D)
            {
                int s_row = GetRow(s.Location, tableLayoutPanel1);
                int s_column = GetColumn(s.Location, tableLayoutPanel1);
                if (s_column < 29 && map[s_row, s_column + 1] == '0' && map[s_row + 1, s_column + 1] == '0')
                {
                    s.Location = new Point(s.Location.X + tableLayoutPanel1.GetColumnWidths()[0], s.Location.Y);
                    fall();
                }
            }
            if (e.KeyCode == Keys.W && jump == 0)
            {
                jump = 1;
                jump_speed = -30;
                i_y = s.Location.Y;
                jumper.Start();
                fall();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int delta_x = e.NewValue - h_ovalue;
            int newTableLayoutX = tableLayoutPanel1.Location.X - delta_x;
            int newPictureBoxX = s.Location.X - delta_x;

            if (newTableLayoutX <= 0 && newTableLayoutX >= this.ClientSize.Width - tableLayoutPanel1.Width)
            {
                tableLayoutPanel1.Location = new Point(newTableLayoutX, tableLayoutPanel1.Location.Y);
                s.Location = new Point(newPictureBoxX, s.Location.Y);
            }

            h_ovalue = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int delta_y = e.NewValue - v_ovalue;
            int newTableLayoutY = tableLayoutPanel1.Location.Y - delta_y;
            int newPictureBoxY = s.Location.Y - delta_y;

            if (newTableLayoutY <= 0 && newTableLayoutY >= this.ClientSize.Height - tableLayoutPanel1.Height)
            {
                tableLayoutPanel1.Location = new Point(tableLayoutPanel1.Location.X, newTableLayoutY);
                s.Location = new Point(s.Location.X, newPictureBoxY);
            }

            v_ovalue = e.NewValue;
        }

        private int GetRow(Point point, TableLayoutPanel tableLayoutPanel)
        {
            int height = 0;
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                height += tableLayoutPanel.GetRowHeights()[i];
                if (point.Y < height)
                {
                    return i; 
                }
            }
            return tableLayoutPanel.RowCount - 1; 
        }

        private int GetColumn(Point point, TableLayoutPanel tableLayoutPanel)
        {
            int width = 0;
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                width += tableLayoutPanel.GetColumnWidths()[i];
                if (point.X < width)
                {
                    return i; 
                }
            }
            return tableLayoutPanel.ColumnCount - 1; 
        }


        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            int get_row = GetRow(point, tableLayoutPanel1);
            int get_column = GetColumn(point, tableLayoutPanel1);

            if ((get_row >= 0 && get_column >= 0))
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(get_column, get_row) == null)
                    {
                        PictureBox pictureBox = new PictureBox();
                        int temp = bag_index + 1;
                        if (temp < 5)
                        {
                            pictureBox.Image = Image.FromFile(@"..\..\pic\block" + temp + ".png");
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox.Margin = new Padding(0, 0, 0, 0);
                            pictureBox.Padding = new Padding(0, 0, 0, 0);
                            pictureBox.Dock = DockStyle.Fill;
                            string temp_s = "block" + temp.ToString();
                            pictureBox.Tag = temp_s;
                            pictureBox.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
                            tableLayoutPanel1.Controls.Add(pictureBox, get_column, get_row);
                            map[get_row, get_column] = (char)(temp + '0');//為啥
                        }
                    }

                }
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox clickedBox = sender as PictureBox;
            if (clickedBox != null)
            {
                int get_row = GetRow(clickedBox.Location, tableLayoutPanel1);
                int get_column = GetColumn(clickedBox.Location, tableLayoutPanel1);

                if (e.Button == MouseButtons.Right)
                {
                    map[get_row, get_column] = '0';
                    tableLayoutPanel1.Controls.Remove(clickedBox);
                    fall();
                    clickedBox.Dispose();
                }
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            vScrollBar1.Enabled = true;
            hScrollBar1.Enabled = true;
            tableLayoutPanel1.Enabled = true;
            s.Enabled = true;
            s.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vScrollBar1.Visible = false;
            hScrollBar1.Visible = false;
            bag.Visible = false;
            pictureBox5.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            tableLayoutPanel1.Visible = false;
            background.Visible = true;
            start_btn.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel1.Controls.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int get_sx = GetRow(s.Location, tableLayoutPanel1);
            int get_sy = GetColumn(s.Location, tableLayoutPanel1);
            map[get_sx, get_sy + 1] = '5';

            FileInfo file = new FileInfo(@"..\..\map.txt");
            FileStream fs;
            if (!file.Exists)
            {
                fs = file.Create();
                fs.Close();
            }
            StreamWriter sw = new StreamWriter(file.FullName, false);//防錯

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    sw.Write(map[i, j].ToString());
                }
                sw.WriteLine();
            }
            sw.Close();

            vScrollBar1.Visible = false;
            hScrollBar1.Visible = false;
            bag.Visible = false;
            pictureBox5.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            tableLayoutPanel1.Visible = false;
            background.Visible = true;
            start_btn.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel1.Controls.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            background.Visible = false;
            start_btn.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            vScrollBar1.Visible = true;
            hScrollBar1.Visible = true;
            vScrollBar1.Enabled = true;
            hScrollBar1.Enabled = true;
            bag.Visible = true;
            pictureBox5.Visible = true;
            pictureBox5.BringToFront();
            pictureBox5.Location = new Point(bag.Left, bag.Top - 2);
            temp_location = bag.Left;
            tableLayoutPanel1.Visible = true;
            s.Enabled = true;
            s.Visible = true;

            this.BackColor = Color.Black;
            StreamReader sr = new StreamReader(@"..\..\map.txt");
            for (int i = 0; i < 15; i++)
            {
                string line = sr.ReadLine();
                if (line == null || line.Length != 30)
                {
                    MessageBox.Show("地圖檔案格式錯誤");
                    return;
                }

                for (int j = 0; j < 30; j++)
                {
                    char c = line[j];
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Margin = new Padding(0, 0, 0, 0);
                    pictureBox.Padding = new Padding(0, 0, 0, 0);
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
                    switch (c)
                    {
                        case '1':
                            pictureBox.Image = Image.FromFile(@"..\..\pic\block1.png");
                            tableLayoutPanel1.Controls.Add(pictureBox, j, i);
                            map[i, j] = '1';
                            break;
                        case '2':
                            pictureBox.Image = Image.FromFile(@"..\..\pic\block2.png");
                            tableLayoutPanel1.Controls.Add(pictureBox, j, i);
                            map[i, j] = '2';
                            break;
                        case '3':
                            pictureBox.Image = Image.FromFile(@"..\..\pic\block3.png");
                            tableLayoutPanel1.Controls.Add(pictureBox, j, i);
                            map[i, j] = '3';
                            break;
                        case '4':
                            pictureBox.Image = Image.FromFile(@"..\..\pic\block4.png");
                            tableLayoutPanel1.Controls.Add(pictureBox, j, i);
                            map[i, j] = '4';
                            break;
                        case '0':
                            map[i, j] = '0';
                            break;
                        case '5':
                            map[i, j] = '0';
                            s.Location = new Point(j * tableLayoutPanel1.GetColumnWidths()[0], i * tableLayoutPanel1.GetRowHeights()[0]);
                            s.Size = new Size(tableLayoutPanel1.GetColumnWidths()[0], 2 * tableLayoutPanel1.GetRowHeights()[0]);
                            this.Controls.Add(s);
                            s.BringToFront();
                            break;
                    }
                }
            }
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jumper_Tick(object sender, EventArgs e)
        {
            s.Location = new Point(s.Location.X, s.Location.Y + jump_speed);
            int get_row = GetRow(s.Location, tableLayoutPanel1);
            int get_col = GetColumn(s.Location, tableLayoutPanel1);
            jump_speed += gravity;
            if ((get_row > 0 && map[get_row - 1, get_col] != '0'))
            {
                s.Location = new Point(s.Location.X, i_y);
                jump_speed = 0;
                jump = 0;
                jumper.Stop();
            }
            if (get_row + 2 < map.GetLength(0) && map[get_row + 2, get_col] != '0')
            {
                s.Location = new Point(s.Location.X, (get_row) * tableLayoutPanel1.GetRowHeights()[0]);
                jump_speed = 0;
                jump = 0;
                jumper.Stop();
            }
        }

        private void fall()
        {
            int get_row = GetRow(s.Location, tableLayoutPanel1);
            int get_col = GetColumn(s.Location, tableLayoutPanel1);
            if (map[get_row + 2, get_col] == '0')
            {
                has_fall = 1;
                faller.Start();
            }
        }

        private void faller_Tick(object sender, EventArgs e)
        {
            if (has_fall == 1)
            {
                s.Location = new Point(s.Location.X, s.Location.Y + fall_speed);
                fall_speed += gravity;
                int get_row = GetRow(s.Location, tableLayoutPanel1);
                int get_col = GetColumn(s.Location, tableLayoutPanel1);
                if (map[get_row + 2, get_col] != '0')
                {
                    s.Location = new Point(s.Location.X, (get_row) * tableLayoutPanel1.GetRowHeights()[0]);
                    fall_speed = 0;
                    has_fall = 0;
                    faller.Stop();
                }
            }
        }
    }
}