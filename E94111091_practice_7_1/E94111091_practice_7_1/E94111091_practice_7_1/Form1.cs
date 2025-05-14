using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace E94111091_practice_7_1
{
    public partial class Form1 : Form
    {
        string temp;
        string file_path="";
        string color = "";
        string font = "";
        string font_style = "";
        string big = "";
        string undo_text = "";
        Color undo_color ;
        Font undo_font ;
        int change = -1;
        string redo_text = "";
        int redo = 0;
        int time = 0;
        int unsave = 0;
        string find_string = "";
        find find;
        int index = 0;
        string change_string = "";
        string[] text=new string[2];
        int top = 0;
        int redo_index = 0;
        FontStyle[] style;
        FontStyle combine;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (style != null)
            {
                foreach (FontStyle style in style)
                {
                    combine |= style; // 使用位運算符合併 FontStyle
                }
            }
            if (font != "")
            {
                textBox1.Font = new Font(font,float.Parse(big),combine);
            }
            if (color != "")
            {
                textBox1.ForeColor = ColorTranslator.FromHtml(color);
            }
            text[top]= textBox1.Text;
            undo_text = textBox1.Text;
            undo_font=textBox1.Font;
            undo_color =textBox1.ForeColor;
            label1.Text = "0";
            auto_save.Stop();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (unsave == 1)
            {
                result=MessageBox.Show("尚未儲存是否關閉視窗","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void 字型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo_font= textBox1.Font;
            change = 1;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }

        }

        private void 顏色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo_color = textBox1.ForeColor;
            change = 2;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void 剪下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = 0;
            start = textBox1.SelectionStart;
            temp = textBox1.SelectedText;
            redo_text = temp;
            undo_text = textBox1.Text;
            change = 0;
            redo = 0;
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart,textBox1.SelectionLength);
            textBox1.SelectionStart = start;
            text[++top % 2] = textBox1.Text;
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = 0;
            start = textBox1.SelectionStart;
            temp =textBox1.SelectedText ;
            redo = 0;
            textBox1.SelectionStart = start;
            redo_text = temp;
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = 0;
            start = textBox1.SelectionStart;
            undo_text = textBox1.Text;
            redo = 1;
            change = 0;
            if (temp != "")
            {
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, temp);
            }
            redo_index=start;
            textBox1.SelectionStart = start;
            text[++top % 2] = textBox1.Text;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {//儲存
            if (file_path == "")
            {
                saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|MyText Files(*.mytext)|*.mytext";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = File.Create(saveFileDialog1.FileName);
                    StreamWriter sw = new StreamWriter(file);
                    file_path = saveFileDialog1.FileName;
                    if (file_path.Contains("mytext"))
                    {
                        sw.WriteLine(textBox1.Font);
                        sw.WriteLine(textBox1.Font.Style);
                        sw.WriteLine(textBox1.Font.Size);
                        sw.WriteLine(textBox1.ForeColor.ToArgb());
                    }
                    sw.Write(textBox1.Text.ToString());
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(file_path, false);
                if (file_path.Contains("mytext"))
                {
                    sw.WriteLine(textBox1.Font);
                    sw.WriteLine(textBox1.Font.Style);
                    sw.WriteLine(textBox1.Font.Size);
                    sw.WriteLine(textBox1.ForeColor.ToArgb());
                }
                sw.Write(textBox1.Text.ToString());
                sw.Close();
            }
            time = 0;
            label1.Text = time.ToString();
            this.Text = file_path;
            unsave = 0;
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|MyText Files(*.mytext)|*.mytext";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.CheckFileExists)
                {
                    FileStream file = File.Create(saveFileDialog1.FileName);
                    StreamWriter sw = new StreamWriter(file);
                    file_path= saveFileDialog1.FileName;
                    if (file_path.Contains("mytext"))
                    {
                        sw.WriteLine(textBox1.Font);
                        sw.WriteLine(textBox1.Font.Style);
                        sw.WriteLine(textBox1.Font.Size);
                        sw.WriteLine(textBox1.ForeColor.ToArgb());
                    }
                    sw.Write(textBox1.Text.ToString());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,false);
                    sw.Write(textBox1.Text.ToString());
                    sw.Close();
                }
                time = 0;
                label1.Text = time.ToString();
                this.Text = file_path;
            }
            unsave = 0;
        }

        public void Get_Text(string text)
        {
            textBox1.Text += text;
        }

        public void Get_File(string path)
        {
            file_path = path;
        }

        public void Get_Font(string font)
        {
            this.font = font;
        }

        public void Get_Style(FontStyle[] style)
        {
            this.style = style;
        }
        public void Get_Color(string color)
        {
            this.color= color;
        }
        public void Get_big(string big)
        {
            this.big = big;
        }
        public void Get_find_string(string find_string)
        {
            this.find_string = find_string;
            if (index<textBox1.Text.Length && (index = textBox1.Text.IndexOf(find_string, index)) != -1)
            {
                textBox1.Select(index, find_string.Length);
                index += 1;
                textBox1.Focus(); 
                find.Set_has_find();
            }
            else
            {
                index = 0;
            }
            change = 0;
        }

        public void Get_change_string(string change_string)
        {
            if (change == 0 && textBox1.SelectionLength > 0)
            {
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(start, textBox1.SelectionLength);
                textBox1.Text = textBox1.Text.Insert(start, change_string);
                textBox1.Select(start, change_string.Length);
                textBox1.Focus(); 
                change = 1;
            }
            text[++top % 2] = textBox1.Text;
        }

        public void Get_change_all_string(string change_all_string,string find_string)
        {
            int index = 0;
            while(index < textBox1.Text.Length && (index = textBox1.Text.IndexOf(find_string, index)) != -1)
            {
                textBox1.Select(index, find_string.Length);
                textBox1.Text = textBox1.Text.Remove(index, textBox1.SelectionLength);
                textBox1.Text = textBox1.Text.Insert(index, change_all_string);
                index += change_all_string.Length;
                textBox1.Focus();
            }
            text[++top % 2] = textBox1.Text;
        }


        private void 字數統計ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("字數:"+textBox1.Text.Length);
        }

        private void 尋找取代ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            find = new find(this);
            index = 0;
            find.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            auto_save.Start();
            unsave = 1;
            time = 0;
            label1.Text=time.ToString();

            if (textBox1.Text != undo_text)
            {
                change = 0;
            }
            text[++top % 2] = textBox1.Text;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = 0;
            start = textBox1.SelectionStart;
            switch (change)
            {
                case 0:
                    textBox1.Text = text[--top % 2] ;
                    break;
                case 1:
                    textBox1.Font = undo_font;
                    break;
                case 2:
                    textBox1.ForeColor = undo_color;
                    break;
                default:
                    break;
            }
            textBox1.SelectionStart = start;
            change = -1;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = 0;
            start = textBox1.SelectionStart;
            if (redo == 1)
            {
                textBox1.Text = textBox1.Text.Insert(redo_index, temp);
            }
            change = 0;
            textBox1.SelectionStart=start; 
            text[++top % 2] = textBox1.Text;
        }

        private void auto_save_Tick(object sender, EventArgs e)
        {
            time++;
            if (time >= 60)
            {
                if (file_path != "")
                {
                    StreamWriter sw = new StreamWriter(file_path,false);
                    sw.Write(textBox1.Text.ToString());
                    sw.Close();
                    unsave = 0;
                }
                time = 0;
            }
            label1.Text=time.ToString();
        }
    }
}
