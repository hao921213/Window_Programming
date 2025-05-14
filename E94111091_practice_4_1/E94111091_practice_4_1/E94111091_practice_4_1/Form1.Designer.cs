namespace E94111091_practice_4_1
{
    partial class Form1
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
            this.chat = new System.Windows.Forms.TabControl();
            this.first_chat = new System.Windows.Forms.TabPage();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.second_chat = new System.Windows.Forms.TabPage();
            this.lbl16 = new System.Windows.Forms.Label();
            this.lbl15 = new System.Windows.Forms.Label();
            this.lbl14 = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.textbox = new System.Windows.Forms.TextBox();
            this.sent_btn = new System.Windows.Forms.Button();
            this.chat.SuspendLayout();
            this.first_chat.SuspendLayout();
            this.second_chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // chat
            // 
            this.chat.Controls.Add(this.first_chat);
            this.chat.Controls.Add(this.second_chat);
            this.chat.Location = new System.Drawing.Point(-6, 12);
            this.chat.Name = "chat";
            this.chat.SelectedIndex = 0;
            this.chat.Size = new System.Drawing.Size(865, 468);
            this.chat.TabIndex = 0;
            this.chat.SelectedIndexChanged += new System.EventHandler(this.chat_SelectedIndexChanged);
            // 
            // first_chat
            // 
            this.first_chat.Controls.Add(this.lbl8);
            this.first_chat.Controls.Add(this.lbl7);
            this.first_chat.Controls.Add(this.lbl6);
            this.first_chat.Controls.Add(this.lbl5);
            this.first_chat.Controls.Add(this.lbl4);
            this.first_chat.Controls.Add(this.lbl3);
            this.first_chat.Controls.Add(this.lbl2);
            this.first_chat.Controls.Add(this.lbl1);
            this.first_chat.Location = new System.Drawing.Point(8, 39);
            this.first_chat.Name = "first_chat";
            this.first_chat.Padding = new System.Windows.Forms.Padding(3);
            this.first_chat.Size = new System.Drawing.Size(849, 421);
            this.first_chat.TabIndex = 0;
            this.first_chat.Text = "斗哥";
            this.first_chat.UseVisualStyleBackColor = true;
            this.first_chat.DoubleClick += new System.EventHandler(this.first_chat_DoubleClick);
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Location = new System.Drawing.Point(550, 350);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(0, 24);
            this.lbl8.TabIndex = 7;
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(57, 323);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(0, 24);
            this.lbl7.TabIndex = 6;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(550, 253);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(0, 24);
            this.lbl6.TabIndex = 5;
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(57, 223);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(0, 24);
            this.lbl5.TabIndex = 4;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(550, 163);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(0, 24);
            this.lbl4.TabIndex = 3;
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(57, 130);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 24);
            this.lbl3.TabIndex = 2;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(550, 57);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 24);
            this.lbl2.TabIndex = 1;
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(57, 37);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 24);
            this.lbl1.TabIndex = 0;
            // 
            // second_chat
            // 
            this.second_chat.Controls.Add(this.lbl16);
            this.second_chat.Controls.Add(this.lbl15);
            this.second_chat.Controls.Add(this.lbl14);
            this.second_chat.Controls.Add(this.lbl13);
            this.second_chat.Controls.Add(this.lbl12);
            this.second_chat.Controls.Add(this.lbl11);
            this.second_chat.Controls.Add(this.lbl10);
            this.second_chat.Controls.Add(this.lbl9);
            this.second_chat.Location = new System.Drawing.Point(8, 39);
            this.second_chat.Name = "second_chat";
            this.second_chat.Padding = new System.Windows.Forms.Padding(3);
            this.second_chat.Size = new System.Drawing.Size(849, 421);
            this.second_chat.TabIndex = 1;
            this.second_chat.Text = "楷特";
            this.second_chat.UseVisualStyleBackColor = true;
            this.second_chat.DoubleClick += new System.EventHandler(this.second_chat_DoubleClick);
            // 
            // lbl16
            // 
            this.lbl16.AutoSize = true;
            this.lbl16.Location = new System.Drawing.Point(536, 327);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(0, 24);
            this.lbl16.TabIndex = 15;
            this.lbl16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl15
            // 
            this.lbl15.AutoSize = true;
            this.lbl15.Location = new System.Drawing.Point(53, 360);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(0, 24);
            this.lbl15.TabIndex = 14;
            // 
            // lbl14
            // 
            this.lbl14.AutoSize = true;
            this.lbl14.Location = new System.Drawing.Point(536, 232);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(0, 24);
            this.lbl14.TabIndex = 13;
            this.lbl14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl14.Click += new System.EventHandler(this.lbl14_Click);
            // 
            // lbl13
            // 
            this.lbl13.AutoSize = true;
            this.lbl13.Location = new System.Drawing.Point(53, 268);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(0, 24);
            this.lbl13.TabIndex = 12;
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.Location = new System.Drawing.Point(536, 134);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(0, 24);
            this.lbl12.TabIndex = 11;
            this.lbl12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(53, 171);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(0, 24);
            this.lbl11.TabIndex = 10;
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Location = new System.Drawing.Point(536, 46);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(0, 24);
            this.lbl10.TabIndex = 9;
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Location = new System.Drawing.Point(53, 70);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(0, 24);
            this.lbl9.TabIndex = 8;
            // 
            // textbox
            // 
            this.textbox.Enabled = false;
            this.textbox.Location = new System.Drawing.Point(14, 505);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(692, 36);
            this.textbox.TabIndex = 1;
            // 
            // sent_btn
            // 
            this.sent_btn.Enabled = false;
            this.sent_btn.Location = new System.Drawing.Point(734, 505);
            this.sent_btn.Name = "sent_btn";
            this.sent_btn.Size = new System.Drawing.Size(112, 41);
            this.sent_btn.TabIndex = 2;
            this.sent_btn.Text = "發送";
            this.sent_btn.UseVisualStyleBackColor = true;
            this.sent_btn.Click += new System.EventHandler(this.sent_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 558);
            this.Controls.Add(this.sent_btn);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.chat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.chat.ResumeLayout(false);
            this.first_chat.ResumeLayout(false);
            this.first_chat.PerformLayout();
            this.second_chat.ResumeLayout(false);
            this.second_chat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl chat;
        private System.Windows.Forms.TabPage first_chat;
        private System.Windows.Forms.TabPage second_chat;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.Button sent_btn;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl9;
    }
}

