using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.Proxys;

namespace FlighBooking_ThomasZerr.Utils.SAP
{
    class SAPConverter
    {
        public static ReturnCodeProxys TypeToReturnCode(string type)
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
    }
}
