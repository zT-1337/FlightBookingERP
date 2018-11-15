using System;

namespace FlighBooking_ThomasZerr.Utils.DateConverters
{
    class DateConverterSAP : IDateConverter
    {
        public string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public DateTime ConvertStringToDateTime(string date)
        {
            int year = Int32.Parse(date.Substring(0, 4));
            int month = Int32.Parse(date.Substring(5, 2));
            int day = Int32.Parse(date.Substring(8, 2));

            return new DateTime(year, month, day);
        }
    }
}
