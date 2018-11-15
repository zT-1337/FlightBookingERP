using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Validators.Factorys;
using FlighBooking_ThomasZerr.Utils.DateConverters;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    class FlightBookingEditWindowFactorySAP : IFlightBookingEditWindowFactory
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private IValidatorFactory validatorFactory_;

        public FlightBookingEditWindow Create()
        {
            validatorFactory_ = new ValidatorFactorySAP();

            var editViewModel = CreateViewModel();
            return new FlightBookingEditWindow(editViewModel);
        }

        private IFlightBookingEditViewModel CreateViewModel()
        {
            var flightBookingFactory = CreateFlightBookingFactory();
            var defaultFlightBookingData = CreateDefaultFlightBookingArgs();
            var bookingDateRange = CreateDateRange();
            var flightDateRange = CreateDateRange();

            var operationResultFactory = CreateOperationResultFactory();

            var airlineIdValidator = validatorFactory_.CreateAirlineIdValidator();
            var travelAgencyIdValidator = validatorFactory_.CreateTravelAgencyIdValidator();
            var customerIdValidator = validatorFactory_.CreateCustomerIdValidator();
            var dateRangeValidator = validatorFactory_.CreateDateRangeValidator();
            var maxResultsValidator = validatorFactory_.CreateMaxResultsValidator();

            return new FlightBookingEditViewModelImpl(flightBookingFactory, 
                defaultFlightBookingData, bookingDateRange, flightDateRange,
                new ObservableCollection<IFlightBooking>(),
                operationResultFactory,
                airlineIdValidator, travelAgencyIdValidator, customerIdValidator,
                dateRangeValidator, maxResultsValidator);
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

        private IDateRange CreateDateRange()
        {
            var dateConverter = new DateConverterSAP();
            var flightDateRange = new DateRangeImpl(dateConverter)
            {
                Option = DateRangeOption.Between,
                EarlierDateTime = DateTime.Now,
                LaterDateTime = DateTime.Now
            };


            return flightDateRange;
        }

        private IOperationResultFactory CreateOperationResultFactory()
        {
            return new OperationResultFactoryImpl();
        }
    }
}
