using System;
using System.Text.RegularExpressions;

namespace FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators
{
    class CustomerIdValidator : ICustomerIdValidator
    {
        public int MaxLength { get; set; }

        public void IsValidElseThrowException(object value)
        {
            if (value is string customerId)
            {
                if (customerId.Length > MaxLength)
                    throw new Exception("Kundennummer darf nur maximal 8 Ziffern lang sein");

                if (!Regex.IsMatch(customerId, "^[0-9]*$"))
                    throw new Exception("Kundennummer darf nur Ziffern enthalten");

                return;
            }

            throw new ArgumentException();
        }
    }
}
