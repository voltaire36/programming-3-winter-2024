namespace practice
{
    partial class ManageSubscriptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CancelBtn = new Button();
            UnsubscribeBtn = new Button();
            SubscribeBtn = new Button();
            EmailTxtBox = new TextBox();
            fontDialog1 = new FontDialog();
            NtfEmail = new CheckBox();
            NtfSms = new CheckBox();
            SmsTxtBox = new TextBox();
            SuspendLayout();
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(390, 220);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(147, 42);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Back";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // UnsubscribeBtn
            // 
            UnsubscribeBtn.Location = new Point(235, 220);
            UnsubscribeBtn.Name = "UnsubscribeBtn";
            UnsubscribeBtn.Size = new Size(147, 42);
            UnsubscribeBtn.TabIndex = 4;
            UnsubscribeBtn.Text = "Unsubscribe";
            UnsubscribeBtn.UseVisualStyleBackColor = true;
            UnsubscribeBtn.Click += UnsubscribeBtn_Click;
            // 
            // SubscribeBtn
            // 
            SubscribeBtn.Location = new Point(73, 220);
            SubscribeBtn.Name = "SubscribeBtn";
            SubscribeBtn.Size = new Size(147, 42);
            SubscribeBtn.TabIndex = 3;
            SubscribeBtn.Text = "Subscribe";
            SubscribeBtn.UseVisualStyleBackColor = true;
            SubscribeBtn.Click += SubscribeBtn_Click;
            // 
            // EmailTxtBox
            // 
            EmailTxtBox.Location = new Point(301, 116);
            EmailTxtBox.Name = "EmailTxtBox";
            EmailTxtBox.Size = new Size(236, 23);
            EmailTxtBox.TabIndex = 6;
            EmailTxtBox.TextChanged += EmailTxtBox_TextChanged;
            // 
            // NtfEmail
            // 
            NtfEmail.AutoSize = true;
            NtfEmail.Location = new Point(73, 116);
            NtfEmail.Name = "NtfEmail";
            NtfEmail.Size = new Size(163, 19);
            NtfEmail.TabIndex = 9;
            NtfEmail.Text = "Notification Sent by Email";
            NtfEmail.UseVisualStyleBackColor = true;
            NtfEmail.CheckedChanged += NtfEmail_CheckedChanged;
            // 
            // NtfSms
            // 
            NtfSms.AutoSize = true;
            NtfSms.Location = new Point(73, 168);
            NtfSms.Name = "NtfSms";
            NtfSms.Size = new Size(157, 19);
            NtfSms.TabIndex = 10;
            NtfSms.Text = "Notification Sent by SMS";
            NtfSms.UseVisualStyleBackColor = true;
            NtfSms.CheckedChanged += NtfSms_CheckedChanged;
            // 
            // SmsTxtBox
            // 
            SmsTxtBox.Location = new Point(301, 166);
            SmsTxtBox.Name = "SmsTxtBox";
            SmsTxtBox.Size = new Size(236, 23);
            SmsTxtBox.TabIndex = 11;
            SmsTxtBox.TextChanged += SmsTxtBox_TextChanged;
            // 
            // ManageSubscriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 386);
            Controls.Add(SmsTxtBox);
            Controls.Add(NtfSms);
            Controls.Add(NtfEmail);
            Controls.Add(EmailTxtBox);
            Controls.Add(CancelBtn);
            Controls.Add(UnsubscribeBtn);
            Controls.Add(SubscribeBtn);
            Name = "ManageSubscriptionForm";
            Text = "ManageSubscriptionForm";
            Load += ManageSubscriptionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelBtn;
        private Button UnsubscribeBtn;
        private Button SubscribeBtn;
        private TextBox EmailTxtBox;
        private FontDialog fontDialog1;
        private CheckBox NtfEmail;
        private CheckBox NtfSms;
        private TextBox SmsTxtBox;
    }
}