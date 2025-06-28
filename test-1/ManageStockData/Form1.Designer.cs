namespace ManageStockData
{
    partial class Form1
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
            btnLoadData = new Button();
            btnSortDate = new Button();
            textBoxResult = new TextBox();
            btnSortOnSymbol = new Button();
            btnSortOnOpen = new Button();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(44, 29);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(98, 44);
            btnLoadData.TabIndex = 1;
            btnLoadData.Text = "Load Data";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // btnSortDate
            // 
            btnSortDate.Location = new Point(369, 29);
            btnSortDate.Name = "btnSortDate";
            btnSortDate.Size = new Size(140, 44);
            btnSortDate.TabIndex = 2;
            btnSortDate.Text = "Sort Based On Date";
            btnSortDate.UseVisualStyleBackColor = true;
            btnSortDate.Click += btnSortDate_Click;
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(44, 93);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ScrollBars = ScrollBars.Vertical;
            textBoxResult.Size = new Size(740, 340);
            textBoxResult.TabIndex = 3;
            // 
            // btnSortOnSymbol
            // 
            btnSortOnSymbol.Location = new Point(177, 29);
            btnSortOnSymbol.Name = "btnSortOnSymbol";
            btnSortOnSymbol.Size = new Size(153, 44);
            btnSortOnSymbol.TabIndex = 4;
            btnSortOnSymbol.Text = "Sort based on Symbol";
            btnSortOnSymbol.UseVisualStyleBackColor = true;
            btnSortOnSymbol.Click += btnSortOnSymbol_Click;
            // 
            // btnSortOnOpen
            // 
            btnSortOnOpen.Location = new Point(553, 29);
            btnSortOnOpen.Name = "btnSortOnOpen";
            btnSortOnOpen.Size = new Size(169, 44);
            btnSortOnOpen.TabIndex = 5;
            btnSortOnOpen.Text = "Sort Based on Open Price";
            btnSortOnOpen.UseVisualStyleBackColor = true;
            btnSortOnOpen.Click += btnSortOnOpen_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 445);
            Controls.Add(btnSortOnOpen);
            Controls.Add(btnSortOnSymbol);
            Controls.Add(textBoxResult);
            Controls.Add(btnSortDate);
            Controls.Add(btnLoadData);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLoadData;
        private Button btnSortDate;
        private TextBox textBoxResult;
        private Button btnSortOnSymbol;
        private Button btnSortOnOpen;
    }
}
