using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace COMPE561_Lab05
{
    public partial class orderForm : Form
    {
        const string connection_keycard = "datasource=127.0.0.1;port=3306;username=root;password=;database=lab5"; //"key" to the database
        const int timelim = 30; //command timeout time limit (seconds)
        const int idlength = 10; //order id length
        const double taxratio = 0.1; //tax multiplier

        //instantiate a datatable for the datagridview element
        DataTable dt = new DataTable();


        //form init
        public orderForm()
        {
            InitializeComponent();

            //populate both combo boxes
            populateDropdown1();
            populateDropdown2();

            //keep certain textboxes permanently disabled
            idbox.Enabled = false;
            authorbox.Enabled = false;
            isbnbox.Enabled = false;
            pricebox.Enabled = false;

            //clean the slate
            reset();
        }


        private void orderForm_Load(object sender, EventArgs e)
        {

        }


        //
        private void addbutton_Click(object sender, EventArgs e)
        {

        }


        //
        private void confirmbutton_Click(object sender, EventArgs e)
        {

        }


        //
        private void cancelbutton_Click(object sender, EventArgs e)
        {

        }


        //back button: stows the current form and returns to the main menu
        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        //customer combo box select: displays respective customer id based on selection
        private void custselDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if an item is chosen, populate the textbox
            if (!(custselDropdown.SelectedItem is null))
            {
                //obtain the selected object
                customer selected_cust = custselDropdown.SelectedItem as customer;

                //access its properties and display customer id
                idbox.Text = selected_cust.id;
            }
        }


        //book combo box select: displays information in textboxes based on selection
        private void bookselDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if an item is chosen, populate the textboxes
            if (!(bookselDropdown.SelectedItem is null))
            {
                //obtain the selected object
                book selected_book = bookselDropdown.SelectedItem as book;

                //access its properties and display them
                authorbox.Text = selected_book.author;
                isbnbox.Text = selected_book.isbn;
                pricebox.Text = selected_book.price;
            }
        }


        //instantiates customer objects and wires them to the combo box
        private void populateDropdown1()
        {
            //create a list to contain customer objects read from the database
            List<customer> cList = new List<customer>();

            //create a connection "portal" to the database using the "keycard" string
            MySqlConnection dbPortal = new MySqlConnection(connection_keycard);

            //create a command object using the "portal" object, and a SQL query that reads all information from the database's "customer" table
            string query = "SELECT * FROM customer";
            MySqlCommand read_command = new MySqlCommand(query, dbPortal);
            read_command.CommandTimeout = timelim; //ensure the command doesn't take too long

            //open the "portal" and begin reading data
            try
            {
                dbPortal.Open();

                //create and activate an reading "eye" via a property of the command object
                MySqlDataReader eye = read_command.ExecuteReader();
                if (eye.HasRows)
                {
                    //create customer objects with the collected data, and add them to the list
                    while (eye.Read())
                    {
                        cList.Add(new customer(eye.GetString(0), eye.GetString(1), eye.GetString(2), eye.GetString(3),
                            eye.GetString(4), eye.GetString(5), eye.GetString(6), eye.GetString(7), eye.GetString(8)));
                    }
                }
            }

            catch (Exception err)
            {
                MessageBox.Show($"ERROR: {err.Message}");
                MessageBox.Show("Failed to connect to database. Application will now exit...");
                Environment.Exit(0);
            }

            //populate the combo box with the contents of the list
            custselDropdown.DataSource = cList;
        }


        //instantiates book objects and wires them to the combo box
        private void populateDropdown2()
        {
            //create a list to contain book objects read from the database
            List<book> bList = new List<book>();

            //create a connection "portal" to the database using the "keycard" string
            MySqlConnection dbPortal = new MySqlConnection(connection_keycard);

            //create a command object using the "portal" object, and a SQL query that reads all information from the database's "book" table
            string query = "SELECT * FROM book";
            MySqlCommand read_command = new MySqlCommand(query, dbPortal);
            read_command.CommandTimeout = timelim; //ensure the command doesn't take too long

            //open the "portal" and begin reading data
            try
            {
                dbPortal.Open();

                //create and activate an reading "eye" via a property of the command object
                MySqlDataReader eye = read_command.ExecuteReader();
                if (eye.HasRows)
                {
                    //create book objects with the collected data, and add them to the list
                    while (eye.Read())
                    {
                        bList.Add(new book(eye.GetString(0), eye.GetString(1), eye.GetString(2), eye.GetString(3)));
                    }
                }
            }

            catch (Exception err)
            {
                MessageBox.Show($"ERROR: {err.Message}");
                MessageBox.Show("Failed to connect to database. Application will now exit...");
                Environment.Exit(0);
            }

            //populate the combo box with the contents of the list
            bookselDropdown.DataSource = bList;
        }


        //generates a random order id
        private string gen_id()
        {
            Random RNGesus = new Random();

            //create and populate a char array with random numbers
            char[] idchars = new char[idlength];
            for (int z = 0; z < idlength; z++)
            {
                int rand = RNGesus.Next(48, 58);
                idchars[z] = (char)rand;
            }

            //convert to string and return
            string randID = new string(idchars);
            return randID;
        }


        /*
        //generates a random date
        private string gen_date()
        {
            Random RNGesus = new Random();
        }
        */


        //clears the form
        private void reset()
        {
            custselDropdown.SelectedItem = null;
            bookselDropdown.SelectedItem = null;

            idbox.Text = null;
            qtybox.Text = null;
            authorbox.Text = null;
            isbnbox.Text = null;
            pricebox.Text = null;
            subtotalbox.Text = null;
            taxbox.Text = null;
            totalbox.Text = null;

            dt.Clear();
        }
    }
}

//TODO: copypasta some of the old code base
//add database functionalities...reads customer names into combobox, reads title into combobox and populates boxes, writes results to a table
//EC: write order summary to notepad