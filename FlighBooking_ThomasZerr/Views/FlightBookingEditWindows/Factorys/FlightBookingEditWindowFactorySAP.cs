using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResults.Factory;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.SearchDatas;
using FlighBooking_ThomasZerr.Utils.DateConverters;
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

            var searchData = CreateSearchData();

            var operationResultFactory = CreateOperationResultFactory();


            return new FlightBookingEditViewModelImpl(flightBookingFactory, defaultFlightBookingData, searchData,
                operationResultFactory)
            {
                RetrievedFlightBookings = new ObservableCollection<IFlightBooking>()
            };
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

            return flightBookingData;
        }

        private ISearchData CreateSearchData()
        {
            IDateConverter dateConverter = new DateConverterSAP();
            var now = DateTime.Now;

            IDateRange flightDateRange = new DateRangeImpl(dateConverter);
            flightDateRange.Option = DateRangeOption.Between;
            flightDateRange.LaterDateTime = now;
            flightDateRange.EarlierDateTime = now;

            IDateRange bookingDateRange = new DateRangeImpl(dateConverter);
            bookingDateRange.Option = DateRangeOption.Between;
            bookingDateRange.LaterDateTime = now;
            bookingDateRange.EarlierDateTime = now;

            ISearchData searchData = new SearchDataSAP
            {
                BookingDateRange = bookingDateRange,
                FlightDateRange = flightDateRange,
                MaxResults = 0,
                IsMaxResultsActive = false
            };

            return searchData;
        }

        private IOperationResultFactory CreateOperationResultFactory()
        {
            return new OperationResultFactoryImpl();
        }
    }
}
