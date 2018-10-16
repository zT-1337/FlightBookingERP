using System;
using FlighBooking_ThomasZerr.FlightBookingReference;
using FlighBooking_ThomasZerr.Models.FlightBookings;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    class ProxySAP : IProxyERP
    {
        private Z_HH_FlightBooking_MT_01Client sapClient_;

        public string Username
        {
            get => sapClient_.ClientCredentials.UserName.UserName;
            set { sapClient_.ClientCredentials.UserName.UserName = value; }
        }

        public string Password
        {
            get => sapClient_.ClientCredentials.UserName.Password;
            set { sapClient_.ClientCredentials.UserName.Password = value; }
        }

        public ProxyResponseERP FlightBookingConfirm(FlightBookingData args)
        {
            var confirm = new FlightBookingConfirm
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingConfirmResponse response = sapClient_.FlightBookingConfirm(confirm);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingCancel(FlightBookingData args)
        {
            var cancel = new FlightBookingCancel
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingCancelResponse response = sapClient_.FlightBookingCancel(cancel);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingCreateFromData(FlightBookingData args)
        {
            //TODO Initialisieren der Variablen
            Bapisbonew bookingData = null;
            Bapiparex[] extensionIn = null;
            
            var createFromData = new FlightBookingCreateFromData
            {
                BookingData = bookingData,
                ExtensionIn = extensionIn,
                ReserveOnly = args.ReserveOnly,
                TestRun = args.TestRun
            };

            FlightBookingCreateFromDataResponse response = sapClient_.FlightBookingCreateFromData(createFromData);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingGetList(FlightBookingData args)
        {
            //TODO initialisieren
            Bapisfldra[] bookingDateRange = null;
            Bapisfldra[] flightDateRange = null;

            var getList = new FlightBookingGetList
            {
                Airline = args.Airline,
                TravelAgency = args.TravelAgency,
                CustomerNumber = args.CustomerNumber,
                BookingDateRange = bookingDateRange,
                FlightDateRange = flightDateRange,
            };

            FlightBookingGetListResponse response = sapClient_.FlightBookingGetList(getList);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }
    }
}
