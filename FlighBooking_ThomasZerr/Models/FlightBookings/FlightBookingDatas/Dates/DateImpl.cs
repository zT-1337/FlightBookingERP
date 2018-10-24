using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates
{
    class DateImpl : IDate
    {
        private IDateConverter dateConverter_;

        public DateTime Date { get; set; }
        public string DateString
        {
            get => dateConverter_.ConvertDateTimeToString(Date);
            set => Date = dateConverter_.ConvertStringToDateTime(value);
        }

        public DateImpl(IDateConverter dateConverter)
        {
            dateConverter_ = dateConverter;
        }
    }
}
