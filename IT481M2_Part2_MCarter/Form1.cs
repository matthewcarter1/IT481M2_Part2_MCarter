using IT481M2_Part2_MCarter.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT481M2_Part2_MCarter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a new instance of the BusinessAccessLayer class
            BusAccessLayer bus = new BusAccessLayer();
            string server = comboBox1.SelectedItem.ToString();
            string database = comboBox2.SelectedItem.ToString();
            string user = comboBox3.SelectedItem.ToString();
            string pass = textBox1.Text;
            string table = comboBox4.SelectedItem.ToString();

            // check if the user has selected an item from the combo boxes and if the text box is not empty
            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(table))
            {
                // show an error message if the user has not entered all the required information
                MessageBox.Show("Please make sure you have selected an item from each combo box and entered a password.");
                return;
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = bus.SelectClients(server, database, user, pass, table);
            dataGridView1.DataSource = bs;
            richTextBox1.Text = bus.CountClients(server, database, user, pass, table);
        }
    }
}
