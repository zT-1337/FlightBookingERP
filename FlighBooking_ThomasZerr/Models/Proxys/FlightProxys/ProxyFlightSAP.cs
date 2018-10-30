using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Flight;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Utils.SAP;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    class ProxyFlightSAP : IProxyFlight
    {
        private Z_FLIGHT_MTClient sapClient_;

        public string Username { get => sapClient_.ClientCredentials.UserName.UserName; set => sapClient_.ClientCredentials.UserName.UserName = value; }
        public string Password { get => sapClient_.ClientCredentials.UserName.Password; set => sapClient_.ClientCredentials.UserName.Password = value; }

        public ProxyFlightSAP()
        {
            sapClient_ = new Z_FLIGHT_MTClient();
        }

        public ProxyFlightResponse IsExisting(IFlightData args)
        {
            var flightGetDetail = new FlightGetDetail
            {
                AirlineID = args.AirlineId,
                ConnectionID = args.ConnectId,
                FlightDate = args.Flightdate.DateString
            };

            var sapResponse = sapClient_.FlightGetDetail(flightGetDetail);

            ReturnCodeProxys returnCode = TypeReturnCodeConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;

            return new ProxyFlightResponse
            {
                ReturnCode =  returnCode,
                Message = message
            };
        }

        public ProxyFlightResponse Create(IFlightData args)
        {
            Bapisflrep flightData = ConvertFlightDataToBapisflrep(args);

            var flightCreate = new FlightSaveReplica()
            {
                FlightData = flightData
            };

            var sapResponse = sapClient_.FlightSaveReplica(flightCreate);

            ReturnCodeProxys returnCode = TypeReturnCodeConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;

            return new ProxyFlightResponse
            {
                ReturnCode = returnCode,
                Message = message
            };
        }

        private Bapisflrep ConvertFlightDataToBapisflrep(IFlightData args)
        {
            return new Bapisflrep
            {
                Airlineid = args.AirlineId,
                Connectid = args.ConnectId,
                CurrIso = args.CurrencyIso,
                Flightdate = args.Flightdate.DateString,
                Planetype = args.Planetype,
                Price = args.Price
            };
        }
    }
}
