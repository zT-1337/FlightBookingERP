using System;

namespace FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidators
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
