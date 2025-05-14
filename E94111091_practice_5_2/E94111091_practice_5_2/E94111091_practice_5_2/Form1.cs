using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_5_2
{
    public partial class Form1 : Form
    {
        List<Character> characters = new List<Character>();
        List<FlowLayoutPanel> panels = new List<FlowLayoutPanel>();
        List<FlowLayoutPanel> anime_panels = new List<FlowLayoutPanel>();
        List<Anime> animes = new List<Anime>();
        FlowLayoutPanel temp_panel;
        int count = 10;
        int dragging = 0;
        int sX, sY;
        int oX, oY;
        int panelXPosition = 0;
        int aX, aY;
        int player_hp=3;
        int round = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DoubleBuffered = true;
            start_btn.Visible = true;
            confirm_btn.Visible = false;
            add_btn.Visible = false;
            delete_btn.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            tableLayoutPanel1.Visible = false;
            timer1.Enabled = false;


            listBox1.Items.Add("Cardigan");
            listBox1.Items.Add("Myrtle");
            listBox1.Items.Add("Melantha");

            Panel panel1 = new Panel();
            panel1.BackColor = Color.Red;
            panel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(panel1,0,1);
            aX=tableLayoutPanel1.Location.X+25; 
            aY=tableLayoutPanel1.Location.Y+65;

            panel1.Margin = new Padding(0);

            Panel panel2 = new Panel();
            panel2.BackColor = Color.LightBlue;
            tableLayoutPanel1.Controls.Add(panel2,10,1);
            panel2.Margin = new Padding(0);

            label1.Text = player_hp.ToString() +"/"+round.ToString();
            label2.Text = "10";

            label3.Text = "";
            label4.Text = "";
            label5.Text = "";

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            start_btn.Visible =false;
            confirm_btn.Visible = true;
            add_btn.Visible = true;
            delete_btn.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = true;

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
                listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                listBox1.Items.Add(listBox2.SelectedItem.ToString());
                listBox2.Items.Remove(listBox2.SelectedItem.ToString());
            }
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count>0)
            {
                confirm_btn.Visible = false;
                add_btn.Visible = false;
                delete_btn.Visible = false;
                listBox1.Visible = false;
                listBox2.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                tableLayoutPanel1.Visible = true;
                timer1.Enabled = true;

                foreach (var item in listBox2.Items)
                {
                    string value = item.ToString();
                    Character character = new Character(value);
                    characters.Add(character);
                }
                panelXPosition = tableLayoutPanel1.Left;

                for (int i = 0; i < characters.Count; i++)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    System.Windows.Forms.Label lbl1 = new System.Windows.Forms.Label();
                    System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label();

                    lbl1.Text = characters[i].GetName();
                    lbl1.Font = new Font(lbl1.Font.OriginalFontName, 8);
                    lbl2.Text = characters[i].GetCost().ToString();
                    lbl2.Font = new Font(lbl1.Font.OriginalFontName, 10);

                    lbl1.Enabled = false;
                    lbl2.Enabled = false;

                    panel.FlowDirection = FlowDirection.TopDown;
                    panel.Controls.Add(lbl1);
                    panel.Controls.Add(lbl2);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Size = new Size(50, 50);
                    panel.AutoSize = false;
                    panel.BackColor = Color.White;
                    panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
                    panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
                    panel.MouseUp += new MouseEventHandler(Panel_MouseUp);
                    panel.Location = new Point(panelXPosition, tableLayoutPanel1.Bottom + 10);
                    this.Controls.Add(panel);
                    panel.BringToFront();
                    panelXPosition += panel.Width;
                }
            }
            
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = 1;
                sX = e.X;
                sY= e.Y;
                temp_panel = sender as FlowLayoutPanel;
                oX = temp_panel.Location.X;
                oY = temp_panel.Location.Y;
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging==1&& temp_panel!=null)
            {
                temp_panel.Left += (e.X - sX);
                temp_panel.Top += (e.Y - sY);
            }
        }


        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (temp_panel != null)
            {
                Point dropPoint = temp_panel.PointToScreen(new Point(e.X, e.Y));
                Point relativePoint = tableLayoutPanel1.PointToClient(dropPoint);

                System.Windows.Forms.Label lbl1 = temp_panel.Controls[0] as System.Windows.Forms.Label;
                Character character = new Character(lbl1.Text);
                dragging = 0;
                if (IsControlInsideTableLayoutPanel(temp_panel, tableLayoutPanel1) && int.Parse(label2.Text) >= character.GetCost())
                {
                    int column = GetColumn(relativePoint, tableLayoutPanel1);
                    int row = GetRow(relativePoint, tableLayoutPanel1);

                    if ((column >= 0 && row >= 0) && !((column == 0 && row == 1) || (column == 10 && row == 1)))
                    {
                        count -= character.GetCost();
                        temp_panel.Controls.Clear();
                        System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label();
                        System.Windows.Forms.Label lbl3 = new System.Windows.Forms.Label();
                        lbl2.Text = character.GetFullHp().ToString() + "/" + character.GetFullHp().ToString();
                        lbl3.Text = character.GetCD().ToString();
                        lbl1.Enabled = false;
                        lbl2.Enabled = false;
                        lbl3.Enabled = false;
                        temp_panel.Controls.Add(lbl1);
                        temp_panel.Controls.Add(lbl2);
                        temp_panel.Controls.Add(lbl3);
                        temp_panel.BorderStyle = BorderStyle.None;
                        temp_panel.BackColor = Color.Gray;
                        temp_panel.Margin = new Padding(0);
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = 1000;
                        timer.Tag = temp_panel;
                        timer.Tick += new EventHandler(timer_Tick);
                        temp_panel.Tag = timer;
                        if (timer.Enabled == false)
                        {
                            timer.Start();
                        }

                        temp_panel.MouseDown -= new MouseEventHandler(Panel_MouseDown);
                        temp_panel.MouseMove -= new MouseEventHandler(Panel_MouseMove);
                        temp_panel.MouseUp -= new MouseEventHandler(Panel_MouseUp);

                        temp_panel.MouseClick += new MouseEventHandler(Panel_MouseClick);
                        temp_panel.MouseDoubleClick += new MouseEventHandler(Panel_MouseDoubleClick);
                        temp_panel.MouseEnter += new EventHandler(Panel_MouseEnter);
                        temp_panel.MouseLeave += new EventHandler(Panel_MouseLeave);

                        tableLayoutPanel1.Controls.Add(temp_panel, column, row);
                        this.Controls.Remove(temp_panel);

                        if (attack.Enabled == false)
                        {
                            attack.Start();
                        }

                        panelXPosition = tableLayoutPanel1.Left;

                        foreach (Control control in this.Controls)
                        {
                            if (control is FlowLayoutPanel panel && !anime_panels.Contains(control))
                            {
                                if (control.Controls[0].Text.Equals("Cardigan"))
                                {
                                    panel.Location = new Point(panelXPosition, tableLayoutPanel1.Bottom + 10);
                                }
                                else if (control.Controls[0].Text.Equals("Myrtle"))
                                {
                                    panel.Location = new Point(panelXPosition + panel.Width, tableLayoutPanel1.Bottom + 10);
                                }
                                else
                                {
                                    panel.Location = new Point(panelXPosition + 2 * panel.Width, tableLayoutPanel1.Bottom + 10);
                                }
                            }
                        }
                    }
                    else
                    {
                        temp_panel.Location = new Point(oX, oY);
                    }
                }
                else
                {
                    temp_panel.Location = new Point(oX, oY);
                }
            }
            
        }
        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            temp_panel = sender as FlowLayoutPanel;
            tableLayoutPanel1.Controls.Remove(temp_panel); 
            System.Windows.Forms.Label lbl1 = temp_panel.Controls[0] as System.Windows.Forms.Label;
            Character character =GetCharacter(lbl1.Text);
            character.SetHp(character.GetFullHp());
            temp_panel.Controls.Clear();

            System.Windows.Forms.Label lbl2=new System.Windows.Forms.Label();
            lbl2.Text=character.GetCost().ToString();
            lbl1.Enabled = false;
            lbl2.Enabled = false;
            temp_panel.Controls.Add(lbl1);
            temp_panel.Controls.Add(lbl2);
            temp_panel.BorderStyle = BorderStyle.FixedSingle;
            temp_panel.Size = new Size(50, 50);
            temp_panel.AutoSize = false;
            temp_panel.BackColor = Color.White;
            temp_panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            temp_panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            temp_panel.MouseUp += new MouseEventHandler(Panel_MouseUp);

            temp_panel.MouseEnter -= new EventHandler(Panel_MouseEnter);
            temp_panel.MouseLeave -= new EventHandler(Panel_MouseLeave);
            temp_panel.MouseClick -= new MouseEventHandler(Panel_MouseClick);
            temp_panel.MouseDoubleClick -= new MouseEventHandler(Panel_MouseDoubleClick);


            if (temp_panel.Tag is System.Windows.Forms.Timer timer)
            {
                timer.Stop(); 
            }
            panelXPosition = tableLayoutPanel1.Left;

            foreach (Control control in this.Controls)
            {
                if (control is FlowLayoutPanel panel && !anime_panels.Contains(control))
                {
                    if (control.Controls[0].Text.Equals("Cardigan"))
                    {
                        panel.Location = new Point(panelXPosition, tableLayoutPanel1.Bottom + 10);
                    }
                    else if (control.Controls[0].Text.Equals("Myrtle"))
                    {
                        panel.Location = new Point(panelXPosition+ panel.Width, tableLayoutPanel1.Bottom + 10);
                    }
                    else
                    {
                        panel.Location = new Point(panelXPosition+2* panel.Width, tableLayoutPanel1.Bottom + 10);
                    }
                }
            }
            temp_panel.Location = new Point(panelXPosition, tableLayoutPanel1.Bottom + 10);
            this.Controls.Add(temp_panel);
            temp_panel.BringToFront();
        }

        private void Panel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            temp_panel = sender as FlowLayoutPanel;
            System.Windows.Forms.Label lbl1 = temp_panel.Controls[0] as System.Windows.Forms.Label;
            Character character = GetCharacter(lbl1.Text);
            System.Windows.Forms.Label lbl3 = temp_panel.Controls[2] as System.Windows.Forms.Label;
            if(int.Parse(lbl3.Text) == 0)
            {
                if (lbl1.Text == "Cardigan")
                {
                    int plus_hp=(int)Math.Floor(character.GetFullHp()*0.4);
                    if (character.GetHp() + plus_hp>=character.GetFullHp())
                    {
                        character.SetHp(character.GetFullHp());
                    }
                    else
                    {
                        character.SetHp(character.GetHp() + plus_hp);
                    }
                    lbl3.Text= character.GetCD().ToString();
                }

                if (lbl1.Text == "Myrtle")
                {
                    count += 14;
                    if (count > 99)
                    {
                        count = 99;
                    }
                    lbl3.Text = character.GetCD().ToString();
                }

                if (lbl1.Text == "Melantha")
                {
                    character.SetDamage(2*character.GetDamage());
                    //對範圍內敵人造成兩倍傷害
                }
                temp_panel.BackColor = Color.Gray;
                temp_panel.MouseClick += new MouseEventHandler(Panel_MouseClick);
            }
        }
        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            temp_panel= sender as FlowLayoutPanel;
            label3.Text = temp_panel.Controls[0].Text;
            label4.Text = temp_panel.Controls[1].Text;
            label5.Text = temp_panel.Controls[2].Text;
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private bool IsControlInsideTableLayoutPanel(Control control, TableLayoutPanel tableLayoutPanel)
        {
            Rectangle tableRect = tableLayoutPanel.ClientRectangle; 
            tableRect.Location = tableLayoutPanel.PointToScreen(Point.Empty); 

            Rectangle controlRect = control.Bounds; 
            controlRect.Location = control.Parent.PointToScreen(control.Location); 

            return tableRect.IntersectsWith(controlRect);
        }

        private int GetColumn(Point point, TableLayoutPanel tableLayoutPanel)
        {
            int width = 0;
            for(int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                width += tableLayoutPanel.GetColumnWidths()[i];
                if (point.X < width)
                {
                    return i;
                }
            }
            return -1;
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
            return -1;
        }

        private Point GetCellPosition( int column, int row)
        {
            int x = 0, y = 0;
            for (int i = 0; i < column; i++)
            {
                x += tableLayoutPanel1.GetColumnWidths()[i];
            }
            for (int j = 0; j < row; j++)
            {
                y += tableLayoutPanel1.GetRowHeights()[j];
            }
            return new Point(x, y);
        }

        private void attack_Tick(object sender, EventArgs e)
        {
            if (round > 0)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Size = new Size(40, 20);
                panel.Location = new Point(aX, aY);
                panel.BackColor = Color.Yellow;


                Anime anime = new Anime();
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = anime.GetHp().ToString();
                panel.Controls.Add(lbl);
                animes.Add(anime);

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 100;
                timer.Tick += new EventHandler(anime_timer_Tick);
                panel.Tag = timer;
                timer.Tag = panel;
                timer.Start();
                this.Controls.Add(panel);
                anime_panels.Add(panel);
                panel.BringToFront();
            }
            else
            {
                if (player_hp > 0)
                {
                    //win
                    start_btn.Visible = false;
                    confirm_btn.Visible = false;
                    add_btn.Visible = false;
                    delete_btn.Visible = false;
                    listBox1.Visible = false;
                    listBox2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    attack.Enabled = false;
                    tableLayoutPanel1.Visible = false;
                    this.Controls.Clear();
                    TextBox textBox1=new TextBox();
                    textBox1.Location = new Point(10, 10); 
                    textBox1.Size = new Size(200, 30);
                    textBox1.Text = "YOU WIN";
                    textBox1.Visible = true;
                    textBox1.BringToFront();

                }
            }
            round--;
            label1.Text = player_hp.ToString() + "/" + round.ToString();

        }

        private void fight_Tick(object sender, EventArgs e)
        {
            var panels = fight.Tag as Tuple<Control, FlowLayoutPanel, System.Windows.Forms.Timer>;
            FlowLayoutPanel character_panel = (FlowLayoutPanel)panels.Item1; // 角色的面板
            FlowLayoutPanel anime_panel = panels.Item2; // 敵人的面板
            System.Windows.Forms.Timer attack =panels.Item3;
            int character_hp;
            int anime_hp;
            string name = character_panel.Controls[0].Text;
            string index;
            
            character_hp=GetCharacter(name).GetHp() ;
            anime_hp = int.Parse(anime_panel.Controls[0].Text);

            character_hp -= (600 - GetCharacter(name).GetDef());
            GetCharacter(name).SetHp(character_hp);
            anime_hp -= (GetCharacter(name).GetDamage() - 300);
            character_panel.Controls[1].Text=character_hp.ToString()+"/"+ GetCharacter(name).GetFullHp();
            anime_panel.Controls[0].Text=anime_hp.ToString();
            if (character_hp <= 0 )
            {
                GetCharacter(name).SetHp( GetCharacter(name).GetFullHp());
                System.Windows.Forms.Label lbl1 = character_panel.Controls[0] as System.Windows.Forms.Label;
                Character character = GetCharacter(lbl1.Text);
                temp_panel.Controls.Clear();

                System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label();
                lbl2.Text = character.GetCost().ToString();
                lbl1.Enabled = false;
                lbl2.Enabled = false;
                character_panel.Controls.Add(lbl1);
                character_panel.Controls.Add(lbl2);
                character_panel.BorderStyle = BorderStyle.FixedSingle;
                character_panel.Size = new Size(50, 50);
                character_panel.AutoSize = false;
                character_panel.BackColor = Color.White;
                character_panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
                character_panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
                character_panel.MouseUp += new MouseEventHandler(Panel_MouseUp);

                character_panel.MouseEnter -= new EventHandler(Panel_MouseEnter);
                character_panel.MouseLeave -= new EventHandler(Panel_MouseLeave);
                character_panel.MouseClick -= new MouseEventHandler(Panel_MouseClick);
                character_panel.MouseDoubleClick -= new MouseEventHandler(Panel_MouseDoubleClick);


                if (character_panel.Tag is System.Windows.Forms.Timer timer)
                {
                    timer.Stop();
                }
                this.Controls.Add(character_panel);
                tableLayoutPanel1.Controls.Remove(character_panel);
                character_panel.BringToFront();
                panelXPosition = tableLayoutPanel1.Left;

                foreach (Control control in this.Controls)
                {
                    if (control is FlowLayoutPanel panel && !anime_panels.Contains(control))
                    {
                        if (control.Controls[0] != null)
                        {
                            control.Size = new Size(50, 50);
                            if (control.Controls[0].Text.Equals("Cardigan"))
                            {
                                panel.Location = new Point(panelXPosition, tableLayoutPanel1.Bottom + 10);
                            }
                            else if (control.Controls[0].Text.Equals("Myrtle"))
                            {
                                panel.Location = new Point(panelXPosition + panel.Width, tableLayoutPanel1.Bottom + 10);
                            }
                            else
                            {
                                panel.Location = new Point(panelXPosition + 2 * panel.Width, tableLayoutPanel1.Bottom + 10);
                            }
                        }
                    }
                }
                fight.Stop();
                attack.Start();
            }

            if (anime_hp < 0)
            {
                this.Controls.Remove(anime_panel);
                fight.Stop();
            }

        }

        private void anime_timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            FlowLayoutPanel panel = timer.Tag as FlowLayoutPanel;
            panel.Location = new Point(panel.Location.X+5,panel.Location.Y);
  
            int panelCenterX = panel.Location.X + panel.Width / 2;
            int panelCenterY = panel.Location.Y + panel.Height / 2;
            int cellCenterX = GetCellPosition(10, 1).X + tableLayoutPanel1.GetColumnWidths()[10] / 2;
            if (Math.Abs(panelCenterX - cellCenterX) <= 3)
            {
                //移動結束
                player_hp--;
                label1.Text = player_hp.ToString() + "/" + round.ToString();
                this.Controls.Remove(panel);
                if (player_hp < 1)
                {
                    //lose
                    start_btn.Visible = false;
                    confirm_btn.Visible = false;
                    add_btn.Visible = false;
                    delete_btn.Visible = false;
                    listBox1.Visible = false;
                    listBox2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    attack.Enabled = false;
                    tableLayoutPanel1.Visible = false;
                    this.Controls.Clear();
                    System.Windows.Forms.Label lbl1 = temp_panel.Controls[0] as System.Windows.Forms.Label;
                    lbl1.Location = new Point(10, 10);
                    lbl1.Size = new Size(200, 30);
                    lbl1.Text = "YOU LOSE";
                    lbl1.Visible = true;
                    lbl1.BringToFront();

                }
            }
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is FlowLayoutPanel)
                {

                    int character_panelCenterX = control.Location.X;
                    int character_panelCenterY = control.Location.Y;
                    if (Math.Abs(panelCenterX - character_panelCenterX) <= 3 && Math.Abs(panelCenterY - character_panelCenterY) <= 25)
                    {
                        timer.Stop();
                        fight.Tag = new Tuple<Control, FlowLayoutPanel, System.Windows.Forms.Timer>(control, panel, timer);
                        fight.Start();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count ++ ;
            if (count >= 99)
            {
                count = 99;
            }
            label2.Text = count.ToString();   
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            FlowLayoutPanel temp_panel = timer.Tag as FlowLayoutPanel;
            System.Windows.Forms.Label lbl1 = temp_panel.Controls[0] as System.Windows.Forms.Label;
            Character character = new Character(lbl1.Text);
            System.Windows.Forms.Label cd=temp_panel.Controls[2] as System.Windows.Forms.Label;

            if (int.Parse(cd.Text) >0)
            {
                int temp = int.Parse(cd.Text);
                temp--;
                cd.Text = temp.ToString();
            }
            else
            {
                temp_panel.BackColor = Color.LightGreen;
                temp_panel.MouseClick -= new MouseEventHandler(Panel_MouseClick);
                cd.Text = "0";
            }
        }

        private Character GetCharacter(string name)
        {
            foreach (Character character in characters) {
                if(character.GetName().Equals(name)) {
                    return character; 
                }
            }
            return null;
        }

        private Anime GetAnime(string name)
        {
            foreach (Anime anime in animes)
            {
                if (anime.GetName().Equals(name))
                {
                    return anime;
                }
            }
            return null;
        }


    }
}
