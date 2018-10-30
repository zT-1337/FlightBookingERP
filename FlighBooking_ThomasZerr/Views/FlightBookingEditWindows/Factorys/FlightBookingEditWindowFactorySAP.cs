using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    class FlightBookingEditWindowFactorySAP : IFlightBookingEditWindowFactory
    {
        public FlightBookingEditWindow Create(string username, string password)
        {
            var editViewModel = CreateViewModel(username, password);
            return new FlightBookingEditWindow(editViewModel);
        }

        private IFlightBookingEditViewModel CreateViewModel(string username, string password)
        {
            var flightBookingFactory = CreateFlightBookingFactory(username, password);
            var defaultFlightBookingData = CreateDefaultFlightBookingArgs();

            return new FlightBookingEditViewModelImpl(flightBookingFactory, 
                defaultFlightBookingData, 
                new ObservableCollection<IFlightBooking>());
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
