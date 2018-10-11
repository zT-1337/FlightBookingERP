using System;
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
            var confirm = new FlightBookingConfirm
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingConfirmResponse response = sapClient.FlightBookingConfirm(confirm);

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

            FlightBookingCancelResponse response = sapClient.FlightBookingCancel(cancel);

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

            FlightBookingCreateFromDataResponse response = sapClient.FlightBookingCreateFromData(createFromData);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingGetList(FlightBookingData args)
        {
            //TODO initialisieren
            Bapisfldra[] bookingDateRange = null;
            Bapiparex[] extensionIn = null;
            Bapisfldra[] flightDateRange = null;

            var getList = new FlightBookingGetList
            {
                Airline = args.Airline,
                BookingDateRange = bookingDateRange,
                CustomerNumber = args.CustomerNumber,
                ExtensionIn = extensionIn,
                FlightDateRange = flightDateRange,
                MaxRows = args.MaxRows,
                MaxRowsSpecified = args.MaxRowsSpecified,
                TravelAgency = args.TravelAgency
            };

            FlightBookingGetListResponse response = sapClient.FlightBookingGetList(getList);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }
    }
}
