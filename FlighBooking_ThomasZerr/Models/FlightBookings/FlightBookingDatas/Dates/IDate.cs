using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates
{
    interface IDate
    {
        DateTime Date { get; set; }
        string DateString { get; set; }
    }
}
