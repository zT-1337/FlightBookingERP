using System;
using System.Collections.Generic;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    class FlightBookingFactoryImpl : IFlightBookingFactory
    {
        private IProxyFlightBooking proxyFlightBooking_;

        public FlightBookingFactoryImpl(IProxyFlightBooking proxyFlightBooking)
        {
            proxyFlightBooking_ = proxyFlightBooking;
        }

        public IFlightBooking Create(IFlightBookingData args)
        {
            ProxyFlightBookingResponse proxyResponse = proxyFlightBooking_.Create(args);

            HandleIsError(proxyResponse.ReturnCode, proxyResponse.Message);

            args.FlightData.AirlineId = proxyResponse.FlightBookingData.FlightData.AirlineId;
            args.BookingId = proxyResponse.FlightBookingData.BookingId;
            return new FlightBookingImpl(proxyFlightBooking_, args);
        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }

        public IFlightBooking[] Retrieve(IFlightBookingData args)
        {
            ProxyFlightBookingResponse proxyResponse = proxyFlightBooking_.GetList(args);

            HandleIsError(proxyResponse.ReturnCode, proxyResponse.Message);

            IFlightBooking[] flightBookings = new IFlightBooking[proxyResponse.FlightBookingDatas.Length];
            for (int i = 0; i < flightBookings.Length; ++i)
            {
                flightBookings[i] = new FlightBookingImpl(proxyFlightBooking_, proxyResponse.FlightBookingDatas[i]);
            }

            return flightBookings;
        }
    }
}
