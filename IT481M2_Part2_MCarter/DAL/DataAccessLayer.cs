using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT481M2_Part2_MCarter.DAL
{
    internal class DataAccessLayer
    {
        string dtable, dserver, ddatabase, duser, dpass;
        public string connString;
        //SqlDataReader reader; // Initialize reader

        // Constructor that takes a connection string(s)
        public DataAccessLayer(string bserver, string bdatabase, string buser, string bpass, string btable) // Define a constructor that takes the necessary connection string parameters
        {
            dserver = bserver;
            ddatabase = bdatabase;
            duser = buser;
            dpass = bpass;
            dtable = btable;

            connString = @"Data Source=" + dserver + ";Initial Catalog=" + ddatabase + ";User Id=" + duser + ";Password=" + dpass + ";TrustServerCertificate=true;"; // Build the connection string using the parameters
            //connString = @"Server=" + dserver + ";" + "Database=" + ddatabase + ";" + "Trusted_Connection=True;";
            //MessageBox.Show(connString);
        }

        // Methods
        public DataTable SelectClients() // Define a method to retrieve customer names from the database
        {
            DataTable table = new DataTable();

            try
            {
                // code that accesses the database goes here
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open(); // Open the connection

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM " + dtable;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            table.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // handle the exception here
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
        }



        public string CountClients()
        {
            string readOut = null; // Declare a string variable to store the results

            try
            {
                // code that accesses the database goes here
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open(); // Open the connection

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn; // Set the connection property of the SQL command object to the SQL connection
                        cmd.CommandText = "SELECT COUNT(*) FROM " + dtable; // Set the command text to the COUNT query

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read()) // Loop through the results
                                {
                                    readOut = reader.GetValue(0) + "\n"; // Concatenate the count to the readOut string
                                }
                            }
                            else
                            {
                                readOut = "No rows found."; // Set the readOut string to a default message
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // handle the exception here
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return readOut; // Return the results
        }
    }
}