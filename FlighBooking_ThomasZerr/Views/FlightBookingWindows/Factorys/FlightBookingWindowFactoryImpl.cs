using System;
using System.Collections.ObjectModel;
using System.Configuration;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;
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

            return new FlightBookingWindow(flightBookingViewModel);
        }

        private IProxyFlightBooking CreateProxySAP(string username, string password)
        {
            IProxyFlight proxyFlight = new ProxyFlightSAP
            {
                Username = username,
                Password = password
            };
            IFlightFactory flightFactory = new FlightFactoryImpl(proxyFlight);
            IProxyFlightBooking proxyFlightBooking = new ProxyFlightBookingSAP(flightFactory)
            {
                Username = username,
                Password = password
            };
            return proxyFlightBooking;
        }

        private IFlightBookingFactory CreateFlightBookingFactoryERP(IProxyFlightBooking proxyFlightBooking)
        {
            return new FlightBookingFactoryImpl(proxyFlightBooking);
        }

        private IFlightBookingData CreateDefaultArgsSAP()
        {
            var flightBookingData = new FlightBookingDataSAP
            {
                BookingId = "",
                CustomerId = "",
                Class = "",
                Counter = "",
                AgencyId = "",
                PassagierName = "",
                Reserved = false,
                Cancelled = false,
            };

            flightBookingData.FlightData.AirlineId = "";
            flightBookingData.FlightData.ConnectId = "";

            flightBookingData.BookingDateRange.EarlierDateTime = DateTime.Now;
            flightBookingData.BookingDateRange.LaterDateTime = DateTime.Now;
            flightBookingData.BookingDateRange.Option = DateRangeOption.Between;

            flightBookingData.FlightDateRange.EarlierDateTime = DateTime.Now;
            flightBookingData.FlightDateRange.LaterDateTime = DateTime.Now;
            flightBookingData.FlightDateRange.Option = DateRangeOption.Between;

            flightBookingData.FlightData.Flightdate.Date = DateTime.Now;
            flightBookingData.Bookdate.Date = DateTime.Now;

            return flightBookingData;
        }

        private IFlightBookingViewModel CreateFlightBookingViewModelImpl(IFlightBookingData defaultArgs, IFlightBookingFactory flightBookingFactory)
        {
            return new FlightBookingViewModelImpl(defaultArgs, flightBookingFactory, 
                new ObservableCollection<IFlightBooking>(), new ObservableCollection<IFlightBooking>());
        }


    }
}
