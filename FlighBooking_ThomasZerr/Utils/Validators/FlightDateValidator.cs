using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Utils.Validators
{
    class FlightDateValidator : IValidator
    {
        public object ExtraParam { get; set; }
        public void IsValid(object value)
        {
            if (ExtraParam is DateTime laterDate)
            {
                if (value is DateTime earlierDate)
                {
                    var temp = DateTime.Compare(earlierDate, laterDate);
                    if (DateTime.Compare(earlierDate, laterDate) > 0)
                        throw new Exception("Startdatum darf nicht vor dem Enddatum liegen");

                    return;
                }
            }

            throw new ArgumentException();
        }
    }
}
