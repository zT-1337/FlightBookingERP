using System;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges
{
    public interface IDateRange
    {
        DateTime EarlierDateTime { get; set; }
        string EarlierDate { get; set; }

        DateTime LaterDateTime { get; set; }
        string LaterDate { get; set; }

        DateRangeOption Option { get; set; }
    }
}
