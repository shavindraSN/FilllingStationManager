using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingStationManager.Interfaces.TestInterfaces
{
    public partial class EmailAndInternet : Form
    {
        private readonly BackgroundWorker bak = new BackgroundWorker();
        public EmailAndInternet()
        {
            InitializeComponent();
            bak.DoWork += bak_DoWork;
        }

        //Concurrent thread to be executed
        private void bak_DoWork(object sender, DoWorkEventArgs e)
        {
            Classes.InternetConnection ic = new Classes.InternetConnection();

            if (ic.isConnected())
            {
                Classes.Email email = new Classes.Email();
                int stat = email.sendEmail(txtTo.Text, txtSubject.Text, txtMessage.Text);
                if (stat == 0)
                    MessageBox.Show("Successfully Sent");
                else
                    MessageBox.Show("Not Sent");
            }
            else
                MessageBox.Show("Could not send the email because Internet is not availble", "No internet Connection");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.InternetConnection ic = new Classes.InternetConnection();
            bool x = ic.isConnected();

            if(x)
                MessageBox.Show("Internet is Available", "Connected");
            else
                MessageBox.Show("Internet is not Availble", "Not Connected");
        }

        // This is Click event of Send email
        private void button2_Click(object sender, EventArgs e)
        {
            bak.RunWorkerAsync();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.InternetConnection ic = new Classes.InternetConnection();

            if (ic.isConnected())
            {
                Classes.Email email = new Classes.Email();
                int stat = email.sendEmail(txtTo.Text, txtSubject.Text, txtMessage.Text,@"E:\a.png");
                if (stat == 0)
                    MessageBox.Show("Successfully Sent");
                else
                    MessageBox.Show("Not Sent");
            }
            else
                MessageBox.Show("Could not send the email because Internet is not availble", "No internet Connection");
           
        }
    }
}
