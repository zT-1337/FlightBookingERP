using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.FlightBookingReference;
using FlighBooking_ThomasZerr.Models.FlightBookings;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    class ProxySAP : IProxyERP
    {
        private Z_HH_FlightBooking_MT_01Client sapClient;

        public string Username
        {
            get => sapClient.ClientCredentials.UserName.UserName;
            set { sapClient.ClientCredentials.UserName.UserName = value; }
        }

        public string Password
        {
            get => sapClient.ClientCredentials.UserName.Password;
            set { sapClient.ClientCredentials.UserName.Password = value; }
        }

        public ProxyResponseERP FlightBookingConfirm(FlightBookingData args)
        {
            var flightBookingConfirm = new FlightBookingConfirm
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingConfirmResponse flightBookingResponse = sapClient.FlightBookingConfirm(flightBookingConfirm);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingCancel(FlightBookingData args)
        {
            var flightBookingCancel = new FlightBookingCancel
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingCancelResponse flightBookingCancelResponse = sapClient.FlightBookingCancel(flightBookingCancel);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingCreateFromData(FlightBookingData args)
        {
            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingGetList(FlightBookingData args)
        {
            throw new NotImplementedException();
        }
    }
}
