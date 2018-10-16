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

        public ProxyResponseERP FlightBookingConfirm(FlightBookingData args)
        {
            var confirm = new FlightBookingConfirm
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingConfirmResponse response = sapClient_.FlightBookingConfirm(confirm);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingCancel(FlightBookingData args)
        {
            var cancel = new FlightBookingCancel
            {
                AirlineID = args.AirlineId,
                BookingNumber = args.BookingNumber,
                TestRun = args.TestRun
            };

            FlightBookingCancelResponse response = sapClient_.FlightBookingCancel(cancel);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingCreateFromData(FlightBookingData args)
        {
            //TODO Initialisieren der Variablen
            Bapisbonew bookingData = null;
            Bapiparex[] extensionIn = null;
            
            var createFromData = new FlightBookingCreateFromData
            {
                BookingData = bookingData,
                ExtensionIn = extensionIn,
                ReserveOnly = args.ReserveOnly,
                TestRun = args.TestRun
            };

            FlightBookingCreateFromDataResponse response = sapClient_.FlightBookingCreateFromData(createFromData);

            //TODO ProxyResponseERP aus Response bauen

            throw new NotImplementedException();
        }

        public ProxyResponseERP FlightBookingGetList(FlightBookingData args)
        {
            Bapisfldra[] bookingDateRange = {ConvertFromDateRangeToBapisfldra(args.BookingDateRange)};
            Bapisfldra[] flightDateRange = {ConvertFromDateRangeToBapisfldra(args.FlightDateRange)};

            var getList = new FlightBookingGetList
            {
                Airline = args.Airline,
                TravelAgency = args.TravelAgency,
                CustomerNumber = args.CustomerNumber,
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

        private Bapisfldra ConvertFromDateRangeToBapisfldra(DateRange dateRange)
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
                    Reserved = booking.Reserved,
                    Cancelled = booking.Cancelled,
                    PassagierName = booking.Passname
                };
            }

            return flightBookingDatas;
        }
    }
}
