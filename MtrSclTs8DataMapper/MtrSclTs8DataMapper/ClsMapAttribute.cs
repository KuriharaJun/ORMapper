using System;

namespace MtrSclTs8
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
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
        /// コンストラクタ
        /// </summary>
        /// <param name="table">テーブル名</param>
        /// <param name="columns">カラム名</param>
        public DatabaseMapAttribute(string table, string columns)
        {
            this.Table = table;
            this.Columns = columns;
        }
    }
}