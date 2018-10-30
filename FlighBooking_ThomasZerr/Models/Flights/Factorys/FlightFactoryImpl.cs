using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return proxyFlightResponse.ReturnCode == ReturnCodeProxys.Success;
        }

        public IFlight Create(IFlightData data)
        {
            ProxyFlightResponse proxyFlightResponse = proxyFlight_.Create(data);
            
            HandleIsError(proxyFlightResponse.ReturnCode, proxyFlightResponse.Message);

            return new FlightImpl(proxyFlight_, data);
        }

        private void HandleIsError(ReturnCodeProxys returnCode, string message)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException(message);
        }
    }
}
