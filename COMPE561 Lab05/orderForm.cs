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
    public partial class orderForm : Form
    {
        //form init
        public orderForm()
        {
            InitializeComponent();
        }


        private void orderForm_Load(object sender, EventArgs e)
        {

        }
    }
}

//TODO: copypasta some of the old code case
//add database functionalities...reads customer names into combobox, reads title into combobox and populates boxes, writes results to a table
//EC:write order summary to notepad