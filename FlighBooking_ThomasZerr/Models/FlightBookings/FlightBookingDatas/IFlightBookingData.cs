﻿using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Dates;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    public interface IFlightBookingData
    {
        //TODO Flightdate eventuell in besseren Datentypen umwandeln
        IFlightData FlightData { get; }
        string BookingId { get; set; }
        string CustomerId { get; set; }
        string Class { get; set; }
        IDate Bookdate { get; }
        string Counter { get; set; }
        string AgencyId { get; set; }
        string PassagierName { get; set; }
        bool Reserved { get; set; }
        bool Cancelled { get; set; }
        bool Confirmed { get; }

        IDateRange BookingDateRange { get; }
        IDateRange FlightDateRange { get; }

        int MaxResults { get; set; }
        bool IsMaxResultsActive { get; set; }

        void ConfirmFlight();
    }
}
