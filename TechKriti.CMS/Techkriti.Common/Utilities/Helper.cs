using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Techkriti.Common.Utilities
{
    public static class Helper
    {
        public static DateTime? ConvertStringToDate(string dateString)
        {
            DateTime result;           

            if (DateTime.TryParse(dateString, out result)) return result;
            else return null;
        }
    }
}