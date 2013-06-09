using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Reflection;
using System.Collections;

namespace MtrSclTs8DataMapper
{
    public class ClsDataMapper
    {
        public List<T> GetDataToObject<T>(DataTable da) where T : new ()
        {
            Dictionary<string, List<string>> dataMapper = GetAttribute<T>();

            Dictionary<string, Type> culumnType = GetCulumnType(da);
            
            return null;
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
                ClsMapAttribute at = (ClsMapAttribute)Attribute.GetCustomAttribute(pi, typeof(ClsMapAttribute));

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
        private bool SetPropertyValue<T,U>(string columns, object value, T typeObject)
        {
            PropertyInfo[] arPi = typeObject.GetType().GetProperties();

            foreach (PropertyInfo pi in arPi)
            {
                ClsMapAttribute at = (ClsMapAttribute)Attribute.GetCustomAttribute(pi, typeof(ClsMapAttribute));

                if (at != null)
                {
                    if (at.Columns == columns)
                    {
                        pi.SetValue(typeObject, ClsConvertUtil.ConvertValue<U>(typeof(U), value), null);
                        return true;
                    }
                }
            }

            return false;
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
                ClsMapAttribute at = (ClsMapAttribute)Attribute.GetCustomAttribute(fi, typeof(ClsMapAttribute));
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
        private bool SetFieldValue<T,U>(string columns, object value, T typeObject)
        {
            FieldInfo[] arFi = typeObject.GetType().GetFields();

            foreach (FieldInfo fi in arFi)
            {
                ClsMapAttribute at = (ClsMapAttribute)Attribute.GetCustomAttribute(fi, typeof(ClsMapAttribute));

                if (at != null)
                {
                    if (at.Columns == columns)
                    {
                        fi.SetValue(typeObject, ClsConvertUtil.ConvertValue<U>(typeof(U), value));
                        return true;
                    }
                }
            }
            return false;
        }

        private List<T> GetData<T>(DataTable dc, Dictionary<string, List<string>> mapper, Dictionary<string, Type> culumnType) where T : new()
        {
            var dataList = new List<T>();
            if (dc == null)
            {
                return dataList;
            }
            else
            {
                
                
                if (mapper.ContainsKey(dc.TableName) == false)
                {
                    return dataList;
                }
                else
                {
                    foreach (DataRow dr in dc.Rows)
                    {
                        T model = new T();
                        foreach (string key in mapper.Keys)
                        {
                            object o = dr[key];
                            
                        }
                    }
                }

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
