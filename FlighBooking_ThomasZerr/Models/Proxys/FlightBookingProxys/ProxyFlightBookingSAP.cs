using System;
using FlighBooking_ThomasZerr.FlightBookingReference;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

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
            var confirm = new FlightBookingConfirm
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingId
            };

            FlightBookingConfirmResponse sapResponse = sapClient_.FlightBookingConfirm(confirm);

            ReturnCodeProxys returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
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
            var cancel = new FlightBookingCancel
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingId
            };

            FlightBookingCancelResponse sapResponse = sapClient_.FlightBookingCancel(cancel);

            ReturnCodeProxys returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
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
            Bapisbonew bookingData = ConvertFlightBookingDataToBapisbonew(args);
            string reserved = ConvertBoolToStringForSAP(args.Reserved);
            
            var createFromData = new FlightBookingCreateFromData
            {
                BookingData = bookingData,
                ReserveOnly = reserved
            };

            FlightBookingCreateFromDataResponse sapResponse = sapClient_.FlightBookingCreateFromData(createFromData);

            ReturnCodeProxys returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            IFlightBookingData flightBookingData = new FlightBookingDataSAP()
            {
                AirlineId = sapResponse.AirlineID,
                BookingId = sapResponse.BookingNumber
            };
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
                Airlineid = args.AirlineId,
                Class = args.Class,
                Connectid = args.ConnectId,
                Counter = args.Counter,
                Customerid = args.CustomerId,
                Flightdate = args.Flightdate.DateString,
                Passname = args.PassagierName
            };
        }

        private string ConvertBoolToStringForSAP(bool toConvert)
        {
            if (toConvert)
                return "X";
            else
                return "";
        }

        public ProxyFlightBookingResponse GetList(IFlightBookingData args)
        {
            Bapisfldra[] bookingDateRange = {ConvertFromDateRangeToBapisfldra(args.BookingDateRange)};
            Bapisfldra[] flightDateRange = {ConvertFromDateRangeToBapisfldra(args.FlightDateRange)};

            var getList = new FlightBookingGetList
            {
                //TODO zu entfernen
                MaxRowsSpecified = true,
                MaxRows = 100,
                Airline = args.AirlineId,
                TravelAgency = args.AgencyId,
                CustomerNumber = args.CustomerId,
                BookingDateRange = bookingDateRange,
                FlightDateRange = flightDateRange
            };

            FlightBookingGetListResponse sapResponse = sapClient_.FlightBookingGetList(getList);

            //TODO Warum hier ein Array von Returns?
            ReturnCodeProxys returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
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

        private ReturnCodeProxys ConvertTypeToReturnCode(string type)
        {
            switch (type)
            {
                case "S":
                    return ReturnCodeProxys.Success;
                case "E":
                    return ReturnCodeProxys.Error;
                case "W":
                    return ReturnCodeProxys.Warning;
                case "I":
                    return ReturnCodeProxys.Information;
                case "A":
                    return ReturnCodeProxys.Abort;
            }

            throw new InvalidOperationException($"Gegebener Type unbekannt: {type}");
        }

        private IFlightBookingData[] ConvertBookingListToFlightBookingData(Bapisbodat[] bookingList)
        {
            IFlightBookingData[] flightBookingDatas = new IFlightBookingData[bookingList.Length];

            for(int i = 0; i < bookingList.Length; ++i)
            {
                var booking = bookingList[i];
                var flightBookingData = new FlightBookingDataSAP()
                {
                    AirlineId = booking.Airlineid,
                    BookingId = booking.Bookingid,
                    ConnectId = booking.Connectid,
                    CustomerId = booking.Customerid,
                    Class = booking.Class,
                    Counter = booking.Counter,
                    AgencyId = booking.Agencynum,
                    Reserved = ConvertStringOfSAPToBool(booking.Reserved),
                    Cancelled = ConvertStringOfSAPToBool(booking.Cancelled),
                    PassagierName = booking.Passname
                };
                flightBookingData.Flightdate.DateString = booking.Flightdate;
                flightBookingData.Bookdate.DateString = booking.Bookdate;

                flightBookingDatas[i] = flightBookingData;
            }

            return flightBookingDatas;
        }

        private bool ConvertStringOfSAPToBool(string toConvert)
        {
            return toConvert.Equals("X");
        }
    }
}
