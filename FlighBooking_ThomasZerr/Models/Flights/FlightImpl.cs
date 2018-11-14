using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;

namespace FlighBooking_ThomasZerr.Models.Flights
{
    class FlightImpl : IFlight
    {
        private ProxyFlight proxyFlight_;

        public IFlightData FlightData { get; }

        public FlightImpl(ProxyFlight proxyFlight, IFlightData flightData)
        {
            proxyFlight_ = proxyFlight;
            FlightData = flightData;
        }
    }
}
