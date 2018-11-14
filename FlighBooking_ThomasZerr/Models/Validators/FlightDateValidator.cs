using System;

namespace FlighBooking_ThomasZerr.Models.Validators
{
    class FlightDateValidator : IValidator
    {
        public void IsValidElseThrowException(object value)
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
