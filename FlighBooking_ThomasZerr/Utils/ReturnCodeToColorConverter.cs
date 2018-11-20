using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using FlighBooking_ThomasZerr.Models.OperationResults.ReturnCodes;

namespace FlighBooking_ThomasZerr.Utils
{
    class ReturnCodeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ReturnCode returnCode = (ReturnCode) value;

            switch (returnCode)
            {
                case ReturnCode.Success:
                    return Brushes.Green;
                case ReturnCode.Exception:
                    return Brushes.Red;
            }

            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
