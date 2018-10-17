using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    class ProxyResponseERP
    {
        public FlightBookingData FlightBookingData { get; set; }
        public FlightBookingData[] FlightBookingDatas { get; set; }
        public ReturnCodeERP ReturnCode { get; set; }
        public string Message { get; set; }
    }
}
