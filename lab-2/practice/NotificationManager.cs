using System;
using System.Windows.Forms;

namespace practice
{
    public partial class NotificationManager : Form
    {
        private ManageSubscriptionForm manageSubscriptionForm;

        public NotificationManager()
        {
            InitializeComponent();
            manageSubscriptionForm = new ManageSubscriptionForm();
        }

        private void PublishNotificationBtn_Click(object sender, EventArgs e)
        {
       
            if (manageSubscriptionForm == null)
            {
                manageSubscriptionForm = new ManageSubscriptionForm();
            }

            // Create the Publish Notification form with subscriber lists
            var publishNotificationForm = new PublishNotification(manageSubscriptionForm.EmailSubscribers, manageSubscriptionForm.MobileSubscribers);

            this.Hide();
            publishNotificationForm.ShowDialog();
            this.Show();
        }


        private void ManageSubscription_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageSubscriptionForm.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void NotificationExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
