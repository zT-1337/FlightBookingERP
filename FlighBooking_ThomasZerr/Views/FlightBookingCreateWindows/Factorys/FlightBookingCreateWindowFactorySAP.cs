using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;
using FlighBooking_ThomasZerr.Models.Validators.Factorys;
using FlighBooking_ThomasZerr.Utils.DateConverters;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys
{
    class FlightBookingCreateWindowFactorySAP : IFlightBookingCreateWindowFactory
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private IValidatorFactory validatorFactory_;

        public FlightBookingCreateWindow Create()
        {
            validatorFactory_ = new ValidatorFactorySAP();

            var createViewModel = CreateViewModel();
            return new FlightBookingCreateWindow(createViewModel);
        }

        private IFlightBookingCreateViewModel CreateViewModel()
        {

            var flightFactory = CreateFlightFactory();
            var defaultFlightArgs = CreateDefaultFlightArgs();
            var flightDateRange = CreateFlightDateRange();

            var flightBookingFactory = CreateFlightBookingFactory();
            var defaultFlightBookingArgs = CreateDefaultFlightBookingArgs();

            var operationResultFactory = CreateOperationResultFactory();

            var airlineIdValidator = validatorFactory_.CreateAirlineIdValidator();
            var flightDateValidator = validatorFactory_.CreateDateRangeValidator();
            var maxResultsValidator = validatorFactory_.CreateMaxResultsValidator();

            var travelAgencyIdValidator = validatorFactory_.CreateTravelAgencyIdValidator();
            var customerIdValidator = validatorFactory_.CreateCustomerIdValidator();
            var flightClassValidator = validatorFactory_.CreateFlightClassValidator();

            var notEmptyStringValidator = validatorFactory_.CreateNotEmptyStringValidator();

            return new FlightBookingCreateViewModelImpl(flightFactory, defaultFlightArgs, flightDateRange,
                flightBookingFactory, defaultFlightBookingArgs, 
                new ObservableCollection<IFlight>(), operationResultFactory,
                airlineIdValidator, flightDateValidator, maxResultsValidator,
                travelAgencyIdValidator, customerIdValidator, flightClassValidator,
                notEmptyStringValidator);
        }

        private IFlightFactory CreateFlightFactory()
        {
            var proxyFlight = new ProxyFlightSAP
            {
                Username = Username,
                Password = Password
            };
            return new FlightFactoryImpl(proxyFlight);
        }

        private IFlightData CreateDefaultFlightArgs()
        {
            var flighData = new FlightDataSAP
            {
                AirlineId = "",
                ConnectId = "",
                Planetype = "",
                CurrencyIso = "",
                Price = 0,
            };

            return flighData;
        }

        private IDateRange CreateFlightDateRange()
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
            return new OperationResultFactoryImpl();
        }
    }
}
