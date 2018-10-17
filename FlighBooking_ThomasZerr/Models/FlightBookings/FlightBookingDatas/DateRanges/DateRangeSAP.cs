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
            get { return ConvertDateTimeToString(EarlierDateTime); }
            set
            {

            }
        }

        public DateTime LaterDateTime { get; set; }
        public string LaterDate { get; set; }
        public DateRangeOption Option { get; set; }

        private string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd");
        }

        private string ConvertStringToDateTime(string date)
        {
            int year = Int32.Parse(date.Substring(0, ));
        }
    }
}
