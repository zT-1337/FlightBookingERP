using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges
{
    class DateRangeSAP : IDateRange
    {
        public DateTime EarlierDateTime { get; set; }

        public string EarlierDate
        {
            get => ConvertDateTimeToString(EarlierDateTime);
            set => EarlierDateTime = ConvertStringToDateTime(value);
        }

        public DateTime LaterDateTime { get; set; }
        public string LaterDate { get; set; }
        public DateRangeOption Option { get; set; }

        private string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd");
        }

        private DateTime ConvertStringToDateTime(string date)
        {
            int year = Int32.Parse(date.Substring(0, 4));
            int month = Int32.Parse(date.Substring(4, 2));
            int day = Int32.Parse(date.Substring(6, 2));

            return new DateTime(year, month, day);
        }
    }
}
