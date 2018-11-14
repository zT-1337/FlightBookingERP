using System;

namespace FlighBooking_ThomasZerr.Utils.DateConverters
{
    interface IDateConverter
    {
        string ConvertDateTimeToString(DateTime dateTime);
        DateTime ConvertStringToDateTime(string date);
    }
}
