using System;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.DateRanges
{
    class DateRangeImpl : IDateRange
    {
        private readonly IDateConverter dateConverter_;

        private DateTime earlierDateTime_;
        public DateTime EarlierDateTime
        {
            get => earlierDateTime_;
            set
            {
                if (DateTime.Compare(value, LaterDateTime) > 0)
                    throw new Exception("Startdatum darf nicht nach dem Enddatum liegen");

                earlierDateTime_ = value;
            }
        }

        public string EarlierDate
        {
            get => dateConverter_.ConvertDateTimeToString(EarlierDateTime);
            set => EarlierDateTime = dateConverter_.ConvertStringToDateTime(value);
        }

        private DateTime laterDateTime_;
        public DateTime LaterDateTime
        {
            get => laterDateTime_;
            set
            {
                if(DateTime.Compare(EarlierDateTime, value) < 0)
                    throw new Exception("Startdatum darf nicht nach dem Enddatum liegen");

                laterDateTime_ = value;
            }
        }

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
