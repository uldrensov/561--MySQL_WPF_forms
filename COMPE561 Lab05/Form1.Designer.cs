namespace COMPE561_Lab05
{
    partial class Form1
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
            this.custSwitch = new System.Windows.Forms.Button();
            this.bookSwitch = new System.Windows.Forms.Button();
            this.orderSwitch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // custSwitch
            // 
            this.custSwitch.Location = new System.Drawing.Point(81, 48);
            this.custSwitch.Name = "custSwitch";
            this.custSwitch.Size = new System.Drawing.Size(116, 23);
            this.custSwitch.TabIndex = 0;
            this.custSwitch.Text = "Manage customers";
            this.custSwitch.UseVisualStyleBackColor = true;
            this.custSwitch.Click += new System.EventHandler(this.custSwitch_Click);
            // 
            // bookSwitch
            // 
            this.bookSwitch.Location = new System.Drawing.Point(81, 99);
            this.bookSwitch.Name = "bookSwitch";
            this.bookSwitch.Size = new System.Drawing.Size(116, 23);
            this.bookSwitch.TabIndex = 1;
            this.bookSwitch.Text = "Manage books";
            this.bookSwitch.UseVisualStyleBackColor = true;
            this.bookSwitch.Click += new System.EventHandler(this.bookSwitch_Click);
            // 
            // orderSwitch
            // 
            this.orderSwitch.Location = new System.Drawing.Point(81, 148);
            this.orderSwitch.Name = "orderSwitch";
            this.orderSwitch.Size = new System.Drawing.Size(116, 23);
            this.orderSwitch.TabIndex = 2;
            this.orderSwitch.Text = "Place order";
            this.orderSwitch.UseVisualStyleBackColor = true;
            this.orderSwitch.Click += new System.EventHandler(this.orderSwitch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 235);
            this.Controls.Add(this.orderSwitch);
            this.Controls.Add(this.bookSwitch);
            this.Controls.Add(this.custSwitch);
            this.Name = "Form1";
            this.Text = "Main menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button custSwitch;
        private System.Windows.Forms.Button bookSwitch;
        private System.Windows.Forms.Button orderSwitch;
    }
}

