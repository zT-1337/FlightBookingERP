using System;
using System.Configuration;
using FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys;
using FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys;

namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys
{
    class FlightBookingMainWindowFactoryImpl : IFlightBookingMainWindowFactory
    {
        public FlightBookingMainWindow Create(string username, string password)
        {
            string erpSystem = ConfigurationManager.AppSettings["ERP-System"];

            if (erpSystem.Equals("SAP"))
                return CreateForSAP(username, password);

            throw new ConfigurationErrorsException($"ERP-System {erpSystem} ist eine unbekannte Option");
        }

        private FlightBookingMainWindow CreateForSAP(string username, string password)
        {
            var createWindowFactory = new FlightBookingCreateWindowFactorySAP
            {
                Username = username,
                Password = password
                
            };
            var editWindowFactory = new FlightBookingEditWindowFactorySAP
            {
                Username = username,
                Password = password
            };

            return new FlightBookingMainWindow(createWindowFactory, editWindowFactory);
        }
    }
}
