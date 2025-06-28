namespace FlickrViewer
{
    partial class FlickrViewerForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            inputTextBox = new TextBox();
            pictureBox = new PictureBox();
            searchButton = new Button();
            imagesListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(156, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter Flickr search tags here:";
            // 
            // inputTextBox
            // 
            inputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputTextBox.Location = new Point(190, 15);
            inputTextBox.Margin = new Padding(4, 3, 4, 3);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(499, 23);
            inputTextBox.TabIndex = 1;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Location = new Point(190, 46);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(587, 605);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Location = new Point(696, 13);
            searchButton.Margin = new Padding(4, 3, 4, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(82, 27);
            searchButton.TabIndex = 4;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // imagesListBox
            // 
            imagesListBox.FormattingEnabled = true;
            imagesListBox.ItemHeight = 15;
            imagesListBox.Location = new Point(18, 46);
            imagesListBox.Margin = new Padding(4, 3, 4, 3);
            imagesListBox.Name = "imagesListBox";
            imagesListBox.Size = new Size(165, 604);
            imagesListBox.TabIndex = 5;
            imagesListBox.SelectedIndexChanged += imagesListBox_SelectedIndexChanged;
            // 
            // FlickrViewerForm
            // 
            AcceptButton = searchButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 662);
            Controls.Add(imagesListBox);
            Controls.Add(searchButton);
            Controls.Add(pictureBox);
            Controls.Add(inputTextBox);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FlickrViewerForm";
            Text = "Flickr Viewer";
            Load += FlickrViewerForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox imagesListBox;
    }
}

