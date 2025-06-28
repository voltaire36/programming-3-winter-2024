using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice
{
    public partial class PublishNotification : Form
    {
        private HashSet<string> emailSubscribers;
        private HashSet<string> mobileSubscribers;

        public PublishNotification(HashSet<string> emailSubscribers, HashSet<string> mobileSubscribers)
        {
            InitializeComponent();
            this.emailSubscribers = emailSubscribers ?? new HashSet<string>();
            this.mobileSubscribers = mobileSubscribers ?? new HashSet<string>();

        }


        private void PublishBtn_Click(object sender, EventArgs e)
        {
            string notificationContent = NotifContentTxtBox.Text;
            string message = "Notification:\n\n" + notificationContent + "\n\nTo:\n";

            // Add all emails and mobile numbers to the message
            foreach (var email in emailSubscribers)
            {
                message += $"Email: {email}\n";
            }
            foreach (var mobile in mobileSubscribers)
            {
                message += $"Mobile: {mobile}\n";
            }

            MessageBox.Show(message, "Publish Notification");
        }

        private void PublishExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PublishNotification_Load(object sender, EventArgs e)
        {

        }

        private void NotifContentTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
