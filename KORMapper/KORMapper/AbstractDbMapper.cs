using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KORMapper
{
    /// <summary>
    /// DBMapper共通クラス
    /// <para>DBMapperは必ずこのクラスを継承すること</para>
    /// </summary>
    public class AbstractDbMapper : IDBMapper
    {
        /// <summary>
        /// プロパティへの値設定
        /// </summary>
        /// <typeparam name="T">対象型</typeparam>
        /// <param name="pi">プロパティ情報</param>
        /// <param name="value">設定値</param>
        /// <param name="typeObject">設定対象オブジェクト</param>
        /// <param name="toType">変換型</param>
        private void SetProperty<T>(PropertyInfo pi, object value, T typeObject, Type toType)
        {
            if (toType == typeof(bool))
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertBoolValue(value), null);
            }
            else if (toType == typeof(byte))
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertByteValue(value), null);
            }
            else if (typeof(char) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertCharValue(value), null);
            }
            else if (typeof(DateTime) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertDateTimeValue(value), null);
            }
            else if (typeof(decimal) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertDecimalValue(value), null);
            }
            else if (typeof(double) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertDoubleValue(value), null);
            }
            else if (typeof(short) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertShortValue(value), null);
            }
            else if (typeof(int) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertIntValue(value), null);
            }
            else if (typeof(long) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertLongValue(value), null);
            }
            else if (typeof(sbyte) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertSbyteValue(value), null);
            }
            else if (typeof(float) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertSingleValue(value), null);
            }
            else if (typeof(string) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertStringValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(TimeSpan) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertTimeSpanValue(value), null);
            }
            else if (typeof(ushort) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertUshortValue(value), null);
            }
            else if (typeof(uint) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertUintValue(value), null);
            }
            else if (typeof(ulong) == toType)
            {
                pi.SetValue(typeObject, ConvertUtil.ConvertUlongValue(value), null);
            }
            else if (typeof(bool?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertBoolValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(byte?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertByteValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(char?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertCharValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(DateTime?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertDateTimeValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(decimal?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertByteValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(double?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertDoubleValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(short?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertShortValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(int?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertIntValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(long?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertLongValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(sbyte?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertSbyteValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(float?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertSingleValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(TimeSpan?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertTimeSpanValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(ushort?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertUshortValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(uint?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertUintValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
            else if (typeof(ulong?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ConvertUtil.ConvertUlongValue(value), null);
                }
                else
                {
                    pi.SetValue(typeObject, null, null);
                }
            }
        }

        /// <summary>
        /// フィールドへの値設定（型変換実行）
        /// </summary>
        /// <typeparam name="T">対象型</typeparam>
        /// <param name="fi">フィールド情報</param>
        /// <param name="value">設定値</param>
        /// <param name="typeObject">設定対象オブジェクト</param>
        /// <param name="toType">変換型</param>
        private void SetField<T>(FieldInfo fi, object value, T typeObject, Type toType)
        {
            if (toType == typeof(bool))
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertBoolValue(value));
            }
            else if (toType == typeof(byte))
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertByteValue(value));
            }
            else if (typeof(char) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertCharValue(value));
            }
            else if (typeof(DateTime) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertDateTimeValue(value));
            }
            else if (typeof(decimal) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertDecimalValue(value));
            }
            else if (typeof(double) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertDoubleValue(value));
            }
            else if (typeof(short) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertShortValue(value));
            }
            else if (typeof(int) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertIntValue(value));
            }
            else if (typeof(long) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertLongValue(value));
            }
            else if (typeof(sbyte) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertSbyteValue(value));
            }
            else if (typeof(float) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertSingleValue(value));
            }
            else if (typeof(string) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertStringValue(value));
            }
            else if (typeof(TimeSpan) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertTimeSpanValue(value));
            }
            else if (typeof(ushort) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertUshortValue(value));
            }
            else if (typeof(uint) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertUintValue(value));
            }
            else if (typeof(ulong) == toType)
            {
                fi.SetValue(typeObject, ConvertUtil.ConvertUlongValue(value));
            }
            else if (typeof(bool?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertBoolValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(byte?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertByteValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(DateTime?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertDateTimeValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(short?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertShortValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(int?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertIntValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(long?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertLongValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(sbyte?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertSbyteValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(float?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertShortValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
            else if (typeof(TimeSpan?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ConvertUtil.ConvertTimeSpanValue(value));
                }
                else
                {
                    fi.SetValue(typeObject, null);
                }
            }
        }
    }
}
