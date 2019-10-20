using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

//전역 적용
namespace SimpleERP
{
    public static class CommonHelper
    {
        public static bool IsNull(this string str) => string.IsNullOrWhiteSpace(str);
        public static string IsNull(this string str, string str2) => string.IsNullOrWhiteSpace(str) ? str2 : str;

        public static bool In(this string str, params string[] str2)
        {
            if (str.IsNull() || str2 == null)
                return false;

            return str2.Contains(str);
        }

        public static string ToString(this DateTime? datetime, string format = "yyyyMMdd")
        {
            if (datetime == null)
                return null;

            return datetime?.ToString(format);
        }

        public static DateTime? ToDateTime(this string str, string format = "yyyy-MM-dd")
        {
            if (str.IsNull())
                return null;

            if (str.Length == 8)
                format = "yyyyMMdd";

            return DateTime.ParseExact(str, format, CultureInfo.CurrentCulture);
        }
    }
}
