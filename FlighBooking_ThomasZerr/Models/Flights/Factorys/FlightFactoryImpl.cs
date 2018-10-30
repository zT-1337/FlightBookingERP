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
        private IProxyFlight proxyFlight_;

        public FlightFactoryImpl(IProxyFlight proxyFlight)
        {
            proxyFlight_ = proxyFlight;
        }

        public bool IsFlightExisting(IFlightData data)
        {
            ProxyFlightResponse proxyFlightResponse = proxyFlight_.IsExisting(data);
            if (IsMessageTellingNotExisting(proxyFlightResponse.Message))
                return false;

            HandleIsError(proxyFlightResponse.ReturnCode, proxyFlightResponse.Message);

            return true;
        }

        private bool IsMessageTellingNotExisting(string Message)
        {
            return Regex.IsMatch(Message, "Flug .* nicht vorhanden");
        }

        public IFlight Create(IFlightData data)
        {
            ProxyFlightResponse proxyFlightResponse = proxyFlight_.Create(data);
            HandleIsError(proxyFlightResponse.ReturnCode, proxyFlightResponse.Message);
            return new FlightImpl(proxyFlight_, data);
        }

        public IFlight[] Retrieve(IFlightData data)
        {
            throw new NotImplementedException();
        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }
    }
}
