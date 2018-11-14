using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidator
{
    class NotEmptyStringValidatorImpl : INotEmptyStringValidator
    {
        public string PropertyName { get; set; }

        public void IsValidElseThrowException(object value)
        {
            if (value is string str)
            {
                if(str.Length == 0)
                    throw new Exception($"{PropertyName} darf nicht leer sein");

                return;
            }

            throw new ArgumentException();
        }
    }
}
