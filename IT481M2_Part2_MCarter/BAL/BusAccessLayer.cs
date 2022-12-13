using IT481M2_Part2_MCarter.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481M2_Part2_MCarter.BAL
{
    internal class BusAccessLayer
    {
        string btable, bserver, bdatabase, buser, bpass;
        // this method selects the clients from the database and returns them as a string
        public DataTable SelectClients(string server, string database, string user, string pass, string table)
        {
            btable = table;
            bserver = server;
            bdatabase = database;
            buser = user;
            bpass = pass;

            // create an empty DataTable to return in case the user is not authorized to access a table
            DataTable dt = new DataTable();

            // check the user's name and only allow them to access the table they are authorized to access
            if (user == "User_HR" && table != "Employees")
            {
                return dt;
            }
            else if (user == "User_Sales" && table == "Employees")
            {
                return dt;
            }

            // create a new instance of the DataAccessLayer class
            DataAccessLayer dataAccessLayer = new DataAccessLayer(bserver, bdatabase, buser, bpass, btable);

            // call the SelectClients() method on the DataAccessLayer instance
            // and return the results as a string
            return dataAccessLayer.SelectClients();
        }

        // this method counts the number of clients in the database and returns the result as a string
        public string CountClients(string server, string database, string user, string pass, string table)
        {
            btable = table;
            bserver = server;
            bdatabase = database;
            buser = user;
            bpass = pass;

            // check the user's name and only allow them to access the table they are authorized to access
            if (user == "User_HR" && table != "Employees")
            {
                return "Not Alowed";
            }
            else if (user == "User_Sales" && table == "Employees")
            {
                return "Not Allowed";
            }

            // create a new instance of the DataAccessLayer class
            DataAccessLayer dataAccessLayer = new DataAccessLayer(bserver, bdatabase, buser, bpass, btable);

            // call the CountClients() method on the DataAccessLayer instance
            // and return the results as a string
            return dataAccessLayer.CountClients();
        }    
    }
}
