using System;

namespace FlighBooking_ThomasZerr.Models.Validators.FlightClassValidators
{
    class FlightClassValidator : IFlightClassValidator
    {
        public string[] FlightClasses { get; set; }

        private string ListOfFlightClasses
        {
            get
            {
                string listOfFlightClasses = "";
                foreach (var flightClass in FlightClasses)
                {
                    listOfFlightClasses += flightClass + ", ";
                }

                return listOfFlightClasses;
            }
        }

        public void IsValidElseThrowException(object value)
        {
            if (value is string flightClass)
            {
                if(!IsFlightClass(flightClass))
                    throw new Exception($"Flugklasse muss einen dieser Werte haben: {ListOfFlightClasses}");

                return;
            }

            throw new ArgumentException();
    
        }

        private bool IsFlightClass(string maybeFlightClass)
        {
            foreach (var flightClass in FlightClasses)
            {
                if (flightClass.Equals(maybeFlightClass))
                    return true;
            }

            return false;
        }
    }
}
