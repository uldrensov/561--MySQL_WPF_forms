namespace COMPE561_Lab05
{
    partial class orderForm
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
            this.confirmbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.taxlabel = new System.Windows.Forms.Label();
            this.subtotallabel = new System.Windows.Forms.Label();
            this.totallabel = new System.Windows.Forms.Label();
            this.totalbox = new System.Windows.Forms.TextBox();
            this.taxbox = new System.Windows.Forms.TextBox();
            this.subtotalbox = new System.Windows.Forms.TextBox();
            this.qtylabel = new System.Windows.Forms.Label();
            this.qtybox = new System.Windows.Forms.TextBox();
            this.pricelabel = new System.Windows.Forms.Label();
            this.isbnlabel = new System.Windows.Forms.Label();
            this.authorlabel = new System.Windows.Forms.Label();
            this.bookselLabel = new System.Windows.Forms.Label();
            this.maingrid = new System.Windows.Forms.DataGridView();
            this.pricebox = new System.Windows.Forms.TextBox();
            this.authorbox = new System.Windows.Forms.TextBox();
            this.isbnbox = new System.Windows.Forms.TextBox();
            this.bookselDropdown = new System.Windows.Forms.ComboBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.custselLabel = new System.Windows.Forms.Label();
            this.custselDropdown = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maingrid)).BeginInit();
            this.SuspendLayout();
            // 
            // confirmbutton
            // 
            this.confirmbutton.Location = new System.Drawing.Point(582, 432);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(78, 23);
            this.confirmbutton.TabIndex = 39;
            this.confirmbutton.Text = "Confirm order";
            this.confirmbutton.UseVisualStyleBackColor = true;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(583, 461);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(77, 23);
            this.cancelbutton.TabIndex = 38;
            this.cancelbutton.Text = "Cancel order";
            this.cancelbutton.UseVisualStyleBackColor = true;
            // 
            // taxlabel
            // 
            this.taxlabel.AutoSize = true;
            this.taxlabel.Location = new System.Drawing.Point(104, 429);
            this.taxlabel.Name = "taxlabel";
            this.taxlabel.Size = new System.Drawing.Size(28, 13);
            this.taxlabel.TabIndex = 37;
            this.taxlabel.Text = "Tax:";
            // 
            // subtotallabel
            // 
            this.subtotallabel.AutoSize = true;
            this.subtotallabel.Location = new System.Drawing.Point(83, 403);
            this.subtotallabel.Name = "subtotallabel";
            this.subtotallabel.Size = new System.Drawing.Size(49, 13);
            this.subtotallabel.TabIndex = 36;
            this.subtotallabel.Text = "Subtotal:";
            // 
            // totallabel
            // 
            this.totallabel.AutoSize = true;
            this.totallabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totallabel.Location = new System.Drawing.Point(514, 403);
            this.totallabel.Name = "totallabel";
            this.totallabel.Size = new System.Drawing.Size(40, 13);
            this.totallabel.TabIndex = 35;
            this.totallabel.Text = "Total:";
            // 
            // totalbox
            // 
            this.totalbox.Location = new System.Drawing.Point(560, 400);
            this.totalbox.Name = "totalbox";
            this.totalbox.Size = new System.Drawing.Size(100, 20);
            this.totalbox.TabIndex = 34;
            // 
            // taxbox
            // 
            this.taxbox.Location = new System.Drawing.Point(138, 426);
            this.taxbox.Name = "taxbox";
            this.taxbox.Size = new System.Drawing.Size(100, 20);
            this.taxbox.TabIndex = 33;
            // 
            // subtotalbox
            // 
            this.subtotalbox.Location = new System.Drawing.Point(138, 400);
            this.subtotalbox.Name = "subtotalbox";
            this.subtotalbox.Size = new System.Drawing.Size(100, 20);
            this.subtotalbox.TabIndex = 32;
            // 
            // qtylabel
            // 
            this.qtylabel.AutoSize = true;
            this.qtylabel.Location = new System.Drawing.Point(56, 123);
            this.qtylabel.Name = "qtylabel";
            this.qtylabel.Size = new System.Drawing.Size(49, 13);
            this.qtylabel.TabIndex = 31;
            this.qtylabel.Text = "Quantity:";
            // 
            // qtybox
            // 
            this.qtybox.Location = new System.Drawing.Point(116, 120);
            this.qtybox.Name = "qtybox";
            this.qtybox.Size = new System.Drawing.Size(100, 20);
            this.qtybox.TabIndex = 30;
            // 
            // pricelabel
            // 
            this.pricelabel.AutoSize = true;
            this.pricelabel.Location = new System.Drawing.Point(453, 164);
            this.pricelabel.Name = "pricelabel";
            this.pricelabel.Size = new System.Drawing.Size(34, 13);
            this.pricelabel.TabIndex = 29;
            this.pricelabel.Text = "Price:";
            // 
            // isbnlabel
            // 
            this.isbnlabel.AutoSize = true;
            this.isbnlabel.Location = new System.Drawing.Point(452, 138);
            this.isbnlabel.Name = "isbnlabel";
            this.isbnlabel.Size = new System.Drawing.Size(35, 13);
            this.isbnlabel.TabIndex = 28;
            this.isbnlabel.Text = "ISBN:";
            // 
            // authorlabel
            // 
            this.authorlabel.AutoSize = true;
            this.authorlabel.Location = new System.Drawing.Point(443, 112);
            this.authorlabel.Name = "authorlabel";
            this.authorlabel.Size = new System.Drawing.Size(44, 13);
            this.authorlabel.TabIndex = 27;
            this.authorlabel.Text = " Author:";
            // 
            // bookselLabel
            // 
            this.bookselLabel.AutoSize = true;
            this.bookselLabel.Location = new System.Drawing.Point(56, 85);
            this.bookselLabel.Name = "bookselLabel";
            this.bookselLabel.Size = new System.Drawing.Size(35, 13);
            this.bookselLabel.TabIndex = 26;
            this.bookselLabel.Text = "Book:";
            // 
            // maingrid
            // 
            this.maingrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.maingrid.Location = new System.Drawing.Point(215, 223);
            this.maingrid.Name = "maingrid";
            this.maingrid.Size = new System.Drawing.Size(445, 134);
            this.maingrid.TabIndex = 25;
            // 
            // pricebox
            // 
            this.pricebox.Location = new System.Drawing.Point(493, 161);
            this.pricebox.Name = "pricebox";
            this.pricebox.Size = new System.Drawing.Size(167, 20);
            this.pricebox.TabIndex = 24;
            // 
            // authorbox
            // 
            this.authorbox.Location = new System.Drawing.Point(493, 109);
            this.authorbox.Name = "authorbox";
            this.authorbox.Size = new System.Drawing.Size(167, 20);
            this.authorbox.TabIndex = 23;
            // 
            // isbnbox
            // 
            this.isbnbox.Location = new System.Drawing.Point(493, 135);
            this.isbnbox.Name = "isbnbox";
            this.isbnbox.Size = new System.Drawing.Size(167, 20);
            this.isbnbox.TabIndex = 22;
            // 
            // bookselDropdown
            // 
            this.bookselDropdown.FormattingEnabled = true;
            this.bookselDropdown.Location = new System.Drawing.Point(116, 82);
            this.bookselDropdown.Name = "bookselDropdown";
            this.bookselDropdown.Size = new System.Drawing.Size(544, 21);
            this.bookselDropdown.TabIndex = 21;
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(116, 223);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(69, 43);
            this.addbutton.TabIndex = 20;
            this.addbutton.Text = "Add titles";
            this.addbutton.UseVisualStyleBackColor = true;
            // 
            // custselLabel
            // 
            this.custselLabel.AutoSize = true;
            this.custselLabel.Location = new System.Drawing.Point(56, 33);
            this.custselLabel.Name = "custselLabel";
            this.custselLabel.Size = new System.Drawing.Size(54, 13);
            this.custselLabel.TabIndex = 41;
            this.custselLabel.Text = "Customer:";
            // 
            // custselDropdown
            // 
            this.custselDropdown.FormattingEnabled = true;
            this.custselDropdown.Location = new System.Drawing.Point(116, 30);
            this.custselDropdown.Name = "custselDropdown";
            this.custselDropdown.Size = new System.Drawing.Size(544, 21);
            this.custselDropdown.TabIndex = 40;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(331, 489);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 48);
            this.backButton.TabIndex = 42;
            this.backButton.Text = "Back to menu";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // orderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 549);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.custselLabel);
            this.Controls.Add(this.custselDropdown);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.taxlabel);
            this.Controls.Add(this.subtotallabel);
            this.Controls.Add(this.totallabel);
            this.Controls.Add(this.totalbox);
            this.Controls.Add(this.taxbox);
            this.Controls.Add(this.subtotalbox);
            this.Controls.Add(this.qtylabel);
            this.Controls.Add(this.qtybox);
            this.Controls.Add(this.pricelabel);
            this.Controls.Add(this.isbnlabel);
            this.Controls.Add(this.authorlabel);
            this.Controls.Add(this.bookselLabel);
            this.Controls.Add(this.maingrid);
            this.Controls.Add(this.pricebox);
            this.Controls.Add(this.authorbox);
            this.Controls.Add(this.isbnbox);
            this.Controls.Add(this.bookselDropdown);
            this.Controls.Add(this.addbutton);
            this.Name = "orderForm";
            this.Text = "Book order";
            this.Load += new System.EventHandler(this.orderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maingrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label taxlabel;
        private System.Windows.Forms.Label subtotallabel;
        private System.Windows.Forms.Label totallabel;
        private System.Windows.Forms.TextBox totalbox;
        private System.Windows.Forms.TextBox taxbox;
        private System.Windows.Forms.TextBox subtotalbox;
        private System.Windows.Forms.Label qtylabel;
        private System.Windows.Forms.TextBox qtybox;
        private System.Windows.Forms.Label pricelabel;
        private System.Windows.Forms.Label isbnlabel;
        private System.Windows.Forms.Label authorlabel;
        private System.Windows.Forms.Label bookselLabel;
        private System.Windows.Forms.DataGridView maingrid;
        private System.Windows.Forms.TextBox pricebox;
        private System.Windows.Forms.TextBox authorbox;
        private System.Windows.Forms.TextBox isbnbox;
        private System.Windows.Forms.ComboBox bookselDropdown;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label custselLabel;
        private System.Windows.Forms.ComboBox custselDropdown;
        private System.Windows.Forms.Button backButton;
    }
}