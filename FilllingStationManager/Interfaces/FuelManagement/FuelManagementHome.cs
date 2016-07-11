using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilllingStationManager.Interfaces.FuelManagement
{
    public partial class FuelManagementHome : Form
    {
        public FuelManagementHome()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Interfaces.CustomerManagement.CustomerManagementHome cmh = new CustomerManagement.CustomerManagementHome();
            cmh.Visible = true;
            this.Hide();
        }
    }
}
