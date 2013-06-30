using System.Data.Common;

namespace KORMapper
{
    /// <summary>
    /// DBマッピングオブジェクトUpdateインターフェース
    /// <para>Update処理のマッピングをするクラスは必ずこのインターフェースを実装すること</para>
    /// </summary>
    public interface IDBMapperUpdate
    {
        #region Update処理
        /// <summary>
        /// Update実行処理
        /// </summary>
        /// <param name="command">SQLコマンド</param>
        /// <returns>処理件数</returns>
        long Update(DbCommand command);

        /// <summary>
        /// Update実行処理
        /// </summary>
        /// <typeparam name="U">パラメータ型</typeparam>
        /// <param name="command">SQLコマンド</param>
        /// <param name="table">パラメータ型テーブル名</param>
        /// <param name="paramObject">パラメータオブジェクト</param>
        /// <returns>処理件数</returns>
        long Update<U>(DbCommand command, string table, U paramObject);
        #endregion
    }
}
