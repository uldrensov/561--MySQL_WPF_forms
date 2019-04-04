using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace COMPE561_Lab05
{
    public partial class customerForm : Form
    {
        const string connection_keycard = "datasource=127.0.0.1;port=3306;username=root;password=;database=lab5"; //"key" to the database
        const int timelim = 30; //command timeout time limit (seconds)
        const int idlength = 6; //customer id length


        //form init
        public customerForm()
        {
            InitializeComponent();

            //populate the combo box
            populateDropdown();

            //set the form to default/edit mode
            resetOrEdit();
        }


        private void customerForm_Load(object sender, EventArgs e)
        {

        }


        //save button: checks all textboxes for valid input, then updates/adds information to the database
        private void saveButton_Click(object sender, EventArgs e)
        {
            //use regular expressions to detect proper/improper user inputs
            Regex RX1 = new Regex("^[a-zA-Z ]{1,30}$"); //regex for first name, last name, city
            Regex RX2 = new Regex("^[0-9]{1,5} [a-zA-Z0-9 ]{1,30}$"); //regex for address
            Regex RX3 = new Regex("^[A-Z]{2}$"); //regex for state
            Regex RX4 = new Regex("^[0-9]{5}$"); //regex for zip
            Regex RX5 = new Regex("^[0-9]{3}-[0-9]{3}-[0-9]{4}$"); //regex for phone
            Regex RX6 = new Regex("^[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$"); //regex for email

            bool perfectInput = true; //this flag becomes false if any input field is found invalid

            //validate user input
            if (!RX1.IsMatch(fnBox.Text))
            {
                MessageBox.Show("Please enter a valid first name. Only alphabetical characters permitted.");
                perfectInput = false;
            }
            else if (!RX1.IsMatch(lnBox.Text))
            {
                MessageBox.Show("Please enter a valid last name. Only alphabetical characters permitted.");
                perfectInput = false;
            }
            else if (!RX2.IsMatch(addressBox.Text))
            {
                MessageBox.Show("Please enter a valid address similar the following format: [12345 Fake Street Pkwy]");
                perfectInput = false;
            }
            else if (!RX1.IsMatch(cityBox.Text))
            {
                MessageBox.Show("Please enter a valid city. Only alphabetical characters permitted.");
                perfectInput = false;
            }
            else if (!RX3.IsMatch(stateBox.Text))
            {
                MessageBox.Show("Please enter a valid 2-character state code in capital letters.");
                perfectInput = false;
            }
            else if (!RX4.IsMatch(zipBox.Text))
            {
                MessageBox.Show("Please enter a valid zip code. Must be 5-6 numerical digits long.");
                perfectInput = false;
            }
            else if (!RX5.IsMatch(phoneBox.Text))
            {
                MessageBox.Show("Please enter a valid phone number. Must include area code and dashes.");
                perfectInput = false;
            }
            else if (!RX6.IsMatch(emailBox.Text))
            {
                MessageBox.Show("Please enter a valid email address similar the following format: [example123@local.com]");
                perfectInput = false;
            }

            //only proceed if all input fields are valid
            if (perfectInput)
            {
                //create a connection "portal" to the database using the "keycard" string
                MySqlConnection dbPortal = new MySqlConnection(connection_keycard);

                //if editing an existing customer (it should be selected in the combo box)
                if (!(custDropdown.SelectedItem is null))
                {
                    //set up a yes-no dialogue prompt, and proceed only if "Yes" is chosen
                    DialogResult choice = MessageBox.Show("Are you sure you want to edit the selected entry?", "Confirm edit", MessageBoxButtons.YesNo);
                    if (choice == DialogResult.Yes)
                    {
                        //create a command object using the "portal" object, and a SQL query that updates a row of data from the database's "customer" table
                        string query =
                            "UPDATE customer " +
                            $"SET first = '{fnBox.Text}', last = '{lnBox.Text}', address = '{addressBox.Text}', city = '{cityBox.Text}', " +
                            $"state = '{stateBox.Text}', zip = '{zipBox.Text}', phone = '{phoneBox.Text}', email = '{emailBox.Text}' " +
                            $"WHERE id = '{idBox.Text}';";
                        MySqlCommand update_command = new MySqlCommand(query, dbPortal);
                        update_command.CommandTimeout = timelim; //ensure the command doesn't take too long

                        //open the "portal" and update data
                        try
                        {
                            dbPortal.Open();
                            update_command.ExecuteNonQuery();

                            //confirm success, refresh the combo box, clean up the form
                            MessageBox.Show("Customer data successfully edited.");
                            populateDropdown();
                            resetOrEdit();
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show($"ERROR: {err.Message}");
                            MessageBox.Show("Failed to record customer information. Please contact the admin.");
                        }
                    }
                }

                //if adding a new customer (no combo box selection)
                else
                {
                    //set up a yes-no dialogue prompt, and proceed only if "Yes" is chosen
                    DialogResult choice = MessageBox.Show("Are you sure you want to create a new entry?", "Confirm new entry", MessageBoxButtons.YesNo);
                    if (choice == DialogResult.Yes)
                    {
                        //create a command object using the "portal" object, and a SQL query that inserts a row of data into the database's "customer" table
                        string query =
                            "INSERT INTO customer (first, last, address, city, state, zip, phone, email, id) " +
                            $"VALUES ('{fnBox.Text}', '{lnBox.Text}', '{addressBox.Text}', '{cityBox.Text}', " +
                            $"'{stateBox.Text}', '{zipBox.Text}', '{phoneBox.Text}', '{emailBox.Text}', '{gen_id()}');";
                        MySqlCommand insertion_command = new MySqlCommand(query, dbPortal);
                        insertion_command.CommandTimeout = timelim; //ensure the command doesn't take too long

                        //open the "portal" and insert data
                        try
                        {
                            dbPortal.Open();
                            insertion_command.ExecuteNonQuery();

                            //confirm success, refresh the combo box, clean up the form
                            MessageBox.Show("New customer data successfully saved.");
                            populateDropdown();
                            resetOrEdit();
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show($"ERROR: {err.Message}");
                            MessageBox.Show("Failed to record customer information. Please contact the admin.");
                        }
                    }
                }
            }
        }


        //new customer button: sets the form to new customer mode
        private void newcustButton_Click(object sender, EventArgs e)
        {
            custDropdown.SelectedItem = null; //clear combo box selection
            custDropdown.Enabled = false; //disable combo box

            //clear textboxes
            fnBox.Text = null;
            lnBox.Text = null;
            addressBox.Text = null;
            cityBox.Text = null;
            stateBox.Text = null;
            zipBox.Text = null;
            phoneBox.Text = null;
            emailBox.Text = null;
            idBox.Text = null;

            //enable textboxes (important: id is auto-generated; leave textbox disabled)
            fnBox.Enabled = true;
            lnBox.Enabled = true;
            addressBox.Enabled = true;
            cityBox.Enabled = true;
            stateBox.Enabled = true;
            zipBox.Enabled = true;
            phoneBox.Enabled = true;
            emailBox.Enabled = true;

            fnBox.Focus(); //set focus to first name textbox
        }


        //cancel button: resets the form to default/edit mode
        private void cancelButton_Click(object sender, EventArgs e)
        {
            //set up a yes-no dialogue prompt, and reset the form if "Yes" is chosen
            DialogResult choice = MessageBox.Show("Cancel current action and reset the form?", "Cancel action", MessageBoxButtons.YesNo);
            if (choice == DialogResult.Yes) resetOrEdit();
        }


        //back button: stows the current form and returns to the main menu
        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        //combo box select: enables all textboxes, displays information in textboxes based on selection
        private void custDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //"awaken" the form (important: leave id textbox disabled)
            fnBox.Enabled = true;
            lnBox.Enabled = true;
            addressBox.Enabled = true;
            cityBox.Enabled = true;
            stateBox.Enabled = true;
            zipBox.Enabled = true;
            phoneBox.Enabled = true;
            emailBox.Enabled = true;

            //if an item is chosen, populate the textboxes
            if (!(custDropdown.SelectedItem is null))
            {
                //obtain the selected object
                customer selected_cust = custDropdown.SelectedItem as customer;

                //access its properties and display them
                fnBox.Text = selected_cust.first;
                lnBox.Text = selected_cust.last;
                addressBox.Text = selected_cust.address;
                cityBox.Text = selected_cust.city;
                stateBox.Text = selected_cust.state;
                zipBox.Text = selected_cust.zip;
                phoneBox.Text = selected_cust.phone;
                emailBox.Text = selected_cust.email;
                idBox.Text = selected_cust.id;
            }

            //if there is no selection, ensure the form does not "awaken"
            else resetOrEdit();
        }


        //instantiates customer objects and wires them to the combo box
        private void populateDropdown()
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
            custDropdown.DataSource = cList;
        }


        //resets the form to default mode (edit customer mode)
        private void resetOrEdit()
        {
            custDropdown.SelectedItem = null; //clear combo box selection
            custDropdown.Enabled = true; //enable combo box

            //clear textboxes
            fnBox.Text = null;
            lnBox.Text = null;
            addressBox.Text = null;
            cityBox.Text = null;
            stateBox.Text = null;
            zipBox.Text = null;
            phoneBox.Text = null;
            emailBox.Text = null;
            idBox.Text = null;

            //disable textboxes
            fnBox.Enabled = false;
            lnBox.Enabled = false;
            addressBox.Enabled = false;
            cityBox.Enabled = false;
            stateBox.Enabled = false;
            zipBox.Enabled = false;
            phoneBox.Enabled = false;
            emailBox.Enabled = false;
            idBox.Enabled = false;
        }


        //generates a random customer id
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
    }
}
