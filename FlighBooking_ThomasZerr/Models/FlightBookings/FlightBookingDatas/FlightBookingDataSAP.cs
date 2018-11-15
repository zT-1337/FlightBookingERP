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
        public string CustomerId { get; set; }
        public string Class { get; set; }
        public IDate Bookdate { get; }
        public string Counter { get; set; }
        public string AgencyId { get; set; }
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
            FlightData = new FlightDataSAP();

            var dateConverter = new DateConverterSAP();
            Bookdate = new DateImpl(dateConverter);
        }
    }
}
