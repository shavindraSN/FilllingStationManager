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
    public partial class GenericTest : Form
    {
        public GenericTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Validator.Validator val = new Classes.Validator.Validator();
            if(val.isEmail(textBox1.Text))
            {
                label1.Text = "Is an email";
            } 
            else
            {
                label1.Text = "Not an Email";
            }
        }
    }
}
