using System;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingImpl : IFlightBooking
    {
        private IProxyFlightBooking _proxyFlightBooking;

        public IFlightBookingData FlightBookingData { get; }

        public FlightBookingImpl(IProxyFlightBooking proxyFlightBooking, IFlightBookingData flightBookingData)
        {
            _proxyFlightBooking = proxyFlightBooking;
            FlightBookingData = flightBookingData;
        }

        public void Confirm()
        {
            ProxyFlightBookingResponse flightBookingResponse = _proxyFlightBooking.Confirm(FlightBookingData);

            HandleIsError(flightBookingResponse.ReturnCode, flightBookingResponse.Message);

            FlightBookingData.Confirmed = true;

        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }

        public void Cancel()
        {
            ProxyFlightBookingResponse flightBookingResponse = _proxyFlightBooking.Cancel(FlightBookingData);

            HandleIsError(flightBookingResponse.ReturnCode, flightBookingResponse.Message);

            FlightBookingData.Cancelled = true;
        }
    }
}
