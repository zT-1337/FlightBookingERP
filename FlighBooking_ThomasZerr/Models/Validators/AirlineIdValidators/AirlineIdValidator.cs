using System;

namespace FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators
{
    class AirlineIdValidator : IAirlineIdValidator
    {
        public int MaxLength { get; set; }

        public void IsValidElseThrowException(object value)
        {
            if (value is string airlineId)
            {
                if(airlineId.Length > MaxLength)
                    throw new Exception("Fluggesellschaft darf maximal aus drei Zeichen bestehen");

                return;
            }

            throw new ArgumentException();
        }
    }
}
