using System;
using System.Text.RegularExpressions;

namespace FlighBooking_ThomasZerr.Models.Validators
{
    class CustomerIdValidator : IValidator
    {
        public int MaxLength { get; set; }

        public void IsValidElseThrowException(object value)
        {
            if (value is string customerId)
            {
                if (customerId.Length == 0)
                    throw new Exception("Kundennummer darf nicht leer sein");

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
