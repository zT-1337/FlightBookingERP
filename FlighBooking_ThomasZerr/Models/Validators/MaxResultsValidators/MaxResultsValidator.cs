using System;

namespace FlighBooking_ThomasZerr.Models.Validators.MaxResultsValidators
{
    class MaxResultsValidator : IMaxResultsValidator
    {
        public void IsValidElseThrowException(object value)
        {
            if (value is int maxResults)
            {
                if(maxResults < 0)
                    throw new Exception("Anzahl Suchergebnisse muss positiv sein");

                return;
            }

            throw new ArgumentException("Int erwartet");
        }
    }
}
