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
using System.IO;

/// <summary>
/// DATABASE TABLE [orders] STRUCTURE DETAILS:
/// [order_id, cust_id, date] columns are of type TEXT
/// [subtotal] column is of type DECIMAL(7,2)
/// [tax] column is of type DECIMAL(5,2)
/// [total] column is of type DECIMAL(8,2)
/// 
/// DATABASE TABLE [order_details] STRUCTURE DETAILS:
/// [order_id, isbn] columns are of type TEXT
/// [qty] column is of type INT(2)
/// [line_total] column is of type DECIMAL(7,2)
/// </summary>
namespace COMPE561_Lab05
{
    public partial class orderForm : Form
    {
        Form1 f; //used to reference the main form

        const string connection_keycard = "datasource=127.0.0.1;port=3306;username=root;password=;database=lab5"; //"key" to the database
        const string dest_name = "ordersummary.txt"; //receipt .txt file name
        const int timelim = 30; //command timeout time limit (seconds)
        const int idlength = 10; //order id length
        const double taxratio = 10; //tax multiplier (percent)

        //instantiate a datatable for the datagridview element
        DataTable dt = new DataTable();


        //form init
        public orderForm(Form1 mainform)
        {
            InitializeComponent();

            //create a reference to the main form
            f = mainform;

            //populate both combo boxes
            populateDropdown1();
            populateDropdown2();

            //keep certain textboxes permanently disabled
            idbox.Enabled = false;
            authorbox.Enabled = false;
            isbnbox.Enabled = false;
            pricebox.Enabled = false;
            subtotalbox.Enabled = false;
            taxbox.Enabled = false;
            totalbox.Enabled = false;

            //set up the columns of the datatable
            dt.Columns.AddRange(new DataColumn[4]
            {
                new DataColumn("Title", typeof(string)),
                new DataColumn("Price($)", typeof(string)),
                new DataColumn("Quantity", typeof(string)),
                new DataColumn("Line total($)", typeof(string))
            }
            );

            //set the datatable as the source for the datagridview
            maingrid.DataSource = dt;

            //clean the form
            reset();
        }


        private void orderForm_Load(object sender, EventArgs e)
        {

        }


        //add button: adds a row entry to the datatable based on the currently selected book and an entered quantity
        private void addbutton_Click(object sender, EventArgs e)
        {
            //if a book is selected from the combo box, proceed
            if (!(bookselDropdown.SelectedItem is null))
            {
                //obtain the currently selected book object
                book selected_book = bookselDropdown.SelectedItem as book;

                //proceed if the quantity input is valid
                if (int.TryParse(qtybox.Text, out int quantity))
                {
                    //proceed if the quantity entered is between 1 and 99
                    if (quantity == 0)
                    {
                        MessageBox.Show("Please enter a nonzero quantity.");
                        qtybox.Focus();
                    }

                    else if (quantity > 99)
                    {
                        MessageBox.Show("Buy limit is 99.");
                        qtybox.Focus();
                    }

                    else
                    {          
                        //calculate line price, add a row to the datatable, and clear the quantity textbox
                        double lineprice = Convert.ToDouble(selected_book.price) * quantity;
                        dt.Rows.Add(selected_book.title, selected_book.price, quantity.ToString(), lineprice.ToString("F"));
                        qtybox.Text = null;
                    }
                }

                else
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    qtybox.Focus();
                }
            }

            else
            {
                MessageBox.Show("Please select a book.");
                bookselDropdown.Focus();
            }
        }


        //confirm button: calculates final costs, writes to the database, and (optionally) writes a receipt .txt document
        private void confirmbutton_Click(object sender, EventArgs e)
        {
            try
            {
                //this if-statement simply serves to check if any cells exist
                //the if-check logic itself will never fail because the program will instead throw an exception if the cell doesn't exist
                if (!(dt.Rows[0][0] is null))
                {
                    //ensure a customer is selected to place the order
                    if (!(custselDropdown.SelectedItem is null))
                    {
                        //set up a yes-no dialogue prompt, and proceed only if "Yes" is chosen
                        DialogResult choice1 = MessageBox.Show("Confirm order?", "", MessageBoxButtons.YesNo);
                        if (choice1 == DialogResult.Yes)
                        {
                            double subtotal = 0; //running total for subtotal calculation
                            int count = dt.Rows.Count; //total number of entries added to datatable
                            string ordercode = gen_id(); //this order's uniquely generated id

                            //get today's date
                            DateTime today = new DateTime();
                            today = DateTime.Now;

                            //sum up the prices of all items in the datatable
                            for (int i = 0; i < count; i++)
                            {
                                double rowprice = Convert.ToDouble(dt.Rows[i][3]);
                                subtotal += rowprice;
                            }

                            //calculate tax and total
                            double tax = (Math.Ceiling(subtotal * taxratio) / 100.0); //rounds up to 2 decimal places by dividing a whole number by 100
                            double total = subtotal + tax;

                            //format all costs with 2 decimal points, and display them in their relevant textboxes
                            subtotalbox.Text = $"${subtotal.ToString("F")}";
                            taxbox.Text = $"${tax.ToString("F")}";
                            totalbox.Text = $"${total.ToString("F")}";

                            //create a connection "portal" to the database using the "keycard" string
                            MySqlConnection dbPortal = new MySqlConnection(connection_keycard);

                            //create a command object using the "portal" object, and a SQL query that inserts a row of data into the database's "orders" table
                            string query1 = "INSERT INTO orders(order_id, cust_id, subtotal, tax, total, date) " +
                                $"VALUES('{ordercode}', '{idbox.Text}', {subtotal.ToString("F")}, {tax.ToString("F")}, {total.ToString("F")}, '{today.Date.ToString("d")}');";
                            MySqlCommand command1 = new MySqlCommand(query1, dbPortal);
                            command1.CommandTimeout = timelim; //ensure the command doesn't take too long

                            //open the "portal" and insert data
                            try
                            {
                                dbPortal.Open();
                                command1.ExecuteNonQuery();
                            }

                            catch (Exception err)
                            {
                                MessageBox.Show($"ERROR: {err.Message}");
                                MessageBox.Show("Failed to record book information [CODE 001]. Please contact the admin.");
                                return;
                            }

                            //create a second command object for use with several SQL queries that insert rows of data into the database's "order_details" table
                            MySqlCommand command2;
                            for (int i=0; i < dt.Rows.Count; i++)
                            {
                                string query2 = "INSERT INTO order_details(order_id, isbn, qty, line_total) " +
                                    $"VALUES('{ordercode}', " +
                                    $"(SELECT isbn FROM book WHERE title = '{dt.Rows[i][0]}'), " +
                                    $"{dt.Rows[i][2]}, {dt.Rows[i][3]});";
                                command2 = new MySqlCommand(query2, dbPortal);
                                command2.CommandTimeout = timelim; //ensure the command doesn't take too long

                                //insert data using the already open "portal"
                                try
                                {
                                    command2.ExecuteNonQuery();
                                }

                                catch (Exception err)
                                {
                                    MessageBox.Show($"ERROR: {err.Message}");
                                    MessageBox.Show("Failed to record book information [CODE 002]. Please contact the admin.");
                                    return;
                                }
                            }                           

                            //confirm success and ask if a receipt is desired
                            MessageBox.Show("Order successfully placed!");
                            DialogResult choice2 = MessageBox.Show("Would you like to print a receipt?", "Print order summary", MessageBoxButtons.YesNo);

                            //write an order summary to a .txt file if the user wishes
                            if (choice2 == DialogResult.Yes)
                            {
                                try
                                {
                                    FileStream destination = new FileStream(dest_name, FileMode.Create, FileAccess.Write);
                                    StreamWriter print_tool = new StreamWriter(destination);

                                    print_tool.WriteLine("*****ORDER SUMMARY*****");
                                    print_tool.WriteLine("");
                                    print_tool.WriteLine($"CUSTOMER: {custselDropdown.SelectedItem}");
                                    print_tool.WriteLine($"ID: {idbox.Text}");
                                    print_tool.WriteLine($"ORDER NUMBER: {ordercode}");
                                    print_tool.WriteLine($"DATE: {today.Date.ToString("d")}");
                                    print_tool.WriteLine("");
                                    for (int j = 0; j < dt.Rows.Count; j++)
                                    {
                                        print_tool.WriteLine($"-----{dt.Rows[j][0]} (${dt.Rows[j][1]})  *{dt.Rows[j][2]}   =   ${dt.Rows[j][3]}");
                                    }
                                    print_tool.WriteLine("");
                                    print_tool.WriteLine($"SUBTOTAL: {subtotalbox.Text}");
                                    print_tool.WriteLine($"TAX: {taxbox.Text}");
                                    print_tool.WriteLine($"TOTAL: {totalbox.Text}");
                                    print_tool.WriteLine("");
                                    print_tool.WriteLine("*******THANK YOU*******");

                                    print_tool.Close();
                                    destination.Close();
                                    MessageBox.Show("Receipt successfully printed. Thank you for shopping.");
                                }

                                catch (Exception err)
                                {
                                    MessageBox.Show($"ERROR: {err.Message}");
                                    MessageBox.Show("Failed to print receipt. Please contact the administrator.");
                                }
                            }

                            //clear the datatable
                            dt.Clear();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please select customer name.");
                        custselDropdown.Focus();
                    }    
                }
            }

            catch
            {
                MessageBox.Show("Please add items to your cart before attempting to place an order.");
            }
        }


        //cancel button: allows the user to reset the form
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Are you sure you want to cancel your current order?", "Cancel order", MessageBoxButtons.YesNo);
            if (choice == DialogResult.Yes) reset();
        }


        //back button: exits the current form and restores visibility to the main menu
        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
            f.Show();
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


        //reads from the database, instantiates customer objects, and wires them to the combo box
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


        //reads from the database, instantiates book objects, and wires them to the combo box
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
