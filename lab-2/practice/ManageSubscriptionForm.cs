using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice
{

    public partial class ManageSubscriptionForm : Form
    {
        // Declare the collections to store subscribers
        public HashSet<string> EmailSubscribers { get; private set; }
        public HashSet<string> MobileSubscribers { get; private set; }

        // Delegate for subscription updates
        public delegate void SubscriptionUpdateDelegate(string message);

        // Event for subscription updates
        public event SubscriptionUpdateDelegate SubscriptionUpdated;

        public ManageSubscriptionForm()
        {
            InitializeComponent();
            EmailSubscribers = new HashSet<string>();
            MobileSubscribers = new HashSet<string>();
            SmsTxtBox.MaxLength = 12;
        }


        private void UnsubscribeBtn_Click(object sender, EventArgs e)
        {
            var email = EmailTxtBox.Text;
            var mobile = SmsTxtBox.Text;

            if (NtfEmail.Checked && EmailSubscribers.Remove(email))
            {
                SubscriptionUpdated?.Invoke($"Email {email} unsubscribed");
                MessageBox.Show("Email unsubscribed successfully.");
            }

            if (NtfSms.Checked && MobileSubscribers.Remove(mobile))
            {
                SubscriptionUpdated?.Invoke($"Mobile {mobile} unsubscribed");
                MessageBox.Show("Mobile number unsubscribed successfully.");
            }
        }


        private void ManageSubscriptionForm_Load(object sender, EventArgs e)
        {

        }



        private void SubscribeBtn_Click(object sender, EventArgs e)
        {
            var email = EmailTxtBox.Text;
            var mobile = SmsTxtBox.Text;

            bool isEmailSubscribed = NtfEmail.Checked && !string.IsNullOrEmpty(email) && IsValidEmail(email);
            bool isMobileSubscribed = NtfSms.Checked && !string.IsNullOrEmpty(mobile) && IsValidMobile(ref mobile);

            // For email subscription
            if (isEmailSubscribed)
            {
                if (EmailSubscribers.Add(email)) // If successfully added
                {
                    SubscriptionUpdated?.Invoke($"Email {email} subscribed"); // Invoke delegate
                    MessageBox.Show("Email successfully subscribed.");
                }
                else
                {
                    MessageBox.Show("Email already subscribed.");
                }
            }

            // For mobile number subscription
            if (isMobileSubscribed)
            {
                if (MobileSubscribers.Add(mobile)) // If successfully added
                {
                    SubscriptionUpdated?.Invoke($"Mobile {mobile} subscribed"); // Invoke delegate
                    MessageBox.Show("Mobile number successfully subscribed.");
                    SmsTxtBox.Text = mobile; // Update the text box with the formatted number
                }
                else
                {
                    MessageBox.Show("Mobile number already subscribed.");
                }
            }

 
            if (!isEmailSubscribed && !isMobileSubscribed)
            {
                MessageBox.Show("Please enter a valid email and/or mobile number.");
            }
        }





        private bool IsValidEmail(string email) //Req: validate
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }


        private bool IsValidMobile(ref string mobile)
        {
            mobile = new string(mobile.Where(char.IsDigit).ToArray());

            if (mobile.Length == 10)
            {
                mobile = mobile.Insert(3, "-").Insert(7, "-");
                return true;
            }

            return false;
        }



        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NtfEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NtfSms_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EmailTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SmsTxtBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var digits = new string(textBox.Text.Where(char.IsDigit).ToArray());
            var formattedNumber = "";

  
            if (digits.Length > 0)
            {
  
                formattedNumber = digits.Substring(0, Math.Min(3, digits.Length));

 
                if (digits.Length > 3)
                {
                    formattedNumber += "-" + digits.Substring(3, Math.Min(3, digits.Length - 3));
                }


                if (digits.Length > 6)
                {
                    formattedNumber += "-" + digits.Substring(6);
                }
            }

   
            int caretPosition = textBox.SelectionStart;
            textBox.Text = formattedNumber;
            textBox.SelectionStart = Math.Min(caretPosition, textBox.Text.Length); 
        }

    }
}




