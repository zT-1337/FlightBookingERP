using System;
using System.Collections.Generic;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    class FlightBookingFactoryERP : IFlightBookingFactory
    {
        private IProxyERP proxyERP_;

        public FlightBookingFactoryERP(IProxyERP proxyERP)
        {
            proxyERP_ = proxyERP;
        }

        public IFlightBooking Create(FlightBookingData args)
        {
            ProxyResponseERP response = proxyERP_.FlightBookingCreateFromData(args);

            HandleIsError(response.ReturnCode, response.Message);
            HandleIsWarning(response.ReturnCode, response.Message);

            args.AirlineId = response.FlightBookingData.AirlineId;
            args.BookingId = response.FlightBookingData.BookingId;
            return new FlightBookingERP(proxyERP_, args);
        }

        private void HandleIsError(ReturnCodeERP returnCode, string message)
        {
            if (returnCode == ReturnCodeERP.Error || returnCode == ReturnCodeERP.Abort)
                throw new InvalidOperationException(message);
        }

        private void HandleIsWarning(ReturnCodeERP returnCode, string message)
        {
            if (returnCode == ReturnCodeERP.Warning)
                throw new WarningException(message);
        }

        public IFlightBooking[] RetrieveAll(FlightBookingData args)
        {
            ProxyResponseERP responses = proxyERP_.FlightBookingGetList(args);

            HandleIsError(responses.ReturnCode, responses.Message);
            HandleIsWarning(responses.ReturnCode, responses.Message);

            List<IFlightBooking> flightBookings = new List<IFlightBooking>();
            foreach (var flightBookingData in responses.FlightBookingDatas)
            {
                flightBookings.Add(new FlightBookingERP(proxyERP_, flightBookingData));
            }

            return flightBookings.ToArray();
        }
    }
}
