namespace COMPE561_Lab05
{
    partial class bookForm
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
            this.comboLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.newbookButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.bookDropdown = new System.Windows.Forms.ComboBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.isbnLabel = new System.Windows.Forms.Label();
            this.isbnBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboLabel
            // 
            this.comboLabel.AutoSize = true;
            this.comboLabel.Location = new System.Drawing.Point(38, 45);
            this.comboLabel.Name = "comboLabel";
            this.comboLabel.Size = new System.Drawing.Size(93, 13);
            this.comboLabel.TabIndex = 62;
            this.comboLabel.Text = "Edit existing book:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(677, 271);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 39);
            this.backButton.TabIndex = 61;
            this.backButton.Text = "Back to menu";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(677, 157);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 39);
            this.saveButton.TabIndex = 60;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newbookButton
            // 
            this.newbookButton.Location = new System.Drawing.Point(677, 32);
            this.newbookButton.Name = "newbookButton";
            this.newbookButton.Size = new System.Drawing.Size(75, 39);
            this.newbookButton.TabIndex = 59;
            this.newbookButton.Text = "New book";
            this.newbookButton.UseVisualStyleBackColor = true;
            this.newbookButton.Click += new System.EventHandler(this.newbookButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(73, 113);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 55;
            this.titleLabel.Text = "Title:";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(137, 110);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(431, 20);
            this.titleBox.TabIndex = 44;
            // 
            // bookDropdown
            // 
            this.bookDropdown.FormattingEnabled = true;
            this.bookDropdown.Location = new System.Drawing.Point(137, 42);
            this.bookDropdown.Name = "bookDropdown";
            this.bookDropdown.Size = new System.Drawing.Size(320, 21);
            this.bookDropdown.TabIndex = 42;
            this.bookDropdown.SelectedIndexChanged += new System.EventHandler(this.bookDropdown_SelectedIndexChanged);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(73, 160);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(41, 13);
            this.authorLabel.TabIndex = 64;
            this.authorLabel.Text = "Author:";
            // 
            // authorBox
            // 
            this.authorBox.Location = new System.Drawing.Point(137, 157);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(431, 20);
            this.authorBox.TabIndex = 63;
            // 
            // isbnLabel
            // 
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Location = new System.Drawing.Point(73, 205);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(35, 13);
            this.isbnLabel.TabIndex = 66;
            this.isbnLabel.Text = "ISBN:";
            // 
            // isbnBox
            // 
            this.isbnBox.Location = new System.Drawing.Point(137, 202);
            this.isbnBox.Name = "isbnBox";
            this.isbnBox.Size = new System.Drawing.Size(431, 20);
            this.isbnBox.TabIndex = 65;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(73, 247);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(34, 13);
            this.priceLabel.TabIndex = 68;
            this.priceLabel.Text = "Price:";
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(137, 244);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(431, 20);
            this.priceBox.TabIndex = 67;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(677, 77);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 39);
            this.cancelButton.TabIndex = 69;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // bookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 334);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.isbnLabel);
            this.Controls.Add(this.isbnBox);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.authorBox);
            this.Controls.Add(this.comboLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newbookButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.bookDropdown);
            this.Name = "bookForm";
            this.Text = "Book data";
            this.Load += new System.EventHandler(this.bookForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comboLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button newbookButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.ComboBox bookDropdown;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.Label isbnLabel;
        private System.Windows.Forms.TextBox isbnBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.Button cancelButton;
    }
}