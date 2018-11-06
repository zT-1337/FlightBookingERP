using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Flight;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
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

        public ProxyFlightResponse GetList(IFlightData args)
        {
            Bapisfldra[] flightDateRange = {ConvertFromDateRangeToBapisfldra(args.FlightDateRange)};

            var flightGetlist = new FlightGetList
            {
                Airline = args.AirlineId,
                DateRange = flightDateRange,
                MaxRows = args.MaxResults,
                MaxRowsSpecified = args.IsMaxResultsActive
            };

            var sapResponse = sapClient_.FlightGetList(flightGetlist);

            ReturnCodeProxys returnCode = TypeReturnCodeConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            IFlightData[] flightDatas = ConvertFlightListToFlightData(sapResponse.FlightList);

            return new ProxyFlightResponse
            {
                ReturnCode = returnCode,
                Message = message,
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

        private string ConvertDateRangeOptionToString(DateRangeOption option)
        {
            switch (option)
            {
                case DateRangeOption.Equal:
                    return "EQ";
                case DateRangeOption.NotEqual:
                    return "NE";
                case DateRangeOption.Between:
                    return "BT";
                case DateRangeOption.NotBetween:
                    return "NB";
            }

            throw new InvalidOperationException($"Gegebene DateRangeOption nicht bekannt: {option:G}");
        }
    }
}
