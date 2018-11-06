using System;
using FlighBooking_ThomasZerr.FlightBookingReference;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Utils.SAP;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    class ProxyFlightBookingSAP : IProxyFlightBooking
    {
        private Z_HH_FlightBooking_MT_01Client sapClient_;

        public string Username
        {
            get => sapClient_.ClientCredentials.UserName.UserName;
            set { sapClient_.ClientCredentials.UserName.UserName = value; }
        }

        public string Password
        {
            get => sapClient_.ClientCredentials.UserName.Password;
            set { sapClient_.ClientCredentials.UserName.Password = value; }
        }

        public ProxyFlightBookingSAP()
        {
            sapClient_ = new Z_HH_FlightBooking_MT_01Client();
        }

        public ProxyFlightBookingResponse Confirm(IFlightBookingData args)
        {
            var confirmRequest = BuildConfirmRequest(args);
            FlightBookingConfirmResponse sapResponse = sapClient_.FlightBookingConfirm(confirmRequest);
            return BuildConfirmResponse(sapResponse);
        }

        private FlightBookingConfirm BuildConfirmRequest(IFlightBookingData args)
        {
            return new FlightBookingConfirm
            {
                AirlineID = args.FlightData.AirlineId,
                BookingNumber = args.BookingId
            };
        }

        private ProxyFlightBookingResponse BuildConfirmResponse(FlightBookingConfirmResponse sapResponse)
        {
            ReturnCodeProxys returnCode = SAPConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            ProxyFlightBookingResponse result = new ProxyFlightBookingResponse
            {
                ReturnCode = returnCode,
                Message = message
            };

            return result;
        }

        public ProxyFlightBookingResponse Cancel(IFlightBookingData args)
        {
            var cancelRequest = BuildCancelRequest(args);
            FlightBookingCancelResponse sapResponse = sapClient_.FlightBookingCancel(cancelRequest);
            return BuildCancelResponse(sapResponse);
        }

        private FlightBookingCancel BuildCancelRequest(IFlightBookingData args)
        {
            return new FlightBookingCancel
            {
                AirlineID = args.FlightData.AirlineId,
                BookingNumber = args.BookingId
            };
        }

        private ProxyFlightBookingResponse BuildCancelResponse(FlightBookingCancelResponse sapResponse)
        {
            ReturnCodeProxys returnCode = SAPConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            ProxyFlightBookingResponse result = new ProxyFlightBookingResponse
            {
                ReturnCode = returnCode,
                Message = message
            };

            return result;
        }

        public ProxyFlightBookingResponse Create(IFlightBookingData args)
        {
            var createRequest = BuildCreateFromDataRequest(args);
            FlightBookingCreateFromDataResponse sapResponse = sapClient_.FlightBookingCreateFromData(createRequest);
            return BuildCreateFromDataResponse(sapResponse);
        }

        private FlightBookingCreateFromData BuildCreateFromDataRequest(IFlightBookingData args)
        {
            Bapisbonew bookingData = ConvertFlightBookingDataToBapisbonew(args);
            string reserved = SAPConverter.ConvertBoolToStringForSAP(args.Reserved);

            return new FlightBookingCreateFromData
            {
                BookingData = bookingData,
                ReserveOnly = reserved
            };
        }

        private ProxyFlightBookingResponse BuildCreateFromDataResponse(FlightBookingCreateFromDataResponse sapResponse)
        {

            ReturnCodeProxys returnCode = SAPConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            IFlightBookingData flightBookingData = new FlightBookingDataSAP()
            {
                BookingId = sapResponse.BookingNumber
            };
            flightBookingData.FlightData.AirlineId = sapResponse.AirlineID;

            ProxyFlightBookingResponse result = new ProxyFlightBookingResponse
            {
                ReturnCode = returnCode,
                Message = message,
                FlightBookingData = flightBookingData
            };

            return result;
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

        public ProxyFlightBookingResponse GetList(IFlightBookingData args)
        {
            var getListRequest = BuildGetListRequest(args); 
            FlightBookingGetListResponse sapResponse = sapClient_.FlightBookingGetList(getListRequest);
            return BuildGetListResponse(sapResponse);
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

        private ProxyFlightBookingResponse BuildGetListResponse(FlightBookingGetListResponse sapResponse)
        {
            ReturnCodeProxys returnCode = SAPConverter.TypeToReturnCode(sapResponse.Return[0].Type);
            IFlightBookingData[] flightBookingDatas = ConvertBookingListToFlightBookingData(sapResponse.BookingList);
            string message = sapResponse.Return[0].Message;

            ProxyFlightBookingResponse result = new ProxyFlightBookingResponse
            {
                ReturnCode = returnCode,
                FlightBookingDatas = flightBookingDatas,
                Message = message,
            };

            return result;
        }

        private Bapisfldra ConvertFromDateRangeToBapisfldra(IDateRange dateRange)
        {
            string option = SAPConverter.ConvertDateRangeOptionToString(dateRange.Option);

            Bapisfldra result = new Bapisfldra
            {
                Sign = "I",
                Option = option,
                Low = dateRange.EarlierDate,
                High = dateRange.LaterDate

            };

            return result;
        }

        private IFlightBookingData[] ConvertBookingListToFlightBookingData(Bapisbodat[] bookingList)
        {
            IFlightBookingData[] flightBookingDatas = new IFlightBookingData[bookingList.Length];

            for(int i = 0; i < bookingList.Length; ++i)
            {
                var booking = bookingList[i];
                var flightBookingData = new FlightBookingDataSAP()
                {
                    BookingId = booking.Bookingid,
                    CustomerId = booking.Customerid,
                    Class = booking.Class,
                    Counter = booking.Counter,
                    AgencyId = booking.Agencynum,
                    Reserved = SAPConverter.ConvertStringOfSAPToBool(booking.Reserved),
                    Cancelled = SAPConverter.ConvertStringOfSAPToBool(booking.Cancelled),
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
    }
}
