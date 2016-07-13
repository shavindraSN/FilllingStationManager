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

        /// <summary>
        /// Check all the given TextBoxes are empty. 
        /// If any TextBox in the given set is empty, method returns true. 
        /// Otherwise returns false
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns>Returns true or false</returns>
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

        /// <summary>
        /// Check all the given TextBoxes are contains only numbers.
        /// If all the textboxes contains numbers returns true else return false
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns>Returns true or false.</returns>
        public Boolean isNumber(TextBox[] textBoxes)
        {
            int tempi;
            double tempd;
            foreach (TextBox textBox in textBoxes)
            {
                if(!int.TryParse(textBox.Text, out tempi) && double.TryParse(textBox.Text, out tempd))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean isInteger(TextBox[] textBoxes)
        {
            int tempi;
            foreach (TextBox textBox in textBoxes)
            {
                if(!int.TryParse(textBox.Text, out tempi))
                {
                    return false;
                }
            }

            return false;
        }
    }
}
