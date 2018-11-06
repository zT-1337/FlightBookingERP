﻿using System;
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
        private IProxyFlight proxyFlight_;

        public FlightFactoryImpl(IProxyFlight proxyFlight)
        {
            proxyFlight_ = proxyFlight;
        }

        public IFlight[] Retrieve(IFlightData data)
        {
            ProxyFlightResponse flightResponse = proxyFlight_.GetList(data);

            HandleIsError(flightResponse.ReturnCode, flightResponse.Message);

            IFlight[] flights = new IFlight[flightResponse.FlightDatas.Length];
            for (int i = 0; i < flights.Length; ++i)
            {
                flights[i] = new FlightImpl(proxyFlight_, flightResponse.FlightDatas[i]);
            }

            return flights;
        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }
    }
}
