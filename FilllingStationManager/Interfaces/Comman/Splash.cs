using iTuner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingStationManager.Interfaces.Comman
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            ReportAvailability();

            NetworkStatus.AvailabilityChanged +=
                new NetworkStatusChangedHandler(DoAvailabilityChanged);
        }

        static void DoAvailabilityChanged(
           object sender, NetworkStatusChangedArgs e)
        {
            ReportAvailability();
        }

        private static void ReportAvailability()
        {
            if (NetworkStatus.IsAvailable)
            {
                MessageBox.Show("Connection Availble");
            }
            else
            {
                MessageBox.Show("Connection Not Available");
            }
        }
    }
}
