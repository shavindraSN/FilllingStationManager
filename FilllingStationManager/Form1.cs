using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTuner;
using System.Data.SqlClient;

namespace FillingStationManager
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime n = DateTime.Now;
            MessageBox.Show(n.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            String q = "Insert into one Values(" + Convert.ToInt32(txtID.Text) + ", '" + txtName.Text + "')";
            Classes.DBUtil dbu = new Classes.DBUtil();
            int x = dbu.writeToDB(q);

            MessageBox.Show(x.ToString() + "number of rows affected");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Classes.DBUtil dbu = new Classes.DBUtil();
            SqlDataReader db = dbu.readFromDB("SELECT * FROM Emp");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Classes.DBUtil db = new Classes.DBUtil();
            db.connectToDB();
        }

       

       
    }
}
