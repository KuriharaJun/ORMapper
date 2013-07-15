using System;

namespace KORMapper
{
    /// <summary>
    /// データマップ用属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class DataMapperAttribute : Attribute
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="table">テーブル名</param>
        public DataMapperAttribute(string table)
        {
            this.Table = table;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="table">識別用名称</param>
        /// <param name="param">パラメータ名</param>
        /// <param name="paramOrder">パラメータ順序</param>
        public DataMapperAttribute(string table, string param, uint paramOrder)
            : this(table)
        {
            this.Param = param;
            this.ParamOrder = paramOrder;
        }
        #endregion

        /// <summary>
        /// 取得情報識別用名称
        /// </summary>
        public string Table { get; private set; }

        /// <summary>
        /// カラム名
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// パラメータ
        /// </summary>
        public string Param { get; set; }

        /// <summary>
        /// パラメータ順序
        /// </summary>
        public uint? ParamOrder { get; private set; }
    }
}
