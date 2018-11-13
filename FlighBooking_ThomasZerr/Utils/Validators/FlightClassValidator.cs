using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Utils.Validators
{
    class FlightClassValidator : IValidator
    {
        public string[] FlightClasses { get; set; }
        public object ExtraParam { get; set; }

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

        public void IsValid(object value)
        {
            if (value is string flightClass)
            {
                if(flightClass.Length == 0)
                    throw new Exception("Klasse darf nicht leer sein");

                if(FlightClasses.Contains(flightClass))
                    throw new Exception($"Flugklasse muss einen dieser Werte haben: {ListOfFlightClasses}");

                return;
            }

            throw new ArgumentException();
    
        }
    }
}
