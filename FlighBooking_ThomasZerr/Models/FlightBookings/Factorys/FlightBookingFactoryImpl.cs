using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.SearchDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    class FlightBookingFactoryImpl : IFlightBookingFactory
    {
        private readonly ProxyFlightBooking proxyFlightBooking_;

        public FlightBookingFactoryImpl(ProxyFlightBooking proxyFlightBooking)
        {
            proxyFlightBooking_ = proxyFlightBooking;
        }

        public IFlightBooking Create(IFlightBookingData args)
        {
            IFlightBookingData flightBookingData = proxyFlightBooking_.Create(args);

            args.FlightData.AirlineId = flightBookingData.FlightData.AirlineId;
            args.BookingId = flightBookingData.BookingId;
            return new FlightBookingImpl(proxyFlightBooking_, args);
        }

        public IFlightBooking[] Retrieve(IFlightBookingData args, ISearchData searchData)
        {
            IFlightBookingData[] flightBookingDatas = proxyFlightBooking_.GetList(args, searchData);

            IFlightBooking[] flightBookings = new IFlightBooking[flightBookingDatas.Length];
            for (int i = 0; i < flightBookings.Length; ++i)
            {
                flightBookings[i] = new FlightBookingImpl(proxyFlightBooking_, flightBookingDatas[i]);
            }

            return flightBookings;
        }
    }
}
