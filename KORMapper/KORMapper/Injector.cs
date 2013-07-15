using System;
using System.Collections.Generic;

namespace KORMapper
{
    /// <summary>
    /// DIクラス
    /// </summary>
    public class Injector
    {
        /// <summary>
        /// モデルマッピングDictionary
        /// </summary>
        private static Dictionary<string, Dictionary<string, object>> mappingData = new Dictionary<string,Dictionary<string,object>>();

        /// <summary>
        /// モデル名・テーブル名マッピング
        /// </summary>
        private static LinkedList<ObjectLinkNode> nameMapList = new LinkedList<ObjectLinkNode>();

        /// <summary>
        /// モデルマッピングDictionary
        /// </summary>
        public static Dictionary<string, Dictionary<string, object>> MappingData { get; private set; }

        /// <summary>
        /// マッピング情報設定
        /// </summary>
        /// <exception cref="InvalidCastException">DataMapper属性にキャスト不可能</exception>
        /// <exception cref="NullReferenceException">DataMapper属性が設定されていない。もしくは、Tableパラメータが設定されていない。</exception>
        public static void SetMapping()
        {
            var dDic = AbstractBind.BindDictionary;

            foreach (string s in dDic.Keys)
            {
                object[] arAt = dDic[s].GetCustomAttributes(typeof(DataMapperAttribute), true);
                if (arAt != null)
                {
                    foreach (var at in arAt)
                    {
                        var dAt = at as DataMapperAttribute;

                        if (dAt == null)
                        {
                            throw new InvalidCastException("Attribute can't cast to DataMapperAttribute.");
                        }

                        if (string.IsNullOrEmpty(dAt.Table) == true)
                        {
                            throw new NullReferenceException("this Table is not exists.");
                        }

                        if (mappingData.ContainsKey(dAt.Table) == true)
                        {
                            var mapData = mappingData[dAt.Table];
                            SetMappingInfo(mapData, dAt);
                            mappingData[dAt.Table] = mapData;
                        }
                        else
                        {
                            var mapData = new Dictionary<string, object>();
                            SetMappingInfo(mapData, dAt);
                            mappingData.Add(dAt.Table, mapData);

                            var node = new ObjectLinkNode(s, dAt.Table);
                            nameMapList.AddLast(node);
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("DataMapperAttribute is not exists.\nPlease set DatamapperAttribute.");
                }
            }
        }

        /// <summary>
        /// モデルマッピング情報設定
        /// </summary>
        /// <param name="data">マッピング情報格納ディクショナリ</param>
        /// <param name="attribute">属性</param>
        private static void SetMappingInfo(Dictionary<string, object> data, DataMapperAttribute attribute)
        {
            SetColumnValue(data, attribute.Column);
            SetParamValue(data, attribute.Param);
            SetParamOrder(data, attribute.ParamOrder);
        }

        /// <summary>
        /// カラム情報設定
        /// </summary>
        /// <param name="data">マッピング情報格納ディクショナリ</param>
        /// <param name="column">カラム</param>
        /// <exception cref="InvalidCastException">キー[Column]に対して無効なデータ型が登録されている</exception>
        private static void SetColumnValue(Dictionary<string, object> data, string column)
        {
            if (string.IsNullOrEmpty(column) == false)
            {
                if (data.ContainsKey("Column") == true)
                {
                    var val = data["Column"] as List<string>;
                    if (val == null)
                    {
                        throw new InvalidCastException("Data can't cast to List<string>.");
                    }

                    val.Add(column);
                    data["Column"] = val;
                }
                else
                {
                    var val = new List<string>();
                    val.Add(column);
                    data.Add("Column", val);
                }
            }
        }

        /// <summary>
        /// パラメータ情報設定
        /// </summary>
        /// <param name="data">マッピング情報格納ディクショナリ</param>
        /// <param name="param">パラメータ</param>
        /// <exception cref="InvalidCastException">キー[Param]に対して無効なデータ型が登録されている</exception>
        private static void SetParamValue(Dictionary<string, object> data, string param)
        {
            if (string.IsNullOrEmpty(param) == false)
            {
                if (data.ContainsKey("Param") == true)
                {
                    var val = data["Param"] as List<string>;
                    if (val == null)
                    {
                        throw new InvalidCastException("Data can't cast to List<string>.");
                    }

                    val.Add(param);
                    data["Param"] = val;
                }
                else
                {
                    var val = new List<string>();
                    val.Add(param);
                    data.Add("Param", val);
                }
            }
        }

        /// <summary>
        /// パラメータ順序設定
        /// </summary>
        /// <param name="data">マッピング情報格納ディクショナリ</param>
        /// <param name="paramOrder">パラメータ順序</param>
        /// <exception cref="InvalidCastException">キー[ParamOrder]に対して無効なデータ型が登録されている</exception>
        private static void SetParamOrder(Dictionary<string, object> data, uint? paramOrder)
        {
            if (paramOrder.HasValue == true)
            {
                if (data.ContainsKey("ParamOrder") == true)
                {
                    var val = data["ParamOrder"] as List<uint>;
                    if (val == null)
                    {
                        throw new InvalidCastException("Data can't cast to List<uint>.");
                    }

                    val.Add(paramOrder.Value);
                    data["ParamOrder"] = val;
                }
                else
                {
                    var val = new List<uint>();
                    val.Add(paramOrder.Value);
                    data.Add("ParamOrder", val);
                }
            }
        }

        private struct ObjectLinkNode
        {
            public string NodeName { get; private set; }
            public string TableName { get; private set; }

            public ObjectLinkNode(string nodeName, string tableName)
                :this()
            {
                this.NodeName = nodeName;
                this.TableName = tableName;
            }
        }
    }
}
