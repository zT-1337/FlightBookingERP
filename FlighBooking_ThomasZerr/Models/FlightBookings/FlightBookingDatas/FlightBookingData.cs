using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    class FlightBookingData
    {
        //TODO Eventuell in bessere Datentypen umwandeln
        public string AirlineId { get; set; }
        public string BookingId { get; set; }
        public string ConnectId { get; set; }
        public string Flightdate { get; set; }
        public string CustomerId { get; set; }
        public string Class { get; set; }
        public string Bookdate { get; set; }
        public string Counter { get; set; }
        public string AgencyId { get; set; }
        public string PassagierName { get; set; }
        //TODO in bool ändern
        public string Reserved { get; set; }
        public string Cancelled { get; set; }

        public string AirlineName { get; set; }
        public string TravelAgency { get; set; }
        //TODO aus dieser Klasse schmeißen
        public DateRange BookingDateRange { get; set; }
        public DateRange FlightDateRange { get; set; }

    }
}
