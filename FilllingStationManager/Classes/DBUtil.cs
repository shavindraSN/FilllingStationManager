using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingStationManager.Classes
{
    class DBUtil
    {
        /*
         *This class does low level interaction with Database
         *This class does following Types of interactions
         *1.a. Establishing connection with the database
         *  b. Catching exceptions and giving relevant error message when error is caught
         *2.a. Reading Database and return Dataset object. SQL Query is the parameter
         *  b. Error message is generated and popped-up when error is caught.
         *3.a. Write Data to database. This include Inserting, Updating and Deleting data from the database
         *  b. Pop-up different type of error messages. Primary key duplication, deletion cannot be done because its
         *     foreign key
         * All the exceptions are send to the developer
         */

        static SqlConnection conn;

        // Default Database should be newFSMSDB
        // For Testing it is change to Test2
        public void connectToDB()
        {
            try
            {
                String connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=nwFSMSDB";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message.ToString() + "\n Error Statistics will be sent to investigation", "An error occured while Connecting to database");

                String subject = ex.Message.Substring(0, 40);
                subject = subject.Replace("'", "''");

                String ErrorEmailBody = @"Class: " + this.GetType().Name + "\n";
                ErrorEmailBody += @"Method: writeToDB()\n";
                ErrorEmailBody += @"Exception: " + ex.ToString();
                Email email = new Email();
                ErrorEmailBody = ErrorEmailBody.Replace("'", "''");
                email.sendErrorEmail(subject, ErrorEmailBody);
            }

        }

        // This method will close the connection
        public void closeConnection()
        {
            conn.Close();
        }

        // This method is used to write to database
        // Following types of changes can be made to database using this method
        // 1. Insert new row to database
        // 2. Update existing row
        // 3. Delete row
        // Return: Number of affected rows
        // Parameter: SQL Query
        public int writeToDB(String query)
        {
            if (conn == null)
            {
                connectToDB();
            }

            SqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = query;
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //Send Exception Statistics to Developer Email      
                
                MessageBox.Show(ex.GetBaseException().Message.ToString() + "\n Error Statistics will be sent to investigation", "An error occured while writing to database");

                String subject = ex.Message.Substring(0, 40);
                subject = subject.Replace("'", "''");
 
                String ErrorEmailBody = @"Class: "+this.GetType().Name+"\n";
                ErrorEmailBody += @"Method: writeToDB()\n";
                ErrorEmailBody += @"Exception: " + ex.ToString();
                Email email = new Email();
                ErrorEmailBody = ErrorEmailBody.Replace("'", "''");
                email.saveErrorEmail(subject, ErrorEmailBody, email.sendErrorEmail(subject, ErrorEmailBody));
            }
            return -1;
        }

        public SqlDataReader readFromDB(String Query)
        {
            if (conn == null)
            {
                connectToDB();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                //Send Exception Statistics to Developer Email
                MessageBox.Show(ex.GetBaseException().Message.ToString() + "\n Error Statistics will be sent to investigation", "An error occured while Reading from database");

                String subject = ex.Message.Substring(0, 22);
                subject = subject.Replace("'", "''");

                String ErrorEmailBody = @"Class: " + this.GetType().Name + "\n";
                ErrorEmailBody += @"Method: readFromDB()\n";
                ErrorEmailBody += @"Exception: " + ex.ToString();
                Email email = new Email();
                ErrorEmailBody = ErrorEmailBody.Replace("'", "''");
                email.saveErrorEmail(subject, ErrorEmailBody, email.sendErrorEmail(subject, ErrorEmailBody));
            
            }
            return null;
        }
    }
}
