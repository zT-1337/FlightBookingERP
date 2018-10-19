using System;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingERP : IFlightBooking
    {
        private IProxyERP proxyERP_;

        public IFlightBookingData FlightBookingData { get; }

        public FlightBookingERP(IProxyERP proxyERP, IFlightBookingData flightBookingData)
        {
            proxyERP_ = proxyERP;
            FlightBookingData = flightBookingData;
        }

        public void Confirm()
        {
            ProxyResponseERP response = proxyERP_.FlightBookingConfirm(FlightBookingData);

            HandleIsError(response.ReturnCode, response.Message);
            HandleIsWarning(response.ReturnCode, response.Message);

            FlightBookingData.ConfirmFlight();

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

        public void Cancel()
        {
            ProxyResponseERP response = proxyERP_.FlightBookingCancel(FlightBookingData);

            HandleIsError(response.ReturnCode, response.Message);
            HandleIsWarning(response.ReturnCode, response.Message);

            FlightBookingData.Cancelled = true;
        }
    }
}
