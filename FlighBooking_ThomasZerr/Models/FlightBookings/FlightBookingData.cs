using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingData
    {
        //TODO ist Airline und AirlineId das gleiche?
        public string AirlineId { get; set; }
        public string Airline { get; set; }
        public string BookingNumber { get; set; }
        public string TestRun { get; set; }
        public string ReserveOnly { get; set; }
        public string CustomerNumber { get; set; }
        public int MaxRows { get; set; }
        public bool MaxRowsSpecified { get; set; }
        public string TravelAgency { get; set; }

    }
}
