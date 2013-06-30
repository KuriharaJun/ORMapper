using System.Collections.Generic;
using System.Reflection;

namespace KORMapper
{
    /// <summary>
    /// 共通モデルクラス
    /// </summary>
    public abstract class ClsCommonModel
    {
        /// <summary>
        /// モデル情報取得処理
        /// </summary>
        /// <returns>モデル情報</returns>
        public ModelStruct GetModelInfo()
        {
            // 読み取り時利用モデル情報格納領域
            var tableInfo = new Dictionary<string, List<string>>();

            // パラメータ設定情報格納領域
            var paramInfo = new Dictionary<string, List<ParamStruct>>();

            this.GetPropertyModelInfo(tableInfo, paramInfo);

            this.GetFieldModelInfo(tableInfo, paramInfo);

            var modelInfo = new ModelStruct(tableInfo, paramInfo);

            return modelInfo;
        }

        /// <summary>
        /// プロパティからモデル情報取得
        /// </summary>
        /// <param name="tableInfo">読み取り時利用モデル情報格納領域</param>
        /// <param name="paramList">パラメータ設定情報格納領域</param>
        private void GetPropertyModelInfo(Dictionary<string, List<string>> tableInfo, Dictionary<string, List<ParamStruct>> paramList)
        {
            PropertyInfo[] arProperties = this.GetType().GetProperties();

            // 属性情報取得・格納処理
            foreach (var info in arProperties)
            {
                DataMapperAttribute[] arAt = (DataMapperAttribute[])info.GetCustomAttributes(typeof(DataMapperAttribute), false);

                if (arAt != null)
                {
                    foreach (var at in arAt)
                    {
                        // 読み取り時利用モデル情報設定
                        if (string.IsNullOrEmpty(at.Column) == false)
                        {
                            if (tableInfo.ContainsKey(at.Table) == false)
                            {
                                tableInfo.Add(at.Table, new List<string>() { at.Column });
                            }
                            else
                            {
                                tableInfo[at.Table].Add(at.Column);
                            }
                        }

                        // パラメータ情報設定
                        if (string.IsNullOrEmpty(at.Param) == false)
                        {
                            if (paramList.ContainsKey(at.Table) == false)
                            {
                                paramList.Add(at.Table, new List<ParamStruct>() { new ParamStruct(at.Param, at.ParamOrder) });
                            }
                            else
                            {
                                paramList[at.Table].Add(new ParamStruct(at.Param, at.ParamOrder));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// フィールドからモデル情報取得
        /// </summary>
        /// <param name="tableInfo">読み取り時利用モデル情報格納領域</param>
        /// <param name="paramList">パラメータ設定情報格納領域</param>
        private void GetFieldModelInfo(Dictionary<string, List<string>> tableInfo, Dictionary<string, List<ParamStruct>> paramList)
        {
            FieldInfo[] arFields = this.GetType().GetFields();

            // 属性情報取得・格納処理
            foreach (var info in arFields)
            {
                DataMapperAttribute[] arAt = (DataMapperAttribute[])info.GetCustomAttributes(typeof(DataMapperAttribute), true);

                if (arAt != null)
                {
                    foreach (var at in arAt)
                    {
                        // 読み取り時利用モデル情報設定
                        if (tableInfo.ContainsKey(at.Table) == false)
                        {
                            tableInfo.Add(
                                at.Table,
                                new List<string>()
                            {
                                at.Column
                            });
                        }
                        else
                        {
                            tableInfo[at.Table].Add(at.Column);
                        }

                        // パラメータ情報設定
                        if (string.IsNullOrEmpty(at.Param) == false)
                        {
                            if (paramList.ContainsKey(at.Table) == false)
                            {
                                paramList.Add(
                                    at.Table,
                                    new List<ParamStruct>()
                                {
                                    new ParamStruct(at.Param, at.ParamOrder)
                                });
                            }
                            else
                            {
                                paramList[at.Table].Add(new ParamStruct(at.Param, at.ParamOrder));
                            }
                        }
                    }
                }
            }
        }

        #region Entity情報格納エリア
        /// <summary>
        /// モデル情報格納構造体
        /// </summary>
        public struct ModelStruct
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="tableInfo">読み取り時利用モデル情報</param>
            /// <param name="param">パラメータ設定情報</param>
            public ModelStruct(Dictionary<string, List<string>> tableInfo, Dictionary<string, List<ParamStruct>> param)
                : this()
            {
                this.TableInfo = tableInfo;
                this.Param = param;
            }

            /// <summary>
            /// 読み取り時利用モデル情報
            /// </summary>
            public Dictionary<string, List<string>> TableInfo { get; private set; }

            /// <summary>
            /// パラメータ設定情報
            /// </summary>
            public Dictionary<string, List<ParamStruct>> Param { get; private set; }
        }

        /// <summary>
        /// パラメータ情報格納構造体
        /// </summary>
        public struct ParamStruct
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="param">パラメータ名</param>
            /// <param name="paramOrder">パラメータ順序</param>
            public ParamStruct(string param, uint paramOrder)
                : this()
            {
                this.Param = param;
                this.ParamOrder = paramOrder;
            }

            /// <summary>
            /// パラメータ名
            /// </summary>
            public string Param { get; private set; }

            /// <summary>
            /// パラメータ順序
            /// </summary>
            public uint ParamOrder { get; private set; }
        }
        #endregion
    }
}
