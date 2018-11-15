using System;

namespace FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators
{
    class DateRangeValidator : IDateRangeValidator
    {
        public DateTime LaterDateTime { get; set; }

        public void IsValidElseThrowException(object value)
        {
            if (value is DateTime earlierDate)
            {
                if (DateTime.Compare(earlierDate, LaterDateTime) > 0)
                    throw new Exception("Startdatum darf nicht vor dem Enddatum liegen");

                return;
            }

            throw new ArgumentException();
        }
    }
}
