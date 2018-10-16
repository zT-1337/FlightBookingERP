namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
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
        public string TravelAgency { get; set; }

    }
}
