using System;
using System.Collections.Generic;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    class FlightBookingFactoryImpl : IFlightBookingFactory
    {
        private ProxyFlightBooking proxyFlightBooking_;

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

        public IFlightBooking[] Retrieve(IFlightBookingData args, IDateRange bookingDateRangeArg, IDateRange flightDateRangeArg,
                                        int maxResultsArg, bool isMaxResultActiveArg)
        {
            IFlightBookingData[] flightBookingDatas = proxyFlightBooking_.GetList(args, bookingDateRangeArg, flightDateRangeArg, maxResultsArg, isMaxResultActiveArg);

            IFlightBooking[] flightBookings = new IFlightBooking[flightBookingDatas.Length];
            for (int i = 0; i < flightBookings.Length; ++i)
            {
                flightBookings[i] = new FlightBookingImpl(proxyFlightBooking_, flightBookingDatas[i]);
            }

            return flightBookings;
        }
    }
}
