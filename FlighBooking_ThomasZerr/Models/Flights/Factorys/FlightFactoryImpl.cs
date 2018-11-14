using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;

namespace FlighBooking_ThomasZerr.Models.Flights.Factorys
{
    class FlightFactoryImpl : IFlightFactory
    {
        private readonly ProxyFlight proxyFlight_;

        public FlightFactoryImpl(ProxyFlight proxyFlight)
        {
            proxyFlight_ = proxyFlight;
        }

        public IFlight[] Retrieve(IFlightData data, IDateRange flightDateRangeArg, int maxResultsArg, bool isMaxResultActive)
        {
            IFlightData[] flightDatas = proxyFlight_.GetList(data, flightDateRangeArg, maxResultsArg, isMaxResultActive);

            IFlight[] flights = new IFlight[flightDatas.Length];
            for (int i = 0; i < flights.Length; ++i)
            {
                flights[i] = new FlightImpl(proxyFlight_, flightDatas[i]);
            }

            return flights;
        }
    }
}
