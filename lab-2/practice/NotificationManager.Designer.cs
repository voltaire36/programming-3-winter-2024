using practice;

namespace practice
{
    partial class NotificationManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ManageSubscriptionBtn = new Button();
            PublishNotificationBtn = new Button();
            NotificationExitBtn = new Button();
            SuspendLayout();
            // 
            // ManageSubscriptionBtn
            // 
            ManageSubscriptionBtn.Location = new Point(107, 122);
            ManageSubscriptionBtn.Name = "ManageSubscriptionBtn";
            ManageSubscriptionBtn.Size = new Size(147, 42);
            ManageSubscriptionBtn.TabIndex = 0;
            ManageSubscriptionBtn.Text = "Manage Subscription";
            ManageSubscriptionBtn.UseVisualStyleBackColor = true;
            ManageSubscriptionBtn.Click += ManageSubscription_Click;
            // 
            // PublishNotificationBtn
            // 
            PublishNotificationBtn.Location = new Point(107, 184);
            PublishNotificationBtn.Name = "PublishNotificationBtn";
            PublishNotificationBtn.Size = new Size(147, 42);
            PublishNotificationBtn.TabIndex = 1;
            PublishNotificationBtn.Text = "Publish Notification";
            PublishNotificationBtn.UseVisualStyleBackColor = true;
            PublishNotificationBtn.Click += PublishNotificationBtn_Click;
            // 
            // NotificationExitBtn
            // 
            NotificationExitBtn.Location = new Point(107, 247);
            NotificationExitBtn.Name = "NotificationExitBtn";
            NotificationExitBtn.Size = new Size(147, 42);
            NotificationExitBtn.TabIndex = 2;
            NotificationExitBtn.Text = "Exit";
            NotificationExitBtn.UseVisualStyleBackColor = true;
            NotificationExitBtn.Click += NotificationExitBtn_Click;
            // 
            // NotificationManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 404);
            Controls.Add(NotificationExitBtn);
            Controls.Add(PublishNotificationBtn);
            Controls.Add(ManageSubscriptionBtn);
            Name = "NotificationManager";
            Text = "Notification Manager";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ManageSubscriptionBtn;
        private Button PublishNotificationBtn;
        private Button NotificationExitBtn;








    }
}






