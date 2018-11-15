using FlighBooking_ThomasZerr.Flight;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.SearchDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    class ProxyFlightSAP : ProxyFlight
    {
        private readonly Z_FLIGHT_MTClient sapClient_;

        public override string Username { get => sapClient_.ClientCredentials.UserName.UserName; set => sapClient_.ClientCredentials.UserName.UserName = value; }
        public override string Password { set => sapClient_.ClientCredentials.UserName.Password = value; }

        public ProxyFlightSAP()
        {
            sapClient_ = new Z_FLIGHT_MTClient();
        }

        public override IFlightData[] GetList(IFlightData args, ISearchData searchData)
        {
            var getListRequest = BuildGetListRequest(args, searchData);
            var sapResponse = sapClient_.FlightGetList(getListRequest);
            HandleIsError(TypeToReturnCode(sapResponse.Return[0].Type), sapResponse.Return[0].Message, sapResponse.Return[0].Number);
            return BuildGetListResponse(sapResponse.FlightList);
        }

        private FlightGetList BuildGetListRequest(IFlightData args, ISearchData searchData)
        {
            Bapisfldra[] flightDateRange = { ConvertFromDateRangeToBapisfldra(searchData.FlightDateRange) };

            return new FlightGetList
            {
                Airline = args.AirlineId,
                DateRange = flightDateRange,
                MaxRows = searchData.MaxResults,
                MaxRowsSpecified = searchData.IsMaxResultsActive
            };

        }

        private IFlightData[] BuildGetListResponse(Bapisfldat[] flightList)
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
