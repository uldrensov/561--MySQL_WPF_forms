namespace COMPE561_Lab05
{
    partial class customerForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.newcustButton = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.zipLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.lnLabel = new System.Windows.Forms.Label();
            this.fnLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.zipBox = new System.Windows.Forms.TextBox();
            this.stateBox = new System.Windows.Forms.TextBox();
            this.cityBox = new System.Windows.Forms.TextBox();
            this.lnBox = new System.Windows.Forms.TextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.fnBox = new System.Windows.Forms.TextBox();
            this.custDropdown = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboLabel
            // 
            this.comboLabel.AutoSize = true;
            this.comboLabel.Location = new System.Drawing.Point(36, 47);
            this.comboLabel.Name = "comboLabel";
            this.comboLabel.Size = new System.Drawing.Size(112, 13);
            this.comboLabel.TabIndex = 41;
            this.comboLabel.Text = "Edit existing customer:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(741, 103);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 39);
            this.cancelButton.TabIndex = 40;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(741, 204);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 39);
            this.saveButton.TabIndex = 39;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newcustButton
            // 
            this.newcustButton.Location = new System.Drawing.Point(741, 58);
            this.newcustButton.Name = "newcustButton";
            this.newcustButton.Size = new System.Drawing.Size(75, 39);
            this.newcustButton.TabIndex = 38;
            this.newcustButton.Text = "New customer";
            this.newcustButton.UseVisualStyleBackColor = true;
            this.newcustButton.Click += new System.EventHandler(this.newcustButton_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(90, 326);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 37;
            this.emailLabel.Text = "Email:";
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(540, 229);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(25, 13);
            this.zipLabel.TabIndex = 36;
            this.zipLabel.Text = "Zip:";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(90, 291);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(41, 13);
            this.phoneLabel.TabIndex = 35;
            this.phoneLabel.Text = "Phone:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(90, 152);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 34;
            this.addressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(90, 229);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 33;
            this.cityLabel.Text = "City:";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(375, 229);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 13);
            this.stateLabel.TabIndex = 32;
            this.stateLabel.Text = "State:";
            // 
            // lnLabel
            // 
            this.lnLabel.AutoSize = true;
            this.lnLabel.Location = new System.Drawing.Point(417, 116);
            this.lnLabel.Name = "lnLabel";
            this.lnLabel.Size = new System.Drawing.Size(59, 13);
            this.lnLabel.TabIndex = 31;
            this.lnLabel.Text = "Last name:";
            // 
            // fnLabel
            // 
            this.fnLabel.AutoSize = true;
            this.fnLabel.Location = new System.Drawing.Point(90, 116);
            this.fnLabel.Name = "fnLabel";
            this.fnLabel.Size = new System.Drawing.Size(58, 13);
            this.fnLabel.TabIndex = 30;
            this.fnLabel.Text = "First name:";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(154, 323);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(286, 20);
            this.emailBox.TabIndex = 29;
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(154, 288);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(286, 20);
            this.phoneBox.TabIndex = 28;
            // 
            // zipBox
            // 
            this.zipBox.Location = new System.Drawing.Point(571, 226);
            this.zipBox.Name = "zipBox";
            this.zipBox.Size = new System.Drawing.Size(71, 20);
            this.zipBox.TabIndex = 27;
            // 
            // stateBox
            // 
            this.stateBox.Location = new System.Drawing.Point(416, 226);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(71, 20);
            this.stateBox.TabIndex = 26;
            // 
            // cityBox
            // 
            this.cityBox.Location = new System.Drawing.Point(154, 226);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(161, 20);
            this.cityBox.TabIndex = 25;
            // 
            // lnBox
            // 
            this.lnBox.Location = new System.Drawing.Point(481, 113);
            this.lnBox.Name = "lnBox";
            this.lnBox.Size = new System.Drawing.Size(161, 20);
            this.lnBox.TabIndex = 24;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(154, 149);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(488, 20);
            this.addressBox.TabIndex = 23;
            // 
            // fnBox
            // 
            this.fnBox.Location = new System.Drawing.Point(154, 113);
            this.fnBox.Name = "fnBox";
            this.fnBox.Size = new System.Drawing.Size(161, 20);
            this.fnBox.TabIndex = 22;
            // 
            // custDropdown
            // 
            this.custDropdown.FormattingEnabled = true;
            this.custDropdown.Location = new System.Drawing.Point(154, 44);
            this.custDropdown.Name = "custDropdown";
            this.custDropdown.Size = new System.Drawing.Size(320, 21);
            this.custDropdown.TabIndex = 21;
            this.custDropdown.SelectedIndexChanged += new System.EventHandler(this.custDropdown_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(741, 354);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 39);
            this.backButton.TabIndex = 42;
            this.backButton.Text = "Back to menu";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(90, 385);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(52, 13);
            this.idLabel.TabIndex = 43;
            this.idLabel.Text = "ID (Auto):";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(154, 382);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(71, 20);
            this.idBox.TabIndex = 44;
            // 
            // customerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 437);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.comboLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newcustButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.zipLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.lnLabel);
            this.Controls.Add(this.fnLabel);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.zipBox);
            this.Controls.Add(this.stateBox);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.lnBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.fnBox);
            this.Controls.Add(this.custDropdown);
            this.Name = "customerForm";
            this.Text = "Customer data";
            this.Load += new System.EventHandler(this.customerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comboLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button newcustButton;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label lnLabel;
        private System.Windows.Forms.Label fnLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.TextBox zipBox;
        private System.Windows.Forms.TextBox stateBox;
        private System.Windows.Forms.TextBox cityBox;
        private System.Windows.Forms.TextBox lnBox;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox fnBox;
        private System.Windows.Forms.ComboBox custDropdown;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idBox;
    }
}