using System.Collections.Generic;
using System.Data.Common;

namespace KORMapper
{
    /// <summary>
    /// DBマッピングオブジェクトSelectインターフェース
    /// <para>Select処理のマッピングをするクラスは必ずこのインターフェースを実装すること</para>
    /// </summary>
    public interface IDBMapperSelect
    {
        #region Select処理
        /// <summary>
        /// 単一行を返却するSelect実行処理
        /// </summary>
        /// <typeparam name="T">戻り値型</typeparam>
        /// <param name="table">戻り値型設定テーブル名</param>
        /// <param name="command">SQLコマンド</param>
        /// <returns>Select文実行結果</returns>
        T Select<T>(string table, DbCommand command);

        /// <summary>
        /// 複数行を返却するSelect実行処理
        /// </summary>
        /// <typeparam name="T">戻り値要素型</typeparam>
        /// <param name="table">戻り値設定テーブル名</param>
        /// <param name="command">SQLコマンド</param>
        /// <returns>Select文実行結果</returns>
        List<T> SelectList<T>(string table, DbCommand command);

        /// <summary>
        /// 単一行を返却するSelect実行処理（パラメータあり）
        /// </summary>
        /// <typeparam name="T">戻り値型</typeparam>
        /// <typeparam name="U">パラメータ型</typeparam>
        /// <param name="table">戻り値型設定テーブル名</param>
        /// <param name="command">SQLコマンド</param>
        /// <param name="paramObject">パラメータオブジェクト</param>
        /// <returns>Select文実行結果</returns>
        T Select<T, U>(string table, DbCommand command, U paramObject);

        /// <summary>
        /// 複数行を返却するSelect実行処理（パラメータあり）
        /// </summary>
        /// <typeparam name="T">戻り値型</typeparam>
        /// <typeparam name="U">パラメータ型</typeparam>
        /// <param name="table">戻り値型設定テーブル名</param>
        /// <param name="command">SQLコマンド</param>
        /// <param name="paramObject">パラメータオブジェクト</param>
        /// <returns>Select文実行結果</returns>
        List<T> SelectList<T, U>(string table, DbCommand command, U paramObject);
        #endregion
    }
}
