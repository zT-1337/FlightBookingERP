using System;
using FlighBooking_ThomasZerr.Models.DateRanges;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    abstract class Proxy
    {
        public abstract string Username { get; set; }
        public abstract string Password { set; }

        protected ReturnCodeProxys TypeToReturnCode(string type)
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

        protected string ConvertDateRangeOptionToString(DateRangeOption option)
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

        protected bool ConvertStringOfSAPToBool(string toConvert)
        {
            return toConvert.Equals("X");
        }

        protected string ConvertBoolToStringForSAP(bool toConvert)
        {
            if (toConvert)
                return "X";
            return "";
        }

        protected void HandleIsError(ReturnCodeProxys returnCode, string message, string messageNumber)
        {
            if (returnCode == ReturnCodeProxys.Error || returnCode == ReturnCodeProxys.Abort)
                throw new InvalidOperationException($"{message} (Fehlercode: {messageNumber})");
        }
    }
}
