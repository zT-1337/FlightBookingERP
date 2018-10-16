using System;
using System.Collections.Generic;
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

        public FlightBookingData FlightBookingData { get; set; }

        public FlightBookingERP(IProxyERP proxyERP)
        {
            proxyERP_ = proxyERP;
        }

        public void Confirm()
        {
            ProxyResponseERP response = proxyERP_.FlightBookingConfirm(FlightBookingData);

            //TODO response verarbeiten

            throw new NotImplementedException();
        }

        public void Cancel()
        {
            ProxyResponseERP response = proxyERP_.FlightBookingCancel(FlightBookingData);

            //TODO response verarbeiten

            throw new NotImplementedException();
        }
    }
}
