using System;
using System.Text.RegularExpressions;
using FlighBooking_ThomasZerr.Models.Dates;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Utils;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    class FlightBookingDataSAP : NotifyPropertyChanged, IFlightBookingData
    {
        public IFlightData FlightData { get; }
        public string BookingId { get; set; }

        private int maxLenghtCustomerId_;
        private string customerId_;
        public string CustomerId
        {
            get => customerId_;
            set
            {
                if (value.Length > maxLenghtCustomerId_)
                    throw new Exception("Kundennummer darf nur maximal 8 Ziffern lang sein");

                if (!Regex.IsMatch(value, "^[0-9]*$"))
                    throw new Exception("Kundennummer darf nur Ziffern enthalten");

                customerId_ = value;
            }
        }

        private string[] flightClasses_;
        private string listOfFlightClasses_
        {
            get
            {
                string listOfFlightClasses = "";
                foreach (var flightClass in flightClasses_)
                {
                    listOfFlightClasses += flightClass + ", ";
                }

                return listOfFlightClasses;
            }
        }
        private string class_;
        public string Class
        {
            get => class_;
            set
            {
                if (value.Length == 0)
                {
                    class_ = value;
                    return;
                }

                if (!IsFlightClass(value))
                    throw new Exception($"Flugklasse muss einen dieser Werte haben: {listOfFlightClasses_}");

                class_ = value;
            }
        }

        public IDate Bookdate { get; }
        public string Counter { get; set; }

        private int maxLengthAgencyId_;
        private string agencyId_;
        public string AgencyId
        {
            get => agencyId_;
            set
            {
                if (value.Length > maxLengthAgencyId_)
                    throw new Exception("Reisebüro darf nur maximal 8 Ziffern lang sein");

                if (!Regex.IsMatch(value, "^[0-9]*$"))
                    throw new Exception("Reisebüro darf nur Ziffern enthalten");

                agencyId_ = value;
            }
        }

        public string PassagierName { get; set; }

        private bool reserved_;
        public bool Reserved
        {
            get => reserved_;
            set
            {
                reserved_ = value;
                if (value)
                    Confirmed = false;
                RaisePropertyChanged();
            }
        }

        private bool cancelled_;
        public bool Cancelled
        {
            get => cancelled_;
            set
            {
                cancelled_ = value;
                if (value)
                    Confirmed = false;
                RaisePropertyChanged();
            }
        }


        public bool Confirmed
        {
            get => !Reserved && !Cancelled;
            set
            {
                if (value)
                {
                    Reserved = false;
                    Cancelled = false;
                }

                RaisePropertyChanged();
            }
        }

        public FlightBookingDataSAP()
        {
            maxLenghtCustomerId_ = 8;
            flightClasses_ = new[] {"C", "F", "Y"};
            maxLengthAgencyId_ = 8;

            FlightData = new FlightDataSAP();

            var dateConverter = new DateConverterSAP();
            Bookdate = new DateImpl(dateConverter);
        }

        private bool IsFlightClass(string maybeFlightClass)
        {
            foreach (var flightClass in flightClasses_)
            {
                if (flightClass.Equals(maybeFlightClass))
                    return true;
            }

            return false;
        }
    }
}
