using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace MtrSclTs8
{
    public class ClsDataMapper
    {
        public List<T> GetDataToObject<T>(DataTable da) where T : new ()
        {
            Dictionary<string, List<string>> dataMapper = GetAttribute<T>();

            Dictionary<string, Type> culumnType = GetCulumnType(da);

            List<T> modelList = GetData<T>(da, dataMapper, culumnType);
            return modelList;
        }

        /// <summary>
        /// 対象型のプロパティ・フィールド属性値をすべて取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private Dictionary<string,List<string>> GetAttribute<T>() where T : new ()
        {
            T t = new T();
            Dictionary<string, List<string>> tableMapper = new Dictionary<string, List<string>>();

            GetPropertyAttribute<T>(tableMapper, t);
            GetFieldAttribute<T>(tableMapper, t);

            return tableMapper;
        }

        /// <summary>
        /// プロパティの属性値をすべて取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableMapper"></param>
        /// <param name="typeObject"></param>
        private void GetPropertyAttribute<T>(Dictionary<string, List<string>> tableMapper, T typeObject)
        {
            PropertyInfo[] arPi = typeObject.GetType().GetProperties();
            foreach (PropertyInfo pi in arPi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(pi, typeof(DatabaseMapAttribute));

                if (at == null)
                {
                    // 属性設定なしの場合は無視
                }
                else if (tableMapper.ContainsKey(at.Table) == true)
                {
                    tableMapper[at.Table].Add(at.Columns);
                }
                else
                {
                    var entities = new List<string>();
                    entities.Add(at.Columns);
                    tableMapper.Add(at.Table, entities);
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
        private bool SetPropertyValue<T>(string columns, object value, T typeObject)
        {
            PropertyInfo[] arPi = typeObject.GetType().GetProperties();

            foreach (PropertyInfo pi in arPi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(pi, typeof(DatabaseMapAttribute));

                if (at != null)
                {
                    if (at.Columns == columns)
                    {
                        SetProperty<T>(pi, value, typeObject, pi.PropertyType);
                        return true;
                    }
                }
            }

            return false;
        }

        private void SetProperty<T>(PropertyInfo pi, object value, T typeObject, Type toType)
        {
            if (toType == typeof(bool))
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertBoolValue(value),null);
            } else if (toType == typeof(byte)) {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertByteValue(value), null);
            }
            else if (typeof(char) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertCharValue(value), null);
            }
            else if (typeof(DateTime) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertDateTimeValue(value), null);
            }
            else if (typeof(Decimal) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertDecimalValue(value), null);
            }
            else if (typeof(double) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertDoubleValue(value), null);
            }
            else if (typeof(short) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertShortValue(value), null);
            }
            else if (typeof(int) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertIntValue(value), null);
            }
            else if (typeof(long) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertLongValue(value), null);
            }
            else if (typeof(sbyte) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertSbyteValue(value), null);
            }
            else if (typeof(Single) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertSingleValue(value), null);
            }
            else if (typeof(string) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertStringValue(value), null);
            }
            else if (typeof(TimeSpan) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertTimeSpanValue(value), null);
            }
            else if (typeof(ushort) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertUshortValue(value), null);
            }
            else if (typeof(uint) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertUintValue(value), null);
            }
            else if (typeof(ulong) == toType)
            {
                pi.SetValue(typeObject, ClsConvertUtil.ConvertUlongValue(value), null);
            }

        }


        /// <summary>
        /// フィールドの属性値をすべて取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableMapper"></param>
        /// <param name="typeObject"></param>
        private void GetFieldAttribute<T>(Dictionary<string, List<string>> tableMapper, T typeObject)
        {
            FieldInfo[] arFi = typeObject.GetType().GetFields(BindingFlags.GetField);

            foreach (FieldInfo fi in arFi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(fi, typeof(DatabaseMapAttribute));
                if (tableMapper.ContainsKey(at.Table) == true)
                {
                    tableMapper[at.Table].Add(at.Columns);
                }
                else
                {
                    var entities = new List<string>();
                    entities.Add(at.Columns);
                    tableMapper.Add(at.Table, entities);
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
        private bool SetFieldValue<T>(string columns, object value, T typeObject)
        {
            FieldInfo[] arFi = typeObject.GetType().GetFields();

            foreach (FieldInfo fi in arFi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(fi, typeof(DatabaseMapAttribute));

                if (at != null)
                {
                    if (at.Columns == columns)
                    {
                        SetField<T>(fi, value, typeObject, fi.MemberType.GetType());
                        return true;
                    }
                }
            }
            return false;
        }

        private void SetField<T>(FieldInfo fi, object value, T typeObject, Type toType)
        {
            if (toType == typeof(bool))
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertBoolValue(value));
            }
            else if (toType == typeof(byte))
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertByteValue(value));
            }
            else if (typeof(char) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertCharValue(value));
            }
            else if (typeof(DateTime) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertDateTimeValue(value));
            }
            else if (typeof(Decimal) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertDecimalValue(value));
            }
            else if (typeof(double) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertDoubleValue(value));
            }
            else if (typeof(short) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertShortValue(value));
            }
            else if (typeof(int) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertIntValue(value));
            }
            else if (typeof(long) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertLongValue(value));
            }
            else if (typeof(sbyte) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertSbyteValue(value));
            }
            else if (typeof(Single) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertSingleValue(value));
            }
            else if (typeof(string) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertStringValue(value));
            }
            else if (typeof(TimeSpan) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertTimeSpanValue(value));
            }
            else if (typeof(ushort) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertUshortValue(value));
            }
            else if (typeof(uint) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertUintValue(value));
            }
            else if (typeof(ulong) == toType)
            {
                fi.SetValue(typeObject, ClsConvertUtil.ConvertUlongValue(value));
            }

        }

        private List<T> GetData<T>(DataTable da, Dictionary<string, List<string>> mapper, Dictionary<string, Type> culumnType) where T : new()
        {
            var dataList = new List<T>();
            if (da == null)
            {
                return dataList;
            }
            else
            {                
                if (mapper.ContainsKey(da.TableName) == false)
                {
                    return dataList;
                }
                else
                {
                    List<string> keyList = mapper[da.TableName];
                    foreach (DataRow dr in da.Rows)
                    {
                        T model = new T();
                        
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

                return dataList;
            }
        }

        private Dictionary<string, Type> GetCulumnType(DataTable da)
        {
            var culumnType = new Dictionary<string, Type>();
            for (int i = 0; i < da.Columns.Count; i++)
            {
                culumnType.Add(da.Columns[i].ColumnName, da.Columns[i].DataType);
            }
            return culumnType;
        }
    }
}
