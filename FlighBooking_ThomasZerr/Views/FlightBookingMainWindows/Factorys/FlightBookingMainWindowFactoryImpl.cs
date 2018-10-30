using System;
using System.Collections.ObjectModel;
using System.Configuration;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

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
            throw new NotImplementedException();
        }
    }
}
