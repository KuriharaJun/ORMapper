using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace KORMapper
{
    /// <summary>
    /// マッピング処理実行クラス
    /// </summary>
    public class ClsDataMapper
    {
        /// <summary>
        /// O/Rマッピング連続実行処理
        /// <para>Object → Database → Object</para>
        /// </summary>
        /// <typeparam name="T">パラメータオブジェクト型</typeparam>
        /// <typeparam name="U">戻りデータ格納オブジェクト型</typeparam>
        /// <param name="objectModel">パラメータデータ</param>
        /// <param name="tableName">テーブル名</param>
        /// <param name="command">SQLコマンド</param>
        /// <returns>SQL実行結果</returns>
        public List<U> GetORMappingResult<T, U>(T objectModel, string tableName, SqlCommand command)
            where T : new()
            where U : new()
        {
            DataTable dt = SetObjectToData<T>(objectModel, tableName, command);
            var resultList = new List<U>();

            if (dt != null)
            {
                resultList = GetDataToObject<U>(dt);
            }

            return resultList;
        }

        /// <summary>
        /// O/Rマッピング連続実行処理
        /// <para>Object → Database → Object</para>
        /// <para>パラメータ設定なし</para>
        /// </summary>
        /// <typeparam name="U">戻りデータ格納オブジェクト型</typeparam>
        /// <param name="tableName">テーブル名</param>
        /// <param name="command">SQLコマンド</param>
        /// <returns>SQL実行結果</returns>
        public List<U> GetORMappingResult<U>(string tableName, SqlCommand command) where U : new ()
        {
            DataTable dt = SelectProc(command, tableName);

            var resultList = new List<U>();

            if (dt != null)
            {
                resultList = GetDataToObject<U>(dt);
            }

            return resultList;
        }
        /// <summary>
        /// Database → Objectマッピング処理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da">検索結果格納DataTable</param>
        /// <returns></returns>
        public List<T> GetDataToObject<T>(DataTable da) where T : new ()
        {
            Dictionary<string, List<string>> dataMapper = GetAttribute<T>();

            //Dictionary<string, Type> culumnType = GetCulumnType(da);

            List<T> modelList = GetData<T>(da, dataMapper);
            return modelList;
        }

        /// <summary>
        /// Obejct → Databaseマッピング処理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectModel"></param>
        /// <param name="command"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public DataTable SetObjectToData<T>(T objectModel,string tableName, SqlCommand command) where T : new()
        {
            Dictionary<string, List<string>> dataMapper = GetAttributeParam<T>();

            // パラメータの設定
            SetParam<T>(command, dataMapper, tableName, objectModel);
            DataTable dt = SelectProc(command, tableName);
            return dt;
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
        /// 設定値の取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="param"></param>
        /// <param name="typeObject"></param>
        /// <returns></returns>
        private object GetValue<T>(string tableName, string param, T typeObject)
        {
            object value = null;

            if (GetPropertyValue<T>(tableName, param, typeObject, out value) == true)
            {
                return value;
            }
            else if (GetFieldValue<T>(tableName, param, typeObject, out value) == true)
            {
                return value;
            }

            return value;
        }

        /// <summary>
        /// 対象型のプロパティ・フィールド属性値をすべて取得（パラメータ版）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private Dictionary<string, List<string>> GetAttributeParam<T>() where T : new()
        {
            T t = new T();
            Dictionary<string, List<string>> tableMapper = new Dictionary<string, List<string>>();

            GetPropertyAttributeParam<T>(tableMapper, t);
            GetFieldAttributeParam<T>(tableMapper, t);

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
        /// プロパティの属性値をすべて取得（パラメータ）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableMapper"></param>
        /// <param name="typeObject"></param>
        private void GetPropertyAttributeParam<T>(Dictionary<string, List<string>> tableMapper, T typeObject)
        {
            PropertyInfo[] arPi = typeObject.GetType().GetProperties();
            foreach (PropertyInfo pi in arPi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(pi, typeof(DatabaseMapAttribute));

                if (at != null)
                {
                    // 属性設定されている場合のみ処理
                    if (tableMapper.ContainsKey(at.Table) == true && string.IsNullOrEmpty(at.Param) == false)
                    {
                        tableMapper[at.Table].Add(at.Param);
                    }
                    else if (string.IsNullOrEmpty(at.Param) == false)
                    {
                        var entities = new List<string>();
                        entities.Add(at.Param);
                        tableMapper.Add(at.Table, entities);
                    }
                }
                
            }
        }

        /// <summary>
        /// プロパティから値を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="param"></param>
        /// <param name="typeObject"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool GetPropertyValue<T>(string tableName, string param, T typeObject, out object value)
        {
            PropertyInfo[] arPi = typeObject.GetType().GetProperties();
            foreach (PropertyInfo pi in arPi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(pi, typeof(DatabaseMapAttribute));

                if (at != null)
                {
                    // 属性設定されている場合のみ処理
                    if (tableName == at.Table && param == at.Param)
                    {
                        value = pi.GetValue(typeObject, null);
                        return true;
                    }
                }
            }
            value = null;
            return false;
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
            else if (typeof(byte?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ClsConvertUtil.ConvertByteValue(value), null);
                }
            }
            else if (typeof(short?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ClsConvertUtil.ConvertShortValue(value), null);
                }
                else pi.SetValue(typeObject, null, null);
            }
            else if (typeof(int?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ClsConvertUtil.ConvertIntValue(value), null);
                }
                else pi.SetValue(typeObject, null, null);
            }
            else if (typeof(long?) == toType)
            {
                if (value != DBNull.Value)
                {
                    pi.SetValue(typeObject, ClsConvertUtil.ConvertLongValue(value), null);
                }
                else pi.SetValue(typeObject, null, null);
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
        /// フィールドの属性値をすべて取得（パラメータ）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableMapper"></param>
        /// <param name="typeObject"></param>
        private void GetFieldAttributeParam<T>(Dictionary<string, List<string>> tableMapper, T typeObject)
        {
            FieldInfo[] arFi = typeObject.GetType().GetFields(BindingFlags.GetField);

            foreach (FieldInfo fi in arFi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(fi, typeof(DatabaseMapAttribute));

                if (at != null)
                {
                    if (tableMapper.ContainsKey(at.Table) == true && string.IsNullOrEmpty(at.Param) == false)
                    {
                        tableMapper[at.Table].Add(at.Param);
                    }
                    else if (string.IsNullOrEmpty(at.Param) == false)
                    {
                        var entities = new List<string>();
                        entities.Add(at.Param);
                        tableMapper.Add(at.Table, entities);
                    }
                }
            }
        }

        /// <summary>
        /// フィールドから値を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">テーブル名称</param>
        /// <param name="param">パラメータ名</param>
        /// <param name="typeObject">取得対象</param>
        /// <param name="value">出力値</param>
        /// <returns></returns>
        private bool GetFieldValue<T>(string tableName, string param, T typeObject, out object value)
        {
            FieldInfo[] arFi = typeObject.GetType().GetFields();
            foreach (FieldInfo fi in arFi)
            {
                DatabaseMapAttribute at = (DatabaseMapAttribute)Attribute.GetCustomAttribute(fi, typeof(DatabaseMapAttribute));

                if (at != null)
                {
                    // 属性設定されている場合のみ処理
                    if (tableName == at.Table && param == at.Param)
                    {
                        value = fi.GetValue(typeObject);
                        return true;
                    }
                }
            }
            value = null;
            return false;
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
            else if (typeof(byte?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ClsConvertUtil.ConvertByteValue(value));
                }
                else fi.SetValue(typeObject, null);
            }
            else if (typeof(short?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ClsConvertUtil.ConvertShortValue(value));
                }
                else fi.SetValue(typeObject, null);
            }
            else if (typeof(int?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ClsConvertUtil.ConvertIntValue(value));
                }
                else fi.SetValue(typeObject, null);
            }
            else if (typeof(long?) == toType)
            {
                if (value != DBNull.Value)
                {
                    fi.SetValue(typeObject, ClsConvertUtil.ConvertLongValue(value));
                }
                else fi.SetValue(typeObject, null);
            }

        }

        /// <summary>
        /// データアクセス層からデータを読み出し、格納型Listに設定する
        /// </summary>
        /// <typeparam name="T">格納型</typeparam>
        /// <param name="da">データアクセス層</param>
        /// <param name="mapper"></param>
        /// <param name="culumnType"></param>
        /// <returns></returns>
        private List<T> GetData<T>(DataTable da, Dictionary<string, List<string>> mapper) where T : new()
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

        private void SetParam<T>(SqlCommand command, Dictionary<string, List<string>> tableMapper, string tableName, T typeObject)
        {
            if (tableMapper.ContainsKey(tableName) == false)
            {
                throw new NullReferenceException("該当するtableNameが存在しません。 : "+ tableName );
            }

            List<string> paramList = tableMapper[tableName];

            foreach (string param in paramList)
            {
                command.Parameters[param].Value = GetValue<T>(tableName, param, typeObject);
            }
        }

        /// <summary>
        /// SQLコマンド実行処理
        /// </summary>
        /// <param name="command"></param>
        /// <param name="tableName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        private DataTable SelectProc(SqlCommand command, string tableName)
        {
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(tableName);

            int rowCount = da.Fill(dt);

            return dt;
        }

        ///// <summary>
        ///// カラム型取得
        ///// </summary>
        ///// <param name="da">データベースアクセス層</param>
        ///// <returns></returns>
        //private Dictionary<string, Type> GetCulumnType(DataTable da)
        //{
        //    var culumnType = new Dictionary<string, Type>();
        //    for (int i = 0; i < da.Columns.Count; i++)
        //    {
        //        culumnType.Add(da.Columns[i].ColumnName, da.Columns[i].DataType);
        //    }
        //    return culumnType;
        //}
    }
}
