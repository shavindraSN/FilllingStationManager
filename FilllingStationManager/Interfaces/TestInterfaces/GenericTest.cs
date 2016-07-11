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
            TextBox[] textBoxes = { textBox1, textBox2, textBox3 };
            Classes.Validator.TextBoxValidator tbv = new Classes.Validator.TextBoxValidator();
            label1.Text = tbv.isEmpty(textBoxes).ToString();
        }
    }
}
