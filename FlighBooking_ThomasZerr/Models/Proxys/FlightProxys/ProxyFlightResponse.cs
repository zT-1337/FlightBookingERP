using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    class ProxyFlightResponse
    {
        public ReturnCodeProxys ReturnCode { get; set; }
        public string Message { get; set; }
        public string MessageNumber { get; set; }
        public IFlightData[] FlightDatas { get; set; }
    }
}
