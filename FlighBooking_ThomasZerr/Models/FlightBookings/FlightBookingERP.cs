using System;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingERP : IFlightBooking
    {
        private IProxyFlightBooking _proxyFlightBooking;

        public IFlightBookingData FlightBookingData { get; }

        public FlightBookingERP(IProxyFlightBooking proxyFlightBooking, IFlightBookingData flightBookingData)
        {
            _proxyFlightBooking = proxyFlightBooking;
            FlightBookingData = flightBookingData;
        }

        public void Confirm()
        {
            ProxyResponse response = _proxyFlightBooking.FlightBookingConfirm(FlightBookingData);

            HandleIsError(response.ReturnCode, response.Message);

            FlightBookingData.ConfirmFlight();

        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }

        public void Cancel()
        {
            ProxyResponse response = _proxyFlightBooking.FlightBookingCancel(FlightBookingData);

            HandleIsError(response.ReturnCode, response.Message);

            FlightBookingData.Cancelled = true;
        }
    }
}
