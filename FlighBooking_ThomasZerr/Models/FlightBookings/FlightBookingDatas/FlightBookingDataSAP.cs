using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    class FlightBookingDataSAP : IFlightBookingData
    {
        public IFlightData FlightData { get; }
        public string BookingId { get; set; }
        public string CustomerId { get; set; }
        public string Class { get; set; }
        public IDate Bookdate { get; }
        public string Counter { get; set; }
        public string AgencyId { get; set; }
        public string PassagierName { get; set; }
        public bool Reserved { get; set; }
        public bool Cancelled { get; set; }
        public bool Confirmed => !Reserved && !Cancelled;

        public IDateRange BookingDateRange { get; }
        public IDateRange FlightDateRange { get; }

        public FlightBookingDataSAP()
        {
            FlightData = new FlightDataSAP();

            var dateConverter = new DateConverterSAP();
            BookingDateRange = new DateRangeImpl(dateConverter);
            FlightDateRange = new DateRangeImpl(dateConverter);
            Bookdate = new DateImpl(dateConverter);
        }

        public void ConfirmFlight()
        {
            Reserved = false;
            Cancelled = false;
        }
    }
}
