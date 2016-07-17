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
     * Inherit basic validation methods
     */
    class TextBoxValidator: Validator
    {
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
                if (isEmpty(textBox.Text))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check all the given TextBoxes are contains only numbers.
        /// If all the textboxes contains numbers returns true else return false
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns>Returns true or false.</returns>
        public Boolean isNumber(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if(!isNumber(textBoxes))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks all the given TextBoxes are contains Integers
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns>Returns true or false</returns>
        public Boolean isInt(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if(!isInt(textBox.Text))
                {
                    return false;
                }
            }
            return false;
        }
    }
}
