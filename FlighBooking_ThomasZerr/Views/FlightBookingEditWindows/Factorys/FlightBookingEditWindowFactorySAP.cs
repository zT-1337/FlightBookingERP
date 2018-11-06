using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    class FlightBookingEditWindowFactorySAP : IFlightBookingEditWindowFactory
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public FlightBookingEditWindow Create()
        {
            var editViewModel = CreateViewModel();
            return new FlightBookingEditWindow(editViewModel);
        }

        private IFlightBookingEditViewModel CreateViewModel()
        {
            var flightBookingFactory = CreateFlightBookingFactory();
            var defaultFlightBookingData = CreateDefaultFlightBookingArgs();
            var operationResultFactory = CreateOperationResultFactory();

            return new FlightBookingEditViewModelImpl(flightBookingFactory, 
                defaultFlightBookingData, 
                new ObservableCollection<IFlightBooking>(),
                operationResultFactory);
        }

        private IFlightBookingFactory CreateFlightBookingFactory()
        {
            var proxyFlightBooking = new ProxyFlightBookingSAP
            {
                Username = Username,
                Password = Password
                
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

        private IOperationResultFactory CreateOperationResultFactory()
        {
            return new OperationResultFactorySAP();
        }
    }
}
