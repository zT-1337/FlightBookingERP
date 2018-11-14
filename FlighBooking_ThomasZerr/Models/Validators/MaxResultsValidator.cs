using System;

namespace FlighBooking_ThomasZerr.Models.Validators
{
    class MaxResultsValidator : IValidator
    {
        public void IsValidElseThrowException(object value)
        {
            if (value is int maxResults)
            {
                if(maxResults < 0)
                    throw new Exception("MaxResults muss positiv sein");

                return;
            }

            throw new ArgumentException("Int erwartet");
        }
    }
}
