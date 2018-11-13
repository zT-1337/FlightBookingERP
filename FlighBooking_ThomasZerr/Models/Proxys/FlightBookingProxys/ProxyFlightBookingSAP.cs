using System;
using FlighBooking_ThomasZerr.FlightBookingReference;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    class ProxyFlightBookingSAP : ProxyFlightBooking
    {
        private Z_HH_FlightBooking_MT_01Client sapClient_;

        public override string Username
        {
            get => sapClient_.ClientCredentials.UserName.UserName;
            set { sapClient_.ClientCredentials.UserName.UserName = value; }
        }

        public override string Password
        {
            set { sapClient_.ClientCredentials.UserName.Password = value; }
        }

        public ProxyFlightBookingSAP()
        {
            sapClient_ = new Z_HH_FlightBooking_MT_01Client();
        }

        public override void Confirm(IFlightBookingData args)
        {
            var confirmRequest = BuildConfirmRequest(args);
            FlightBookingConfirmResponse sapResponse = sapClient_.FlightBookingConfirm(confirmRequest);
            HandleIsError(TypeToReturnCode(sapResponse.Return[0].Type), sapResponse.Return[0].Message, sapResponse.Return[0].Number);
        }

        private FlightBookingConfirm BuildConfirmRequest(IFlightBookingData args)
        {
            return new FlightBookingConfirm
            {
                AirlineID = args.FlightData.AirlineId,
                BookingNumber = args.BookingId
            };
        }

        public override void Cancel(IFlightBookingData args)
        {
            var cancelRequest = BuildCancelRequest(args);
            FlightBookingCancelResponse sapResponse = sapClient_.FlightBookingCancel(cancelRequest);
            HandleIsError(TypeToReturnCode(sapResponse.Return[0].Type), sapResponse.Return[0].Message, sapResponse.Return[0].Number);
        }

        private FlightBookingCancel BuildCancelRequest(IFlightBookingData args)
        {
            return new FlightBookingCancel
            {
                AirlineID = args.FlightData.AirlineId,
                BookingNumber = args.BookingId
            };
        }

        public override IFlightBookingData Create(IFlightBookingData args)
        {
            var createRequest = BuildCreateFromDataRequest(args);
            FlightBookingCreateFromDataResponse sapResponse = sapClient_.FlightBookingCreateFromData(createRequest);
            HandleIsError(TypeToReturnCode(sapResponse.Return[0].Type), sapResponse.Return[0].Message, sapResponse.Return[0].Number);
            return BuildCreateFromDataResponse(sapResponse);
        }

        private FlightBookingCreateFromData BuildCreateFromDataRequest(IFlightBookingData args)
        {
            Bapisbonew bookingData = ConvertFlightBookingDataToBapisbonew(args);
            string reserved = ConvertBoolToStringForSAP(args.Reserved);

            return new FlightBookingCreateFromData
            {
                BookingData = bookingData,
                ReserveOnly = reserved
            };
        }

        private IFlightBookingData BuildCreateFromDataResponse(FlightBookingCreateFromDataResponse sapResponse)
        {

            IFlightBookingData flightBookingData = new FlightBookingDataSAP()
            {
                BookingId = sapResponse.BookingNumber
            };
            flightBookingData.FlightData.AirlineId = sapResponse.AirlineID;

            return flightBookingData;
        }

        private Bapisbonew ConvertFlightBookingDataToBapisbonew(IFlightBookingData args)
        {
            return new Bapisbonew
            {
                Agencynum = args.AgencyId,
                Airlineid = args.FlightData.AirlineId,
                Class = args.Class,
                Connectid = args.FlightData.ConnectId,
                Counter = args.Counter,
                Customerid = args.CustomerId,
                Flightdate = args.FlightData.Flightdate.DateString,
                Passname = args.PassagierName
            };
        }

        public override IFlightBookingData[] GetList(IFlightBookingData args)
        {
            var getListRequest = BuildGetListRequest(args); 
            FlightBookingGetListResponse sapResponse = sapClient_.FlightBookingGetList(getListRequest);
            HandleIsError(TypeToReturnCode(sapResponse.Return[0].Type), sapResponse.Return[0].Message, sapResponse.Return[0].Number);
            return BuildGetListResponse(sapResponse.BookingList);
        }

        private FlightBookingGetList BuildGetListRequest(IFlightBookingData args)
        {
            Bapisfldra[] bookingDateRange = { ConvertFromDateRangeToBapisfldra(args.BookingDateRange) };
            Bapisfldra[] flightDateRange = { ConvertFromDateRangeToBapisfldra(args.FlightDateRange) };

            return new FlightBookingGetList
            {
                MaxRows = args.MaxResults,
                MaxRowsSpecified = args.IsMaxResultsActive,
                Airline = args.FlightData.AirlineId,
                TravelAgency = args.AgencyId,
                CustomerNumber = args.CustomerId,
                BookingDateRange = bookingDateRange,
                FlightDateRange = flightDateRange
            };
        }

        private IFlightBookingData[] BuildGetListResponse(Bapisbodat[] bookingList)
        {
            IFlightBookingData[] flightBookingDatas = new IFlightBookingData[bookingList.Length];

            for (int i = 0; i < bookingList.Length; ++i)
            {
                var booking = bookingList[i];
                var flightBookingData = new FlightBookingDataSAP()
                {
                    BookingId = booking.Bookingid,
                    CustomerId = booking.Customerid,
                    Class = booking.Class,
                    Counter = booking.Counter,
                    AgencyId = booking.Agencynum,
                    Reserved = ConvertStringOfSAPToBool(booking.Reserved),
                    Cancelled = ConvertStringOfSAPToBool(booking.Cancelled),
                    PassagierName = booking.Passname
                };
                flightBookingData.FlightData.AirlineId = booking.Airlineid;
                flightBookingData.FlightData.ConnectId = booking.Connectid;
                flightBookingData.FlightData.Flightdate.DateString = booking.Flightdate;
                flightBookingData.Bookdate.DateString = booking.Bookdate;

                flightBookingDatas[i] = flightBookingData;
            }

            return flightBookingDatas;
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
