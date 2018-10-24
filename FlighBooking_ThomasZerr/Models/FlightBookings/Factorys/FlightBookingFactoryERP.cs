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
        private IProxyFlightBookingSAP _proxyFlightBookingSap;

        public FlightBookingFactoryERP(IProxyFlightBookingSAP proxyFlightBookingSap)
        {
            _proxyFlightBookingSap = proxyFlightBookingSap;
        }

        public IFlightBooking Create(IFlightBookingData args)
        {
            ProxyResponseERP response = _proxyFlightBookingSap.FlightBookingCreateFromData(args);

            HandleIsError(response.ReturnCode, response.Message);

            args.AirlineId = response.FlightBookingData.AirlineId;
            args.BookingId = response.FlightBookingData.BookingId;
            return new FlightBookingERP(_proxyFlightBookingSap, args);
        }

        private void HandleIsError(ReturnCodeERP returnCode, string message)
        {
            if (returnCode == ReturnCodeERP.Error || returnCode == ReturnCodeERP.Abort)
                throw new InvalidOperationException(message);
        }

        public IFlightBooking[] RetrieveAll(IFlightBookingData args)
        {
            ProxyResponseERP responses = _proxyFlightBookingSap.FlightBookingGetList(args);

            HandleIsError(responses.ReturnCode, responses.Message);

            List<IFlightBooking> flightBookings = new List<IFlightBooking>();
            foreach (var flightBookingData in responses.FlightBookingDatas)
            {
                flightBookings.Add(new FlightBookingERP(_proxyFlightBookingSap, flightBookingData));
            }

            return flightBookings.ToArray();
        }
    }
}
