﻿using System;
using System.Collections.ObjectModel;
using System.Configuration;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows.Factorys
{
    class FlightBookingWindowFactoryImpl : IFlightBookingWindowFactory
    {
        public FlightBookingWindow Create(string username, string password)
        {
            string erpSystem = ConfigurationManager.AppSettings["ERP-System"];

            if (erpSystem.Equals("SAP"))
                return CreateForSAP(username, password);

            throw new ConfigurationErrorsException($"ERP-System {erpSystem} ist eine unbekannte Option");
        }

        private FlightBookingWindow CreateForSAP(string username, string password)
        {
            var proxySAP = CreateProxySAP(username, password);
            var flightBookingFactory = CreateFlightBookingFactoryERP(proxySAP);
            var defaultArgs = CreateDefaultArgsSAP();
            var flightBookingViewModel = CreateFlightBookingViewModelImpl(defaultArgs, flightBookingFactory);

            var flightBookingWindow = new FlightBookingWindow();

            throw new NotImplementedException();
        }

        private IProxyERP CreateProxySAP(string username, string password)
        {
            return new ProxySAP
            {
                Username = username,
                Password = password
            };
        }

        private IFlightBookingFactory CreateFlightBookingFactoryERP(IProxyERP proxyERP)
        {
            return new FlightBookingFactoryERP(proxyERP);
        }

        private IFlightBookingData CreateDefaultArgsSAP()
        {
            var flightBookingData = new FlightBookingDataSAP
            {
                AirlineId = "",
                BookingId = "",
                ConnectId = "",
                Flightdate = "",
                CustomerId = "",
                Class = "",
                Bookdate = "",
                Counter = "",
                AgencyId = "",
                PassagierName = "",
                Reserved = false,
                Cancelled = false,
                AirlineName = "",
                TravelAgency = "",
            };

            flightBookingData.BookingDateRange.EarlierDateTime = DateTime.Now;
            flightBookingData.BookingDateRange.LaterDateTime = DateTime.Now;

            flightBookingData.FlightDateRange.EarlierDateTime = DateTime.Now;
            flightBookingData.FlightDateRange.LaterDateTime = DateTime.Now;

            return flightBookingData;
        }

        private IFlightBookingViewModel CreateFlightBookingViewModelImpl(IFlightBookingData defaultArgs, IFlightBookingFactory flightBookingFactory)
        {
            return new FlightBookingViewModelImpl(defaultArgs, flightBookingFactory, 
                new ObservableCollection<IFlightBooking>(), new ObservableCollection<IFlightBooking>());
        }


    }
}
