using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace COMPE561_Lab05
{
    public partial class bookForm : Form
    {
        //"key" to the database
        const string connection_keycard = "datasource=127.0.0.1;port=3306;username=root;password=;database=lab5";

        //form init
        public bookForm()
        {
            InitializeComponent();

            //populate the combo box
            populateDropdown();

            //set the form to default/edit mode
            resetOrEdit();
        }


        private void bookForm_Load(object sender, EventArgs e)
        {

        }


        //save button: checks all textboxes for valid input, then updates/adds information to the database
        private void saveButton_Click(object sender, EventArgs e)
        {
            //use regular expressions to detect proper/improper user inputs
            Regex RX1 = new Regex("^[a-zA-Z]{1,30}$"); //regex for author
            Regex RX2 = new Regex("^[0-9]{5}$"); //regex for isbn
            Regex RX3 = new Regex("^[0-9]{1,4}.[0-9]{2}$"); //regex for price

            bool perfectInput = true; //this flag becomes false if any input field is found invalid

            //validate user input
            if (!RX1.IsMatch(authorBox.Text))
            {
                MessageBox.Show("Please enter a valid author name. Only alphabetical characters permitted.");
                perfectInput = false;
            }
            else if (!RX2.IsMatch(isbnBox.Text))
            {
                MessageBox.Show("Please enter a valid 5-digit ISBN.");
                perfectInput = false;
            }
            else if (!RX3.IsMatch(priceBox.Text))
            {
                MessageBox.Show("Please enter a valid amount similar to the following format: [75.00]");
                perfectInput = false;
            }

            //only proceed if all input fields are valid
            if (perfectInput)
            {
                //create a connection "portal" to the database using the "keycard" string
                MySqlConnection dbPortal = new MySqlConnection(connection_keycard);

                //if editing an existing book (it should be selected in the combo box)
                if (!(bookDropdown.SelectedItem is null))
                {
                    //
                    string query = 
                        "UPDATE book " +
                        $"SET title = '{titleBox.Text}', author = '{authorBox.Text}', isbn = {isbnBox.Text}, price = {priceBox.Text} " +
                        "WHERE 1;";

                    //TODO
                }

                //if adding a new book (no combo box selection)
                else
                {
                    //create a command object using the "portal" object, and a SQL query that inserts a row of data into the database's "book" table
                    string query = 
                        "INSERT INTO book (title, author, isbn, price) " +
                        $"VALUES ('{titleBox.Text}', '{authorBox.Text}', {isbnBox.Text}, {priceBox.Text});";
                    MySqlCommand insertion_command = new MySqlCommand(query, dbPortal);
                    insertion_command.CommandTimeout = 30; //ensure the command doesn't take too long

                    //open the "portal" and insert data
                    try
                    {
                        dbPortal.Open();
                        insertion_command.ExecuteNonQuery();

                        //confirm success, refresh the combo box, clean up the form
                        MessageBox.Show("New book data successfully saved.");
                        populateDropdown();
                        resetOrEdit();
                    }

                    catch (Exception err)
                    {
                        MessageBox.Show($"ERROR: {err.Message}");
                        MessageBox.Show("Failed to record book information. Please contact the admin.");
                    }
                }
            }
        }


        //new book button: sets the form to new book mode
        private void newbookButton_Click(object sender, EventArgs e)
        {
            bookDropdown.SelectedItem = null; //clear combo box selection
            bookDropdown.Enabled = false; //disable combo box

            //clear textboxes
            titleBox.Text = null;
            authorBox.Text = null;
            isbnBox.Text = null;
            priceBox.Text = null;

            //enable textboxes
            titleBox.Enabled = true;
            authorBox.Enabled = true;
            isbnBox.Enabled = true;
            priceBox.Enabled = true;

            titleBox.Focus(); //set focus to first name textbox
        }


        //cancel button: resets the form to default/edit mode
        private void cancelButton_Click(object sender, EventArgs e)
        {
            resetOrEdit();
        }


        //back button: stow the current form and return to the main menu
        private void backButton_Click(object sender, EventArgs e)
        {
            
        }


        //combo box select: enables all textboxes, displays information in textboxes based on selection
        private void bookDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //"awaken" the form
            titleBox.Enabled = true;
            authorBox.Enabled = true;
            isbnBox.Enabled = true;
            priceBox.Enabled = true;

            //if an item is chosen, populate the textboxes
            if (!(bookDropdown.SelectedItem is null))
            {
                //obtain the selected object
                book selected_book = bookDropdown.SelectedItem as book;

                //access its properties and display them
                titleBox.Text = selected_book.title;
                authorBox.Text = selected_book.author;
                isbnBox.Text = selected_book.isbn;
                priceBox.Text = selected_book.price;
            }

            //if there is no selection, ensure the form does not "awaken"
            else
            {
                resetOrEdit();
            }
        }


        //instantiates book objects and wires them to the combo box
        private void populateDropdown()
        {
            //create a list to contain book objects read from the database
            List<book> bList = new List<book>();

            //create a connection "portal" to the database using the "keycard" string
            MySqlConnection dbPortal = new MySqlConnection(connection_keycard);

            //create a command object using the "portal" object, and a SQL query that reads all information from the database's "book" table
            string query = "SELECT * FROM book";
            MySqlCommand read_command = new MySqlCommand(query, dbPortal);
            read_command.CommandTimeout = 30; //ensure the command doesn't take too long

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
            bookDropdown.DataSource = bList;
        }


        //resets the form to default mode (edit book mode)
        private void resetOrEdit()
        {
            bookDropdown.SelectedItem = null; //clear combo box selection
            bookDropdown.Enabled = true; //enable combo box

            //clear textboxes
            titleBox.Text = null;
            authorBox.Text = null;
            isbnBox.Text = null;
            priceBox.Text = null;

            //disable textboxes
            titleBox.Enabled = false;
            authorBox.Enabled = false;
            isbnBox.Enabled = false;
            priceBox.Enabled = false;
        }
    }
}

//TODO: finish implementing edit features on the save button
//ask user for confirmation on save and mention whether its edit or new
//ask for cancel confirmation