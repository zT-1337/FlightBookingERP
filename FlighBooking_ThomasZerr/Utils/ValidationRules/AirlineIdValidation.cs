using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlighBooking_ThomasZerr.Utils.ValidationRules
{
    class AirlineIdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string airlineId)
            {
                if(airlineId.Length > 3)
                    return new ValidationResult(false, "Darf maximal drei Zeichen lang sein");

                return new ValidationResult(true, "Darf maximal drei Zeichen lang sein");
            }

            throw new ArgumentException();
        }
    }
}
