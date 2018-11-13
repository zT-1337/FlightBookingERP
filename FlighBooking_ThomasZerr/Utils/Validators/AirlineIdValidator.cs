using System;

namespace FlighBooking_ThomasZerr.Utils.Validators
{
    class AirlineIdValidator : IValidator
    {
        public int MaxLength { get; set; }

        public object ExtraParam { get; set; }

        public void IsValid(object value)
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
