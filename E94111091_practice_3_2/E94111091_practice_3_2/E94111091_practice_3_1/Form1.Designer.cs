namespace E94111091_practice_3_1
{
    partial class 角落生物商店
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.open_btn = new System.Windows.Forms.Button();
            this.account_lbl = new System.Windows.Forms.Label();
            this.pw_lbl = new System.Windows.Forms.Label();
            this.account_input = new System.Windows.Forms.TextBox();
            this.pw_input = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.append_btn = new System.Windows.Forms.Button();
            this.show_btn = new System.Windows.Forms.Button();
            this.append_account_btn = new System.Windows.Forms.Button();
            this.log_out_btn = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.amount_input = new System.Windows.Forms.TextBox();
            this.pg_btn = new System.Windows.Forms.Button();
            this.pk_btn = new System.Windows.Forms.Button();
            this.shrimp_btn = new System.Windows.Forms.Button();
            this.send_btn = new System.Windows.Forms.Button();
            this.add_account_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title_textBox
            // 
            this.title_textBox.Enabled = false;
            this.title_textBox.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.title_textBox.Location = new System.Drawing.Point(143, 12);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(593, 43);
            this.title_textBox.TabIndex = 0;
            this.title_textBox.Text = "歡迎來到角落生物商店";
            this.title_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // open_btn
            // 
            this.open_btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.open_btn.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.open_btn.Location = new System.Drawing.Point(282, 227);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(268, 127);
            this.open_btn.TabIndex = 1;
            this.open_btn.Text = "點擊開店";
            this.open_btn.UseVisualStyleBackColor = false;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // account_lbl
            // 
            this.account_lbl.AutoSize = true;
            this.account_lbl.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.account_lbl.Location = new System.Drawing.Point(137, 140);
            this.account_lbl.Name = "account_lbl";
            this.account_lbl.Size = new System.Drawing.Size(62, 31);
            this.account_lbl.TabIndex = 2;
            this.account_lbl.Text = "帳號";
            this.account_lbl.Visible = false;
            // 
            // pw_lbl
            // 
            this.pw_lbl.AutoSize = true;
            this.pw_lbl.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pw_lbl.Location = new System.Drawing.Point(139, 253);
            this.pw_lbl.Name = "pw_lbl";
            this.pw_lbl.Size = new System.Drawing.Size(62, 31);
            this.pw_lbl.TabIndex = 3;
            this.pw_lbl.Text = "密碼";
            this.pw_lbl.Visible = false;
            // 
            // account_input
            // 
            this.account_input.Location = new System.Drawing.Point(229, 135);
            this.account_input.Name = "account_input";
            this.account_input.Size = new System.Drawing.Size(321, 36);
            this.account_input.TabIndex = 4;
            this.account_input.Visible = false;
            // 
            // pw_input
            // 
            this.pw_input.Location = new System.Drawing.Point(229, 253);
            this.pw_input.Name = "pw_input";
            this.pw_input.PasswordChar = '*';
            this.pw_input.Size = new System.Drawing.Size(321, 36);
            this.pw_input.TabIndex = 5;
            this.pw_input.Visible = false;
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.login_btn.Location = new System.Drawing.Point(602, 135);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(112, 154);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "登入";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Visible = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // append_btn
            // 
            this.append_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.append_btn.Location = new System.Drawing.Point(12, 71);
            this.append_btn.Name = "append_btn";
            this.append_btn.Size = new System.Drawing.Size(100, 100);
            this.append_btn.TabIndex = 7;
            this.append_btn.Text = "新增\r\n訂單";
            this.append_btn.UseVisualStyleBackColor = true;
            this.append_btn.Visible = false;
            this.append_btn.Click += new System.EventHandler(this.append_btn_Click);
            // 
            // show_btn
            // 
            this.show_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.show_btn.Location = new System.Drawing.Point(12, 182);
            this.show_btn.Name = "show_btn";
            this.show_btn.Size = new System.Drawing.Size(100, 100);
            this.show_btn.TabIndex = 8;
            this.show_btn.Text = "列出\r\n訂單";
            this.show_btn.UseVisualStyleBackColor = true;
            this.show_btn.Visible = false;
            this.show_btn.Click += new System.EventHandler(this.show_btn_Click);
            // 
            // append_account_btn
            // 
            this.append_account_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.append_account_btn.Location = new System.Drawing.Point(12, 288);
            this.append_account_btn.Name = "append_account_btn";
            this.append_account_btn.Size = new System.Drawing.Size(100, 100);
            this.append_account_btn.TabIndex = 9;
            this.append_account_btn.Text = "新增\r\n帳號\r\n";
            this.append_account_btn.UseVisualStyleBackColor = true;
            this.append_account_btn.Visible = false;
            this.append_account_btn.Click += new System.EventHandler(this.append_account_btn_Click);
            // 
            // log_out_btn
            // 
            this.log_out_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.log_out_btn.Location = new System.Drawing.Point(12, 394);
            this.log_out_btn.Name = "log_out_btn";
            this.log_out_btn.Size = new System.Drawing.Size(100, 100);
            this.log_out_btn.TabIndex = 10;
            this.log_out_btn.Text = "登出";
            this.log_out_btn.UseVisualStyleBackColor = true;
            this.log_out_btn.Visible = false;
            this.log_out_btn.Click += new System.EventHandler(this.log_out_btn_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listBox.Font = new System.Drawing.Font("微軟正黑體", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 26;
            this.listBox.Location = new System.Drawing.Point(143, 71);
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(593, 420);
            this.listBox.TabIndex = 11;
            this.listBox.Visible = false;
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.Location = new System.Drawing.Point(141, 89);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(130, 24);
            this.amount_lbl.TabIndex = 12;
            this.amount_lbl.Text = "請輸入數量";
            this.amount_lbl.Visible = false;
            // 
            // amount_input
            // 
            this.amount_input.Location = new System.Drawing.Point(282, 86);
            this.amount_input.Name = "amount_input";
            this.amount_input.Size = new System.Drawing.Size(432, 36);
            this.amount_input.TabIndex = 13;
            this.amount_input.Visible = false;
            // 
            // pg_btn
            // 
            this.pg_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pg_btn.Location = new System.Drawing.Point(145, 162);
            this.pg_btn.Name = "pg_btn";
            this.pg_btn.Size = new System.Drawing.Size(152, 127);
            this.pg_btn.TabIndex = 14;
            this.pg_btn.Text = "企鵝";
            this.pg_btn.UseVisualStyleBackColor = true;
            this.pg_btn.Visible = false;
            this.pg_btn.Click += new System.EventHandler(this.pg_btn_Click);
            // 
            // pk_btn
            // 
            this.pk_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pk_btn.Location = new System.Drawing.Point(352, 162);
            this.pk_btn.Name = "pk_btn";
            this.pk_btn.Size = new System.Drawing.Size(154, 127);
            this.pk_btn.TabIndex = 15;
            this.pk_btn.Text = "炸豬排";
            this.pk_btn.UseVisualStyleBackColor = true;
            this.pk_btn.Visible = false;
            this.pk_btn.Click += new System.EventHandler(this.pk_btn_Click);
            // 
            // shrimp_btn
            // 
            this.shrimp_btn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.shrimp_btn.Location = new System.Drawing.Point(570, 162);
            this.shrimp_btn.Name = "shrimp_btn";
            this.shrimp_btn.Size = new System.Drawing.Size(144, 127);
            this.shrimp_btn.TabIndex = 16;
            this.shrimp_btn.Text = "炸蝦";
            this.shrimp_btn.UseVisualStyleBackColor = true;
            this.shrimp_btn.Visible = false;
            this.shrimp_btn.Click += new System.EventHandler(this.shrimp_btn_Click);
            // 
            // send_btn
            // 
            this.send_btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.send_btn.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.send_btn.Location = new System.Drawing.Point(252, 374);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(341, 109);
            this.send_btn.TabIndex = 17;
            this.send_btn.Text = "送出訂單";
            this.send_btn.UseVisualStyleBackColor = false;
            this.send_btn.Visible = false;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // add_account_btn
            // 
            this.add_account_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.add_account_btn.Location = new System.Drawing.Point(602, 135);
            this.add_account_btn.Name = "add_account_btn";
            this.add_account_btn.Size = new System.Drawing.Size(112, 129);
            this.add_account_btn.TabIndex = 18;
            this.add_account_btn.Text = "新增帳號";
            this.add_account_btn.UseVisualStyleBackColor = true;
            this.add_account_btn.Visible = false;
            this.add_account_btn.Click += new System.EventHandler(this.add_account_btn_Click);
            // 
            // 角落生物商店
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 527);
            this.Controls.Add(this.add_account_btn);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.shrimp_btn);
            this.Controls.Add(this.pk_btn);
            this.Controls.Add(this.pg_btn);
            this.Controls.Add(this.amount_input);
            this.Controls.Add(this.amount_lbl);
            this.Controls.Add(this.log_out_btn);
            this.Controls.Add(this.append_account_btn);
            this.Controls.Add(this.show_btn);
            this.Controls.Add(this.append_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.pw_input);
            this.Controls.Add(this.account_input);
            this.Controls.Add(this.pw_lbl);
            this.Controls.Add(this.account_lbl);
            this.Controls.Add(this.open_btn);
            this.Controls.Add(this.title_textBox);
            this.Controls.Add(this.listBox);
            this.Name = "角落生物商店";
            this.Text = "角落生物商店";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Label account_lbl;
        private System.Windows.Forms.Label pw_lbl;
        private System.Windows.Forms.TextBox account_input;
        private System.Windows.Forms.TextBox pw_input;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button append_btn;
        private System.Windows.Forms.Button show_btn;
        private System.Windows.Forms.Button append_account_btn;
        private System.Windows.Forms.Button log_out_btn;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label amount_lbl;
        private System.Windows.Forms.TextBox amount_input;
        private System.Windows.Forms.Button pg_btn;
        private System.Windows.Forms.Button pk_btn;
        private System.Windows.Forms.Button shrimp_btn;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Button add_account_btn;
    }
}

