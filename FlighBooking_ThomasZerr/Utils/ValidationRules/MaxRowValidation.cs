using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlighBooking_ThomasZerr.Utils.ValidationRules
{
    class MaxRowValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string numberStr)
            {
                int number;

                try
                {
                    number = int.Parse(numberStr);
                }
                catch (Exception e)
                {
                    return new ValidationResult(false, "Muss eine ganze Zahl sein");
                }
                

                if(number < 0)
                    return new ValidationResult(false, "Muss positiv sein");

                return new ValidationResult(true, "Muss positiv und ganzzahlig sein");
            }

            throw new ArgumentException();
        }
    }
}
