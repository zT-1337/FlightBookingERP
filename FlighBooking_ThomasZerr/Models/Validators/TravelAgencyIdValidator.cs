using System;
using System.Text.RegularExpressions;

namespace FlighBooking_ThomasZerr.Models.Validators
{
    class TravelAgencyIdValidator : IValidator
    {
        public int MaxLength { get; set; }

        public object ExtraParam { get; set; }
        public void IsValidElseThrowException(object value)
        {
            if (value is string travelAgencyId)
            {
                if(travelAgencyId.Length == 0)
                    throw new Exception("Reisebüro darf nicht leer sein");

                if(travelAgencyId.Length > MaxLength)
                    throw new Exception("Reisebüro darf nur maximal 8 Ziffern lang sein");

                if(!Regex.IsMatch(travelAgencyId, "^[0-9]*$"))
                    throw new Exception("Reisebüro darf nur Ziffern enthalten");

                return;
            }

            throw new ArgumentException();
        }
    }
}
