using System;
using FlighBooking_ThomasZerr.Models.Dates;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.Flights.FlightDatas
{
    class FlightDataSAP : IFlightData
    {
        private int maxAirlineIdLength_ = 3;
        private string airlineId_;
        public string AirlineId
        {
            get => airlineId_;
            set
            {
                if (value.Length > maxAirlineIdLength_)
                    throw new Exception("Fluggesellschaft darf maximal aus drei Zeichen bestehen");

                airlineId_ = value;
            }
        }

        public string ConnectId { get; set; }

        public IDate Flightdate { get; }

        public string Planetype { get; set; }

        public string CurrencyIso { get; set; }

        public decimal Price { get; set; }

        public FlightDataSAP()
        {
            IDateConverter dateConverter = new DateConverterSAP();
            Flightdate = new DateImpl(dateConverter);
        }
    }
}
