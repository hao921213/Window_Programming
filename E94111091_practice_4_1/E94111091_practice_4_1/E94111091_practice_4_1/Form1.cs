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
    public partial class Form1 : Form
    {
        Form2 form;
        int chang_color1 = 0;
        int chang_color2 = 0;
        int count = 0;
        int check = 1;


        string[] chat1 = new string[4];
        string[] chat2 = new string[4];

        public Form1()
        {
            InitializeComponent();
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

        private void sent_btn_Click(object sender, EventArgs e)
        {
            string message=textbox.Text;
            Message("楷特:" + message, "斗哥:汪!");
            if (count <= 3)
            {

                lbl1.Text =  chat1[0];
                lbl3.Text = chat1[1];
                lbl5.Text =  chat1[2];
                lbl7.Text = chat1[3];

                lbl10.Text = chat1[0];
                lbl12.Text = chat1[1];
                lbl14.Text = chat1[2];
                lbl16.Text = chat1[3];

                lbl2.Text = chat2[0];
                lbl4.Text = chat2[1];
                lbl6.Text = chat2[2];
                lbl8.Text = chat2[3];

                lbl9.Text = chat2[0];
                lbl11.Text = chat2[1];
                lbl13.Text = chat2[2];
                lbl15.Text = chat2[3];

            }
            else
            {
                lbl1.Text =  chat1[(count - 3) % 4];
                lbl3.Text = chat1[(count - 2) % 4];
                lbl5.Text =  chat1[(count-1)%4];
                lbl7.Text = chat1[count%4];

                lbl10.Text = chat1[(count - 3) % 4];
                lbl12.Text = chat1[(count - 2) % 4];
                lbl14.Text = chat1[(count - 1) % 4];
                lbl16.Text = chat1[count % 4];

                lbl2.Text = chat2[0];
                lbl4.Text = chat2[1];
                lbl6.Text = chat2[2];
                lbl8.Text = chat2[3];

                lbl9.Text = chat2[0];
                lbl11.Text = chat2[1];
                lbl13.Text = chat2[2];
                lbl15.Text = chat2[3];
            }

            count++;
            textbox.Clear();
        }

        public void Message(string temp1,string temp2)
        {
            chat1[count%4]=temp1;
            chat2[count%4] =temp2;
        }

        private void chat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check % 2 == 0)
            {
                textbox.Enabled = false;
                sent_btn.Enabled = false;
            }
            else
            {
                textbox.Enabled = true;
                sent_btn.Enabled = true;
            }
            check++;
        }

        private void lbl14_Click(object sender, EventArgs e)
        {

        }
    }
}
