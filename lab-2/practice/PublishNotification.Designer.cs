namespace practice
{
    partial class PublishNotification
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
            label1 = new Label();
            NotifContentTxtBox = new TextBox();
            PublishBtn = new Button();
            PublishExitBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 136);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "Notification Content";
            // 
            // NotifContentTxtBox
            // 
            NotifContentTxtBox.Location = new Point(288, 133);
            NotifContentTxtBox.Name = "NotifContentTxtBox";
            NotifContentTxtBox.Size = new Size(180, 23);
            NotifContentTxtBox.TabIndex = 1;
            NotifContentTxtBox.TextChanged += NotifContentTxtBox_TextChanged;
            // 
            // PublishBtn
            // 
            PublishBtn.Location = new Point(128, 231);
            PublishBtn.Name = "PublishBtn";
            PublishBtn.Size = new Size(147, 42);
            PublishBtn.TabIndex = 4;
            PublishBtn.Text = "Publish";
            PublishBtn.UseVisualStyleBackColor = true;
            PublishBtn.Click += PublishBtn_Click;
            // 
            // PublishExitBtn
            // 
            PublishExitBtn.Location = new Point(321, 231);
            PublishExitBtn.Name = "PublishExitBtn";
            PublishExitBtn.Size = new Size(147, 42);
            PublishExitBtn.TabIndex = 5;
            PublishExitBtn.Text = "Back";
            PublishExitBtn.UseVisualStyleBackColor = true;
            PublishExitBtn.Click += PublishExitBtn_Click;
            // 
            // PublishNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 386);
            Controls.Add(PublishExitBtn);
            Controls.Add(PublishBtn);
            Controls.Add(NotifContentTxtBox);
            Controls.Add(label1);
            Name = "PublishNotification";
            Text = "PublishNotification";
            Load += PublishNotification_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NotifContentTxtBox;
        private Button PublishBtn;
        private Button PublishExitBtn;
    }
}