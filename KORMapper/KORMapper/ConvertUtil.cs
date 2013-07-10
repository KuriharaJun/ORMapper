using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper
{
    /// <summary>
    /// 共通変換クラス
    /// </summary>
    public class ConvertUtil
    {
        public static bool ConvertBoolValue(object value)
        {
            return Convert.ToBoolean(value);
        }

        public static byte ConvertByteValue(object value)
        {
            return Convert.ToByte(value);
        }

        public static char ConvertCharValue(object value)
        {
            return Convert.ToChar(value);
        }

        public static DateTime ConvertDateTimeValue(object value)
        {
            return Convert.ToDateTime(value);
        }

        public static decimal ConvertDecimalValue(object value)
        {
            return Convert.ToDecimal(value);
        }

        public static double ConvertDoubleValue(object value)
        {
            return Convert.ToDouble(value);
        }

        public static short ConvertShortValue(object value)
        {
            return Convert.ToInt16(value);
        }

        public static int ConvertIntValue(object value)
        {
            return Convert.ToInt32(value);
        }

        public static long ConvertLongValue(object value)
        {
            return Convert.ToInt64(value);
        }

        public static sbyte ConvertSbyteValue(object value)
        {
            return Convert.ToSByte(value);
        }

        public static float ConvertSingleValue(object value)
        {
            return Convert.ToSingle(value);
        }

        public static string ConvertStringValue(object value)
        {
            return Convert.ToString(value);
        }

        public static TimeSpan ConvertTimeSpanValue(object value)
        {
            return TimeSpan.Parse(value.ToString());
        }

        public static ushort ConvertUshortValue(object value)
        {
            return Convert.ToUInt16(value);
        }

        public static uint ConvertUintValue(object value)
        {
            return Convert.ToUInt32(value);
        }

        public static ulong ConvertUlongValue(object value)
        {
            return Convert.ToUInt64(value);
        }
    }
}
