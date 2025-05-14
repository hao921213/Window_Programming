using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_3_1
{
    public partial class 角落生物商店 : Form
    {
        public int lable = 1000;
        public int[] buy_amount= new int[1000];
        public string[] buy= new string[1000];
        public int index = 0;
        public 角落生物商店()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "歡迎光臨，請登入!";
            open_btn.Visible = false;
            account_input.Visible = true;
            account_lbl.Visible = true;
            pw_input.Visible = true;
            pw_lbl.Visible = true;
            login_btn.Visible = true;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string account=account_input.Text;
            string password=pw_input.Text;

            if(account=="admin" && password == "admin")
            {
                title_textBox.Text = "歡迎登入!，" + account;
                account_input.Visible = false;
                account_lbl.Visible = false;
                pw_input.Visible = false;
                pw_lbl.Visible = false;
                login_btn.Visible = false ;

                append_btn.Visible = true;
                append_account_btn.Visible = true;
                show_btn.Visible = true;
                log_out_btn.Visible = true;
                listBox.Visible = true;

                account_input.Clear();
                pw_input.Clear();

            }
            else
            {
                title_textBox.Text = "帳號或密碼錯誤，請重新輸入";
                account_input.Clear();
                pw_input.Clear();
                account_input.Focus();
            }
        }

        private void append_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "輸入完數量後，點擊對應的商品按鈕，並按送出";
            append_btn.Visible = false;
            append_account_btn.Visible = false;
            show_btn.Visible = false;
            log_out_btn.Visible = false;
            listBox.Visible = false;

            amount_input.Visible= true;
            amount_lbl.Visible = true;
            pg_btn.Visible = true;
            pk_btn.Visible = true;
            shrimp_btn.Visible = true;
            send_btn.Visible = true;

            listBox.Items.Clear();

        }

        private string purchase;

        public void Set_purchase(string tpurchase)
        {
            purchase=tpurchase;
        }

        public string Get_purchase()
        {
            return purchase;
        }

        private void pg_btn_Click(object sender, EventArgs e)
        {
            Set_purchase("企鵝");
        }

        private void pk_btn_Click(object sender, EventArgs e)
        {
            Set_purchase("炸豬排");
        }

        private void shrimp_btn_Click(object sender, EventArgs e)
        {
            Set_purchase("炸蝦");
        }



        private void send_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "新增訂單成功，訂單編號"+lable;
            buy_amount[index] = int.Parse(amount_input.Text);
            buy[index]=purchase;

            Set_purchase("");
            lable++;
            index++;

            append_btn.Visible = true;
            append_account_btn.Visible = true;
            show_btn.Visible = true;
            log_out_btn.Visible = true;
            listBox.Visible = true;

            amount_input.Visible = false;
            amount_lbl.Visible = false;
            pg_btn.Visible = false;
            pk_btn.Visible = false;
            shrimp_btn.Visible = false;
            send_btn.Visible = false;

            amount_input.Clear();
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "顯示所有訂單";
            for (int i = 0; i < index ; i++)
            {
                listBox.Items.Add($"訂單編號{1000 + i}:購買了{buy_amount[i]}個{buy[i]}");
            }
        }
    }
}
