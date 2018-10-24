using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Utils.DateConverters
{
    interface IDateConverter
    {
        string ConvertDateTimeToString(DateTime dateTime);
        DateTime ConvertStringToDateTime(string date);
    }
}
