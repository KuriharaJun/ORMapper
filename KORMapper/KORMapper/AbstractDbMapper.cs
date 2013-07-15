using System;
using System.Collections.Generic;
using System.Data;
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
        protected void SetProperty<T>(PropertyInfo pi, object value, T typeObject, Type toType)
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
        /// プロパティに値を設定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columns"></param>
        /// <param name="value"></param>
        /// <param name="typeObject"></param>
        protected bool SetPropertyValue<T>(string columns, object value, T typeObject)
        {
            PropertyInfo[] arPi = typeof(T).GetProperties();

            foreach (var pi in arPi)
            {
                var at = (DataMapperAttribute)Attribute.GetCustomAttribute(pi, typeof(DataMapperAttribute));

                if (at != null)
                {
                    if (at.Column == columns)
                    {
                        SetProperty<T>(pi, value, typeObject, pi.PropertyType);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// フィールドへの値設定（型変換実行）
        /// </summary>
        /// <typeparam name="T">対象型</typeparam>
        /// <param name="fi">フィールド情報</param>
        /// <param name="value">設定値</param>
        /// <param name="typeObject">設定対象オブジェクト</param>
        /// <param name="toType">変換型</param>
        protected void SetField<T>(FieldInfo fi, object value, T typeObject, Type toType)
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

        /// <summary>
        /// フィールドに値を設定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columns"></param>
        /// <param name="value"></param>
        /// <param name="typeObject"></param>
        protected bool SetFieldValue<T>(string columns, object value, T typeObject)
        {
            FieldInfo[] arFi = typeof(T).GetFields();

            foreach (var fi in arFi)
            {
                var at = (DataMapperAttribute)Attribute.GetCustomAttribute(fi, typeof(DataMapperAttribute));

                if (at != null)
                {
                    if (at.Column == columns)
                    {
                        SetField<T>(fi, value, typeObject, fi.MemberType.GetType());
                        return true;
                    }
                }
            }
            return false;
        }

        ///// <summary>
        ///// 対象型のプロパティ・フィールド属性値をすべて取得
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //protected Dictionary<string, List<string>> GetAttribute<T>() where T : new()
        //{
        //    T t = new T();
        //    Dictionary<string, List<string>> tableMapper = new Dictionary<string, List<string>>();

        //    GetPropertyAttribute<T>(tableMapper);
        //    GetFieldAttribute<T>(tableMapper);

        //    return tableMapper;
        //}

        ///// <summary>
        ///// プロパティの属性値をすべて取得
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="tableMapper"></param>
        ///// <param name="typeObject"></param>
        //protected void GetPropertyAttribute<T>(Dictionary<string, List<string>> tableMapper)
        //{
        //    PropertyInfo[] arPi = typeof(T).GetProperties();
        //    foreach (PropertyInfo pi in arPi)
        //    {
        //        DataMapperAttribute at = (DataMapperAttribute)Attribute.GetCustomAttribute(pi, typeof(DataMapperAttribute));

        //        if (at == null)
        //        {
        //            // 属性設定なしの場合は無視
        //        }
        //        else if (tableMapper.ContainsKey(at.Table) == true)
        //        {
        //            tableMapper[at.Table].Add(at.Column);
        //        }
        //        else
        //        {
        //            var entities = new List<string>();
        //            entities.Add(at.Column);
        //            tableMapper.Add(at.Table, entities);
        //        }
        //    }
        //}

        ///// <summary>
        ///// フィールドの属性値をすべて取得
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="tableMapper"></param>
        ///// <param name="typeObject"></param>
        //protected void GetFieldAttribute<T>(Dictionary<string, List<string>> tableMapper)
        //{
        //    FieldInfo[] arFi = typeof(T).GetFields(BindingFlags.GetField);

        //    foreach (FieldInfo fi in arFi)
        //    {
        //        DataMapperAttribute at = (DataMapperAttribute)Attribute.GetCustomAttribute(fi, typeof(DataMapperAttribute));
        //        if (tableMapper.ContainsKey(at.Table) == true)
        //        {
        //            tableMapper[at.Table].Add(at.Column);
        //        }
        //        else
        //        {
        //            var entities = new List<string>();
        //            entities.Add(at.Column);
        //            tableMapper.Add(at.Table, entities);
        //        }
        //    }
        //}

        /// <summary>
        /// データアクセス層からデータを読み出し、格納型Listに設定する
        /// </summary>
        /// <typeparam name="T">格納型</typeparam>
        /// <param name="da">データアクセス層</param>
        /// <returns></returns>
        protected List<T> GetData<T>(DataTable da)
        {
            List<T> dataList = null;

            // DataTable 設定なし
            if (da == null)
            {
                return dataList;
            }
            else if (Injector.MappingData.ContainsKey(da.TableName) == false)
            {
                return dataList;
            }
            else
            {
                // マッピングキーの取得
                var keyDic = Injector.MappingData[da.TableName];

                dataList = new List<T>();
                foreach (DataRow dr in da.Rows)
                {
                    var keyList = this.GetColumnList(keyDic);

                    // 値の設定
                    this.SetValue(dataList, dr, keyList);
                }
                return dataList;
            }
        }

        /// <summary>
        /// マッピングテーブルからカラムキーリスト取得
        /// </summary>
        /// <param name="keyDic">マッピングテーブル</param>
        /// <returns>カラムキーリスト</returns>
        private List<string> GetColumnList(Dictionary<string,object> keyDic)
        {
            // マッピングテーブルにキー[Column]が存在しない
            if (keyDic.ContainsKey("Column") == false)
            {
                throw new KORMapper.Exception.KORMapperException("MappingTable don't have Column key.");
            }

            // 型チェック
            var keyList = keyDic["Column"] as List<string>;

            if (keyList == null)
            {
                throw new InvalidCastException("MappingTable doesn't cast object to List<string>type.");
            }

            return keyList;
        }

        /// <summary>
        /// DB値設定
        /// </summary>
        /// <typeparam name="T">要素型</typeparam>
        /// <param name="dataList">設定先リスト</param>
        /// <param name="dr">データ</param>
        /// <param name="keyList">キーリスト</param>
        private void SetValue<T>(List<T> dataList, DataRow dr, List<string> keyList)
        {
            T model = Activator.CreateInstance<T>();

            foreach (string key in keyList)
            {
                object o = dr[key];
                if (SetPropertyValue<T>(key, o, model) == false)
                {
                    if (SetFieldValue<T>(key, o, model) == false)
                    {
                        // 無視
                    }
                }
            }
            dataList.Add(model);
        }
    }
}
