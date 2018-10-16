using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //TODO FlightBookingERP Objekt erstellen und zurückliefern

            throw new NotImplementedException();
        }

        public IFlightBooking[] RetrieveAll(FlightBookingData args)
        {
            ProxyResponseERP responses = proxyERP_.FlightBookingGetList(args);

            //TODO FlightBookingERP Objekte erstellen und zurückliefern

            throw new NotImplementedException();
        }
    }
}
