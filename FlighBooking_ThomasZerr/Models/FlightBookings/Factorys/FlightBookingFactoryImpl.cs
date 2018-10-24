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
        private IProxyFlightBooking _proxyFlightBooking;

        public FlightBookingFactoryImpl(IProxyFlightBooking proxyFlightBooking)
        {
            _proxyFlightBooking = proxyFlightBooking;
        }

        public IFlightBooking Create(IFlightBookingData args)
        {
            ProxyFlightBookingResponse flightBookingResponse = _proxyFlightBooking.Create(args);

            HandleIsError(flightBookingResponse.ReturnCode, flightBookingResponse.Message);

            args.FlightData.AirlineId = flightBookingResponse.FlightBookingData.FlightData.AirlineId;
            args.BookingId = flightBookingResponse.FlightBookingData.BookingId;
            return new FlightBookingImpl(_proxyFlightBooking, args);
        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }

        public IFlightBooking[] RetrieveAll(IFlightBookingData args)
        {
            ProxyFlightBookingResponse flightBookingResponses = _proxyFlightBooking.GetList(args);

            HandleIsError(flightBookingResponses.ReturnCode, flightBookingResponses.Message);

            List<IFlightBooking> flightBookings = new List<IFlightBooking>();
            foreach (var flightBookingData in flightBookingResponses.FlightBookingDatas)
            {
                flightBookings.Add(new FlightBookingImpl(_proxyFlightBooking, flightBookingData));
            }

            return flightBookings.ToArray();
        }
    }
}
