using System;

namespace FlighBooking_ThomasZerr.Models.Dates
{
    public interface IDate
    {
        DateTime Date { get; set; }
        string DateString { get; set; }
    }
}
