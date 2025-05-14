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
    public partial class Form2 : Form
    {
        Form1 form;
        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            changcolor();
        }

        private void color_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.form1.Show();

        }

        private void Form2_Click(object sender, EventArgs e)
        {
            changcolor();
        }

        public void changcolor()
        {
            Random random = new Random();
            this.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            form.SetNewColor(this.BackColor);
        }


    }
}
