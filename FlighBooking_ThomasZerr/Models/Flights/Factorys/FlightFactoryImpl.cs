using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;

namespace FlighBooking_ThomasZerr.Models.Flights.Factorys
{
    class FlightFactoryImpl : IFlightFactory
    {
        private ProxyFlight proxyFlight_;

        public FlightFactoryImpl(ProxyFlight proxyFlight)
        {
            proxyFlight_ = proxyFlight;
        }

        public IFlight[] Retrieve(IFlightData data)
        {
            IFlightData[] flightDatas = proxyFlight_.GetList(data);

            IFlight[] flights = new IFlight[flightDatas.Length];
            for (int i = 0; i < flights.Length; ++i)
            {
                flights[i] = new FlightImpl(proxyFlight_, flightDatas[i]);
            }

            return flights;
        }
    }
}
