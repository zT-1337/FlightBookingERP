using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.DateRanges;

namespace FlighBooking_ThomasZerr.Models.SearchDatas
{
    class SearchDataSAP : ISearchData
    {
        public IDateRange FlightDateRange { get; set; }
        public IDateRange BookingDateRange { get; set; }

        private int maxResults_;
        public int MaxResults
        {
            get => maxResults_;
            set
            {
                if (value < 0)
                    throw new Exception("Anzahl Suchergebnisse muss positiv sein");

                maxResults_ = value;
            }
        }

        public bool IsMaxResultsActive { get; set; }
    }
}
