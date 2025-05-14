using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_7_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter= "Text Files(*.txt)|*.txt|MyText Files(*.mytext)|*.mytext";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr=new StreamReader(openFileDialog1.FileName);
                Form1 form1 = new Form1();
                form1.Get_File(openFileDialog1.FileName);
                if (openFileDialog1.FileName.Contains(".mytext"))
                {
                    string temp = sr.ReadLine();
                    string[] temp_font=temp.Split(',');
                    form1.Get_Font(temp_font[0]);

                    string temp2 = sr.ReadLine();
                    string[] tempArray = temp2.Split(',');
                    FontStyle[] temp3 = new FontStyle[tempArray.Length];

                    for (int i = 0; i < tempArray.Length; i++)
                    {
                        temp3[i] = (FontStyle)Enum.Parse(typeof(FontStyle), tempArray[i]);
                    }
                    form1.Get_Style(temp3);
                    form1.Get_big(sr.ReadLine());
                    form1.Get_Color(sr.ReadLine());
                }
                while (sr.Peek()!=-1 )
                {
                    form1.Get_Text(sr.ReadLine());
                }
                form1.Text = openFileDialog1.FileName;
                form1.Show();
                sr.Close();
            }
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
