using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingERP : IFlightBooking
    {
        private IProxyERP proxyERP_;

        public FlightBookingData FlightBookingData { get; }

        public FlightBookingERP(IProxyERP proxyERP, FlightBookingData flightBookingData)
        {
            proxyERP_ = proxyERP;
            FlightBookingData = flightBookingData;
        }

        public void Confirm()
        {
            ProxyResponseERP response = proxyERP_.FlightBookingConfirm(FlightBookingData);

            if (response.ReturnCode == ReturnCodeERP.Error || response.ReturnCode == ReturnCodeERP.Abort)
                throw new InvalidOperationException(response.Message);
            if (response.ReturnCode == ReturnCodeERP.Success)
                FlightBookingData.ConfirmFlight();
            else
                throw new WarningException(response.Message);

        }

        public void Cancel()
        {
            ProxyResponseERP response = proxyERP_.FlightBookingCancel(FlightBookingData);

            if (response.ReturnCode == ReturnCodeERP.Error || response.ReturnCode == ReturnCodeERP.Abort)
                throw new InvalidOperationException(response.Message);
            if (response.ReturnCode == ReturnCodeERP.Success)
                FlightBookingData.Cancelled = true;
            else
                throw new WarningException(response.Message);
        }
    }
}
