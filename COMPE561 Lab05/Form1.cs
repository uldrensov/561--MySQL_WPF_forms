using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Cliff Phan (821099130)
/// SQL Bookstore application
/// Allows the user interact with a database to add/modify customer and book entries, and place orders as a registered customer
/// </summary>
namespace COMPE561_Lab05
{
    public partial class Form1 : Form
    {
        //form init
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //customers button: hides the main form and reveals a newly created customerForm
        private void custSwitch_Click(object sender, EventArgs e)
        {
            customerForm f = new customerForm(this); //pass this form instance as an argument, so it can be manipulated from the customerForm
            Hide();
            f.Show();
        }


        //books button: hides the main form and reveals a newly created bookForm
        private void bookSwitch_Click(object sender, EventArgs e)
        {
            bookForm g = new bookForm(this); //pass this form instance as an argument, so it can be manipulated from the bookForm
            Hide();
            g.Show();
        }


        //order button: hides the main form and reveals a newly created orderForm
        private void orderSwitch_Click(object sender, EventArgs e)
        {
            orderForm h = new orderForm(this); //pass this form instance as an argument, so it can be manipulated from the orderForm
            Hide();
            h.Show();
        }
    }
}
