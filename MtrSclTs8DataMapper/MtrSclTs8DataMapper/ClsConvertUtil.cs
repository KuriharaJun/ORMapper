using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MtrSclTs8DataMapper
{
    public class ClsConvertUtil
    {
        public static T ConvertValue<T>(Type toType, object value) where T : Object
        {
            object o = new object();
            if (typeof(bool) == toType)
            {
                o = ConvertBoolValue(value);
            }
            else if (typeof(byte) == toType)
            {
                o = ConvertByteValue(value);
            }
            else if (typeof(char) == toType)
            {
                o = ConvertCharValue(value);
            }
            else if (typeof(DateTime) == toType)
            {
                o = ConvertDateTimeValue(value);
            }
            else if (typeof(Decimal) == toType)
            {
                o = ConvertDecimalValue(value);
            }
            else if (typeof(double) == toType)
            {
                o = ConvertDoubleValue(value);
            }
            else if (typeof(short) == toType)
            {
                o = ConvertShortValue(value);
            }
            else if (typeof(int) == toType)
            {
                o = ConvertIntValue(value);
            }
            else if (typeof(long) == toType)
            {
                o = ConvertLongValue(value);
            }
            else if (typeof(sbyte) == toType)
            {
                o = ConvertSbyteValue(value);
            }
            else if (typeof(Single) == toType)
            {
                o = ConvertSingleValue(value);
            }
            else if (typeof(TimeSpan) == toType)
            {
                o = ConvertTimeSpanValue(value);
            }
            else if (typeof(ushort) == toType)
            {
                o = ConvertUshortValue(value);
            }
            else if (typeof(uint) == toType)
            {
                o = ConvertUintrValue(value);
            }
            else if (typeof(ulong) == toType)
            {
                o = ConvertUlongValue(value);
            }
            else
            {
                o = null;
            }

            return (T)o;
        }


        private static bool ConvertBoolValue(object value)
        {
            return Convert.ToBoolean(value);
        }


        private static byte ConvertByteValue(object value)
        {
            return Convert.ToByte(value);
        }

        private static char ConvertCharValue(object value)
        {
            return Convert.ToChar(value);
        }

        private static DateTime ConvertDateTimeValue(object value)
        {
            return Convert.ToDateTime(value);
        }

        private static Decimal ConvertDecimalValue(object value)
        {
            return Convert.ToDecimal(value);
        }

        private static double ConvertDoubleValue(object value)
        {
            return Convert.ToDouble(value);
        }

        private static short ConvertShortValue(object value)
        {
            return Convert.ToInt16(value);
        }

        private static int ConvertIntValue(object value)
        {
            return Convert.ToInt32(value);
        }

        private static long ConvertLongValue(object value)
        {
            return Convert.ToInt64(value);
        }

        private static sbyte ConvertSbyteValue(object value)
        {
            return Convert.ToSByte(value);
        }

        private static Single ConvertSingleValue(object value)
        {
            return Convert.ToSingle(value);
        }

        private static string ConvertStringValue(object value)
        {
            return Convert.ToString(value);
        }

        private static TimeSpan ConvertTimeSpanValue(object value)
        {
            return TimeSpan.Parse(value.ToString());
        }

        private static ushort ConvertUshortValue(object value)
        {
            return Convert.ToUInt16(value);
        }

        private static uint ConvertUintrValue(object value)
        {
            return Convert.ToUInt32(value);
        }

        private static ulong ConvertUlongValue(object value)
        {
            return Convert.ToUInt64(value);
        }
    }
}
