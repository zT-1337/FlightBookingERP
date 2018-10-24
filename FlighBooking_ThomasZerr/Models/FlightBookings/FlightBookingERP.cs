using System;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingERP : IFlightBooking
    {
        private IProxyFlightBookingSAP _proxyFlightBookingSap;

        public IFlightBookingData FlightBookingData { get; }

        public FlightBookingERP(IProxyFlightBookingSAP proxyFlightBookingSap, IFlightBookingData flightBookingData)
        {
            _proxyFlightBookingSap = proxyFlightBookingSap;
            FlightBookingData = flightBookingData;
        }

        public void Confirm()
        {
            ProxyResponseERP response = _proxyFlightBookingSap.FlightBookingConfirm(FlightBookingData);

            HandleIsError(response.ReturnCode, response.Message);

            FlightBookingData.ConfirmFlight();

        }

        private void HandleIsError(ReturnCodeERP returnCode, string message)
        {
            if (returnCode == ReturnCodeERP.Error || returnCode == ReturnCodeERP.Abort)
                throw new InvalidOperationException(message);
        }

        public void Cancel()
        {
            ProxyResponseERP response = _proxyFlightBookingSap.FlightBookingCancel(FlightBookingData);

            HandleIsError(response.ReturnCode, response.Message);

            FlightBookingData.Cancelled = true;
        }
    }
}
