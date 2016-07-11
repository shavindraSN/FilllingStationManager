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
    public partial class LubricantManagementHome : Form
    {
        public LubricantManagementHome()
        {
            InitializeComponent();
        }

        private void btnLubMngHm_MngLubDtls_Click(object sender, EventArgs e)
        {
            LubricantManagement.ManageLubricant ml = new ManageLubricant();
            ml.Visible = true;
            this.Visible = false;
        }
    }
}
