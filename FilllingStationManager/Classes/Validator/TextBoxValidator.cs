using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingStationManager.Classes.Validator
{
    /*
     * This class validate Textboxes
     */
    class TextBoxValidator
    {

        StringValidator sv = new StringValidator();

        public Boolean isEmpty(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (sv.isNull(textBox.Text))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean isNumber(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
               
            }
            return false;
        }

        public Boolean isInteger(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {

            }

            return false;
        }
    }
}
