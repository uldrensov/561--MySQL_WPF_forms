using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        //customers button:
        private void custSwitch_Click(object sender, EventArgs e)
        {
            customerForm f = new customerForm();
            f.Show();
            //Hide();
        }


        //books button:
        private void bookSwitch_Click(object sender, EventArgs e)
        {
            bookForm g = new bookForm();
            g.Show();
            Hide();
        }


        //order button:
        private void orderSwitch_Click(object sender, EventArgs e)
        {
            orderForm h = new orderForm();
            h.Show();
            Hide();
        }
    }
}

//TODO: buttons can be pressed multiple times to create multiple forms...fix it or simply hide the form?
// implement form-switch features for all other forms