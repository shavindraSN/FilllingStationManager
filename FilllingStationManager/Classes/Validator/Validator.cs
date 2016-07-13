using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingStationManager.Classes.Validator
{
    class Validator
    {
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
    }
}
