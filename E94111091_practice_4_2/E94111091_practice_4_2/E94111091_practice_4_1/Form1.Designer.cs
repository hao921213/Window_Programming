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
            this.second_chat = new System.Windows.Forms.TabPage();
            this.textbox = new System.Windows.Forms.TextBox();
            this.sent_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.first_chat.Location = new System.Drawing.Point(8, 39);
            this.first_chat.Name = "first_chat";
            this.first_chat.Padding = new System.Windows.Forms.Padding(3);
            this.first_chat.Size = new System.Drawing.Size(849, 421);
            this.first_chat.TabIndex = 0;
            this.first_chat.Text = "斗哥";
            this.first_chat.UseVisualStyleBackColor = true;
            this.first_chat.DoubleClick += new System.EventHandler(this.first_chat_DoubleClick);
            // 
            // second_chat
            // 
            this.second_chat.Location = new System.Drawing.Point(8, 39);
            this.second_chat.Name = "second_chat";
            this.second_chat.Padding = new System.Windows.Forms.Padding(3);
            this.second_chat.Size = new System.Drawing.Size(849, 421);
            this.second_chat.TabIndex = 1;
            this.second_chat.Text = "楷特";
            this.second_chat.UseVisualStyleBackColor = true;
            this.second_chat.DoubleClick += new System.EventHandler(this.second_chat_DoubleClick);
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(14, 505);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(692, 36);
            this.textbox.TabIndex = 1;
            // 
            // sent_btn
            // 
            this.sent_btn.Location = new System.Drawing.Point(747, 505);
            this.sent_btn.Name = "sent_btn";
            this.sent_btn.Size = new System.Drawing.Size(112, 41);
            this.sent_btn.TabIndex = 2;
            this.sent_btn.Text = "發送";
            this.sent_btn.UseVisualStyleBackColor = true;
            this.sent_btn.Click += new System.EventHandler(this.sent_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(703, 505);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 41);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 558);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sent_btn);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.chat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.chat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl chat;
        private System.Windows.Forms.TabPage first_chat;
        private System.Windows.Forms.TabPage second_chat;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.Button sent_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

