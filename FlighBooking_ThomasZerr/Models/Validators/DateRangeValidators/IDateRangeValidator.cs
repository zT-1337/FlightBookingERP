using System;

namespace FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators
{
    interface IDateRangeValidator : IValidator
    {
        DateTime LaterDateTime { get; set; }
    }
}
