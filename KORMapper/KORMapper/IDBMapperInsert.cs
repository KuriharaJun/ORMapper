using System.Data.Common;

namespace KORMapper
{
    /// <summary>
    /// DBマッピングオブジェクトInsertインターフェース
    /// <para>Insert処理のマッピングをするクラスは必ずこのインターフェースを実装すること</para>
    /// </summary>
    public interface IDBMapperInsert
    {
        #region Insert処理
        /// <summary>
        /// Insert実行処理
        /// </summary>
        /// <param name="command">SQLコマンド</param>
        /// <returns>処理件数</returns>
        long Insert(DbCommand command);

        /// <summary>
        /// Insert実行処理
        /// </summary>
        /// <typeparam name="U">パラメータ型</typeparam>
        /// <param name="command">SQLコマンド</param>
        /// <param name="table">パラメータ型テーブル名</param>
        /// <param name="paramObject">パラメータオブジェクト</param>
        /// <returns>処理件数</returns>
        long Insert<U>(DbCommand command, string table, U paramObject);
        #endregion
    }
}
