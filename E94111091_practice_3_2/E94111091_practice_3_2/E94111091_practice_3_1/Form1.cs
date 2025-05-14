using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_practice_3_1
{
    public partial class 角落生物商店 : Form
    {
        public int lable = 1000;
        public string[,] buy_record = new string[1000, 3];
        public string[] buyer= new string[1000];
        public string[] pw= new string[1000];
        public int[] buy_index= new int[1000];
        public string temp_buyer ;
        public int buyer_id = 0;
        public int check = 0;


        public 角落生物商店()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buyer[buyer_id] = "admin";
            pw[buyer_id] = "admin";
            buyer_id++;
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

            if(buyer.Contains(account) && password==pw[Array.IndexOf(buyer,account)])
            {
                temp_buyer = account;
                title_textBox.Text = "歡迎登入!，" + temp_buyer;
                
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

        private string purchase="";

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
            pg_btn.Text = "企鵝(已選擇)";
            shrimp_btn.Text = "炸蝦";
            pk_btn.Text = "炸豬排";
        }

        private void pk_btn_Click(object sender, EventArgs e)
        {
            Set_purchase("炸豬排");
            pk_btn.Text = "炸豬排(已選擇)";
            pg_btn.Text = "企鵝";
            shrimp_btn.Text = "炸蝦";
        }

        private void shrimp_btn_Click(object sender, EventArgs e)
        {
            Set_purchase("炸蝦");
            shrimp_btn.Text = "炸蝦(已選擇)";
            pk_btn.Text = "炸豬排";
            pg_btn.Text = "企鵝";
        }

        private void send_btn_Click(object sender, EventArgs e)
        {

            if (check==0)
            {

                try
                {
                    if (int.Parse(amount_input.Text) > 0)
                    {
                        check = 1;
                    }
                    else
                    {
                        title_textBox.Text = "請輸入正整數";
                        amount_input.Clear();
                    }
                }
                catch
                {
                    title_textBox.Text = "請輸入正整數";
                    amount_input.Clear();
                    check = 0;

                    pg_btn.Text = "企鵝";
                    shrimp_btn.Text = "炸蝦";
                    pk_btn.Text = "炸豬排";
                    Set_purchase("");
                }

                if (Get_purchase() == "")
                {
                    title_textBox.Text = "請選擇商品";
                    check = 0;
                }

            }

            if (check == 1)
            {
                title_textBox.Text = "新增訂單成功，訂單編號" + lable;
                buy_record[lable - 1000, 0] = amount_input.Text;
                buy_record[lable - 1000, 1] = purchase;
                buy_record[lable - 1000, 2] = temp_buyer;

                Set_purchase("");
                lable++;
                buy_index[Array.IndexOf(buyer, temp_buyer)]++;

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

                pg_btn.Text = "企鵝";
                shrimp_btn.Text = "炸蝦";
                pk_btn.Text = "炸豬排";

                amount_input.Clear();
                check = 0;
            }


        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "顯示所有訂單";
            for (int i = 0; i < lable-1000 ; i++)
            {
                listBox.Items.Add($"訂單編號{1000 + i}:購買了{buy_record[i,0]}個{buy_record[i,1]}，由{buy_record[i, 2]}新增");
            }
        }

        private void append_account_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "請輸入要新增的帳號與密碼";
            append_btn.Visible = false;
            append_account_btn.Visible = false;
            show_btn.Visible = false;
            log_out_btn.Visible = false;
            listBox.Visible = false;

            account_input.Visible = true;
            account_lbl.Visible = true;
            pw_input.Visible = true;
            pw_lbl.Visible = true;
            add_account_btn.Visible = true;

            listBox.Items.Clear();


        }

        private void log_out_btn_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "歡迎光臨，請登入!";
            account_input.Visible = true;
            account_lbl.Visible = true;
            pw_input.Visible = true;
            pw_lbl.Visible = true;
            login_btn.Visible = true;

            append_btn.Visible = false;
            append_account_btn.Visible = false;
            show_btn.Visible = false;
            log_out_btn.Visible = false;
            listBox.Visible = false;

            listBox.Items.Clear();
        }

        private void add_account_btn_Click(object sender, EventArgs e)
        {
            if (buyer.Contains(account_input.Text))
            {
                title_textBox.Text = "此使用者已存在";
                account_input.Clear();
                pw_input.Clear();
                account_input.Focus();
            }
            else
            {
                buyer[buyer_id] = account_input.Text;
                pw[buyer_id] = pw_input.Text;
                buyer_id++;
                temp_buyer = account_input.Text;

                title_textBox.Text = "歡迎登入!，" + temp_buyer;
                account_input.Visible = false;
                account_lbl.Visible = false;
                pw_input.Visible = false;
                pw_lbl.Visible = false;
                add_account_btn.Visible = false;

                append_btn.Visible = true;
                append_account_btn.Visible = true;
                show_btn.Visible = true;
                log_out_btn.Visible = true;
                listBox.Visible = true;

                account_input.Clear();
                pw_input.Clear();
            }


        }
    }
}
