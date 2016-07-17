using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingStationManager.Classes.Validator
{
    class Validator
    {
        /// <summary>
        /// Checks for numbers for given string. Number can be int or double
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns true or false</returns>
        public Boolean isNumber(String value)
        {
            int tempi;
            double tempd;

            if(int.TryParse(value, out tempi) || double.TryParse(value, out tempd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check whether given string is a Integer(Checks it can convert to integer)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns true or false</returns>
        public Boolean isInt(String value)
        {
            int tempi;
            if(int.TryParse(value, out tempi))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check whether given string is empty(null or empty)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns true or false</returns>
        public Boolean isEmpty(String value)
        {
            if (value == "" || value == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean isEmail(String value)
        {
            // Add the code to implement emails validation
            return false;
        }
    }
}
