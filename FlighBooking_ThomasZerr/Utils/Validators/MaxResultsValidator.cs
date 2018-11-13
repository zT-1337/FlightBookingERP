using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Utils.Validators
{
    class MaxResultsValidator : IValidator
    {
        public object ExtraParam { get; set; }
        public void IsValid(object value)
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
