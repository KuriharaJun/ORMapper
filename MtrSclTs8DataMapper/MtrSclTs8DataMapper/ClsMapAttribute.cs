using System;

namespace KORMapper
{
    /// <summary>
    /// マッピング対象認識用属性
    /// <para>設定対象：フィールド / プロパティ</para>
    /// <para>複数設定：不可</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=false)]
    public class DatabaseMapAttribute : Attribute
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public string Table { set; get; }

        /// <summary>
        /// カラム名
        /// </summary>
        public string Columns { set; get; }

        /// <summary>
        /// パラメータ
        /// </summary>
        public string Param { set; get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="table">テーブル名</param>
        /// <param name="columns">カラム名</param>
        public DatabaseMapAttribute(string table, string columns)
        {
            this.Table = table;
            this.Columns = columns;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="table">テーブル名</param>
        /// <param name="columns">カラム名</param>
        /// <param name="param">パラメータ</param>
        public DatabaseMapAttribute(string table, string columns, string param)
        {
            this.Table = table;
            this.Columns = columns;
            this.Param = param;
        }
    }
}