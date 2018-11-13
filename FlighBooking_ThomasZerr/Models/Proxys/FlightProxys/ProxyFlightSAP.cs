using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Flight;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    class ProxyFlightSAP : ProxyFlight
    {
        private Z_FLIGHT_MTClient sapClient_;

        public override string Username { get => sapClient_.ClientCredentials.UserName.UserName; set => sapClient_.ClientCredentials.UserName.UserName = value; }
        public override string Password { set => sapClient_.ClientCredentials.UserName.Password = value; }

        public ProxyFlightSAP()
        {
            sapClient_ = new Z_FLIGHT_MTClient();
        }

        public override ProxyFlightResponse GetList(IFlightData args)
        {
            var getListRequest = BuildGetListRequest(args);
            var sapResponse = sapClient_.FlightGetList(getListRequest);
            return BuildGetListResponse(sapResponse);
        }

        private FlightGetList BuildGetListRequest(IFlightData args)
        {
            Bapisfldra[] flightDateRange = { ConvertFromDateRangeToBapisfldra(args.FlightDateRange) };

            return new FlightGetList
            {
                Airline = args.AirlineId,
                DateRange = flightDateRange,
                MaxRows = args.MaxResults,
                MaxRowsSpecified = args.IsMaxResultsActive
            };

        }

        private ProxyFlightResponse BuildGetListResponse(FlightGetListResponse sapResponse)
        {
            ReturnCodeProxys returnCode = TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            string messageNumber = sapResponse.Return[0].Number;
            IFlightData[] flightDatas = ConvertFlightListToFlightData(sapResponse.FlightList);

            HandleIsError(returnCode, message, messageNumber);

            return new ProxyFlightResponse
            {
                ReturnCode = returnCode,
                Message = message,
                MessageNumber = messageNumber,
                FlightDatas = flightDatas
            };
        }

        private IFlightData[] ConvertFlightListToFlightData(Bapisfldat[] flightList)
        {
            IFlightData[] flightDatas = new IFlightData[flightList.Length];

            for (int i = 0; i < flightList.Length; ++i)
            {
                var flight = flightList[i];
                var flightData = new FlightDataSAP
                {
                    AirlineId = flight.Airlineid,
                    ConnectId = flight.Connectid,
                    CurrencyIso = flight.CurrIso,
                    Price = flight.Price
                };

                flightData.Flightdate.DateString = flight.Flightdate;
                flightDatas[i] = flightData;
            }

            return flightDatas;
        }

        private Bapisfldra ConvertFromDateRangeToBapisfldra(IDateRange dateRange)
        {
            string option = ConvertDateRangeOptionToString(dateRange.Option);

            Bapisfldra result = new Bapisfldra
            {
                Sign = "I",
                Option = option,
                Low = dateRange.EarlierDate,
                High = dateRange.LaterDate

            };

            return result;
        }
    }
}
