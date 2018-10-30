using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys
{
    class FlightBookingCreateWindowFactorySAP : IFlightBookingCreateWindowFactory
    {
        private string username_;
        private string password_;

        public FlightBookingCreateWindow Create(string username, string password)
        {
            var createViewModel = CreateViewModel(username, password);
            return new FlightBookingCreateWindow(createViewModel);
        }

        private IFlightBookingCreateViewModel CreateViewModel(string username, string password)
        {

            var flightFactory = CreateFlightFactory(username, password);
            var defaultFlightArgs = CreateDefaultFlightArgs();
            var flightBookingFactory = CreateFlightBookingFactory(username, password);
            var defaultFlightBookingArgs = CreateDefaultFlightBookingArgs();

            return new FlightBookingCreateViewModelImpl(flightFactory, defaultFlightArgs, 
                flightBookingFactory, defaultFlightBookingArgs, 
                new ObservableCollection<IFlight>());
        }

        private IFlightFactory CreateFlightFactory(string username, string password)
        {
            var proxyFlight = new ProxyFlightSAP
            {
                Username = username,
                Password = password
            };
            return new FlightFactoryImpl(proxyFlight);
        }

        private IFlightData CreateDefaultFlightArgs()
        {
            return new FlightDataSAP
            {
                AirlineId = "",
                ConnectId = "",
                Planetype = "",
                CurrencyIso = "",
                Price = 0,
            };
        }

        private IFlightBookingFactory CreateFlightBookingFactory(string username, string password)
        {
            var proxyFlightBooking = new ProxyFlightBookingSAP
            {
                Username = username,
                Password = password
            };

            return new FlightBookingFactoryImpl(proxyFlightBooking);
        }

        private IFlightBookingData CreateDefaultFlightBookingArgs()
        {
            return new FlightBookingDataSAP
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
        }
    }
}
