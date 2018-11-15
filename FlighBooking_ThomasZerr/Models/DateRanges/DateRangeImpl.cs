using System;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.DateRanges
{
    class DateRangeImpl : IDateRange
    {
        private readonly IDateConverter dateConverter_;

        public DateTime EarlierDateTime { get; set; }
        public string EarlierDate
        {
            get => dateConverter_.ConvertDateTimeToString(EarlierDateTime);
            set => EarlierDateTime = dateConverter_.ConvertStringToDateTime(value);
        }

        public DateTime LaterDateTime { get; set; }
        public string LaterDate
        {
            get => dateConverter_.ConvertDateTimeToString(LaterDateTime);
            set => LaterDateTime = dateConverter_.ConvertStringToDateTime(value);
        }

        public DateRangeOption Option { get; set; }

        public DateRangeImpl(IDateConverter dateConverter)
        {
            dateConverter_ = dateConverter;
        }
    }
}
