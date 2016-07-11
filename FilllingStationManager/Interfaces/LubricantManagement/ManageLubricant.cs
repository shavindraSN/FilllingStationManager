using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilllingStationManager.Interfaces.LubricantManagement
{
    public partial class ManageLubricant : Form
    {
        public ManageLubricant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LubricantManagement.LubricantManagementHome lmh = new LubricantManagementHome();
            lmh.Visible = true;
           
        }
    }
}
