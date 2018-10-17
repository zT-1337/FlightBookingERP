using System;
using System.CodeDom;
using FlighBooking_ThomasZerr.FlightBookingReference;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    class ProxySAP : IProxyERP
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

        public ProxySAP()
        {
            sapClient_ = new Z_HH_FlightBooking_MT_01Client();
        }

        public ProxyResponseERP FlightBookingConfirm(FlightBookingData args)
        {
            var confirm = new FlightBookingConfirm
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingId
            };

            FlightBookingConfirmResponse sapResponse = sapClient_.FlightBookingConfirm(confirm);

            ReturnCodeERP returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            ProxyResponseERP result = new ProxyResponseERP
            {
                ReturnCode = returnCode,
                Message = message
            };

            return result;
        }

        public ProxyResponseERP FlightBookingCancel(FlightBookingData args)
        {
            var cancel = new FlightBookingCancel
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingId
            };

            FlightBookingCancelResponse sapResponse = sapClient_.FlightBookingCancel(cancel);

            ReturnCodeERP returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            ProxyResponseERP result = new ProxyResponseERP
            {
                ReturnCode = returnCode,
                Message = message
            };

            return result;
        }

        public ProxyResponseERP FlightBookingCreateFromData(FlightBookingData args)
        {
            Bapisbonew bookingData = ConvertFlightBookingDataToBapisbonew(args);
            string reserved = ConvertBoolToStringForSAP(args.Reserved);
            
            var createFromData = new FlightBookingCreateFromData
            {
                BookingData = bookingData,
                ReserveOnly = reserved
            };

            FlightBookingCreateFromDataResponse sapResponse = sapClient_.FlightBookingCreateFromData(createFromData);

            ReturnCodeERP returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
            string message = sapResponse.Return[0].Message;
            FlightBookingData flightBookingData = new FlightBookingData
            {
                AirlineId = sapResponse.AirlineID,
                BookingId = sapResponse.BookingNumber
            };
            ProxyResponseERP result = new ProxyResponseERP
            {
                ReturnCode = returnCode,
                Message = message,
                FlightBookingData = flightBookingData
            };

            return result;
        }

        private Bapisbonew ConvertFlightBookingDataToBapisbonew(FlightBookingData args)
        {
            return new Bapisbonew
            {
                Agencynum = args.AgencyId,
                Airlineid = args.AirlineId,
                Class = args.Class,
                Connectid = args.ConnectId,
                Counter = args.Counter,
                Customerid = args.CustomerId,
                Flightdate = args.Flightdate,
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

        public ProxyResponseERP FlightBookingGetList(FlightBookingData args)
        {
            Bapisfldra[] bookingDateRange = {ConvertFromDateRangeToBapisfldra(args.BookingDateRange)};
            Bapisfldra[] flightDateRange = {ConvertFromDateRangeToBapisfldra(args.FlightDateRange)};

            var getList = new FlightBookingGetList
            {
                Airline = args.AirlineName,
                TravelAgency = args.TravelAgency,
                CustomerNumber = args.CustomerId,
                BookingDateRange = bookingDateRange,
                FlightDateRange = flightDateRange,
            };

            FlightBookingGetListResponse sapResponse = sapClient_.FlightBookingGetList(getList);

            //TODO Warum hier ein Array von Returns?
            ReturnCodeERP returnCode = ConvertTypeToReturnCode(sapResponse.Return[0].Type);
            FlightBookingData[] flightBookingDatas = ConvertBookingListToFlightBookingData(sapResponse.BookingList);
            string message = sapResponse.Return[0].Message;

            ProxyResponseERP result = new ProxyResponseERP
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

            throw new NotImplementedException();
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

        private ReturnCodeERP ConvertTypeToReturnCode(string type)
        {
            switch (type)
            {
                case "S":
                    return ReturnCodeERP.Success;
                case "E":
                    return ReturnCodeERP.Error;
                case "W":
                    return ReturnCodeERP.Warning;
                case "I":
                    return ReturnCodeERP.Information;
                case "A":
                    return ReturnCodeERP.Abort;
            }

            throw new InvalidOperationException($"Gegebener Type unbekannt: {type}");
        }

        private FlightBookingData[] ConvertBookingListToFlightBookingData(Bapisbodat[] bookingList)
        {
            FlightBookingData[] flightBookingDatas = new FlightBookingData[bookingList.Length];

            for (int i = 0; i < bookingList.Length; ++i)
            {
                var booking = bookingList[i];
                var flightBookingData = new FlightBookingData
                {
                    AirlineId = booking.Airlineid,
                    BookingId = booking.Bookingid,
                    ConnectId = booking.Connectid,
                    Flightdate = booking.Flightdate,
                    CustomerId = booking.Customerid,
                    Class = booking.Class,
                    Bookdate = booking.Bookdate,
                    Counter = booking.Counter,
                    AgencyId = booking.Agencynum,
                    Reserved = ConvertStringOfSAPToBool(booking.Reserved),
                    Cancelled = ConvertStringOfSAPToBool(booking.Cancelled),
                    PassagierName = booking.Passname
                };
            }

            return flightBookingDatas;
        }

        private bool ConvertStringOfSAPToBool(string toConvert)
        {
            return toConvert.Equals("X");
        }
    }
}
