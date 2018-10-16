using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    class DateRange
    {
        public string EarlierDate { get; set; }
        public string LaterDate { get; set; }
        public DateRangeOptions Options { get; set; }
        public bool IsRangeIncluded { get; set; }
    }
}
