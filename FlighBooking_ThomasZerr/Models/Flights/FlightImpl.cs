using System;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;

namespace FlighBooking_ThomasZerr.Models.Flights
{
    class FlightImpl : IFlight
    {
        private IProxyFlight proxyFlight_;

        public IFlightData FlightData { get; }

        public FlightImpl(IProxyFlight proxyFlight, IFlightData flightData)
        {
            proxyFlight_ = proxyFlight;
            FlightData = flightData;
        }

        public bool IsExisting()
        {
            ProxyFlightResponse proxyFlightResponse = proxyFlight_.IsExisting(FlightData);
            return proxyFlightResponse.ReturnCode == ReturnCodeProxys.Success;
        }
    }
}
