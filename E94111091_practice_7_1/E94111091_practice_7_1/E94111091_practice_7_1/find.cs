using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_7_1
{
    public partial class find : Form
    {
        string find_string = "";
        int has_find = 0;
        Form1 form1;
        public find(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            has_find = 0;
            if (textBox1.Text=="") {
                MessageBox.Show("請輸入要搜尋的文字","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                find_string = textBox1.Text;
                form1.Get_find_string(find_string);
                if (has_find == 0)
                {
                    MessageBox.Show("已找不到更多匹配項目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        public void Set_has_find()
        {
            has_find = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Get_change_string(textBox2.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            form1.Get_change_all_string(textBox2.Text, textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
