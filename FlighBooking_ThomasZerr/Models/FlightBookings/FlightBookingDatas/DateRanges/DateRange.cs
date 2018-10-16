namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges
{
    class DateRange
    {
        public string EarlierDate { get; set; }
        public string LaterDate { get; set; }
        public DateRangeOptions Options { get; set; }
        public bool IsRangeIncluded { get; set; }
    }
}
