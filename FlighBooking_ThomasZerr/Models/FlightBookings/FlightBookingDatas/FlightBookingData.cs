﻿using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    class FlightBookingData
    {
        //TODO Flightdate eventuell in besseren Datentypen umwandeln
        public string AirlineId { get; set; }
        public string BookingId { get; set; }
        public string ConnectId { get; set; }
        public string Flightdate { get; set; }
        public string CustomerId { get; set; }
        public string Class { get; set; }
        public string Bookdate { get; set; }
        public string Counter { get; set; }
        public string AgencyId { get; set; }
        public string PassagierName { get; set; }
        public bool Reserved { get; set; }
        public bool Cancelled { get; set; }
        public bool Confirmed => !Reserved && !Cancelled;

        public string AirlineName { get; set; }
        public string TravelAgency { get; set; }
        public IDateRange BookingDateRange { get; set; }
        public IDateRange FlightDateRange { get; set; }

        public void ConfirmFlight()
        {
            Reserved = false;
            Cancelled = false;
        }
    }
}
