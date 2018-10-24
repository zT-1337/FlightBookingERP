using System;
using System.Collections.Generic;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    class FlightBookingFactoryERP : IFlightBookingFactory
    {
        private IProxyFlightBooking _proxyFlightBooking;

        public FlightBookingFactoryERP(IProxyFlightBooking proxyFlightBooking)
        {
            _proxyFlightBooking = proxyFlightBooking;
        }

        public IFlightBooking Create(IFlightBookingData args)
        {
            ProxyResponse response = _proxyFlightBooking.FlightBookingCreateFromData(args);

            HandleIsError(response.ReturnCode, response.Message);

            args.AirlineId = response.FlightBookingData.AirlineId;
            args.BookingId = response.FlightBookingData.BookingId;
            return new FlightBookingERP(_proxyFlightBooking, args);
        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }

        public IFlightBooking[] RetrieveAll(IFlightBookingData args)
        {
            ProxyResponse responses = _proxyFlightBooking.FlightBookingGetList(args);

            HandleIsError(responses.ReturnCode, responses.Message);

            List<IFlightBooking> flightBookings = new List<IFlightBooking>();
            foreach (var flightBookingData in responses.FlightBookingDatas)
            {
                flightBookings.Add(new FlightBookingERP(_proxyFlightBooking, flightBookingData));
            }

            return flightBookings.ToArray();
        }
    }
}
