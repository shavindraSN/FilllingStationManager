using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class is to check String validation
 * 
 */
namespace FillingStationManager.Classes.Validator
{
    class StringValidator
    {
        public Boolean isNull(String value)
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
    }
}
