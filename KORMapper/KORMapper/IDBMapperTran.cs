namespace KORMapper
{
    /// <summary>
    /// DBマッピングオブジェクトTransactionインターフェース
    /// <para>Transaction処理のマッピングをするクラスは必ずこのインターフェースを実装すること</para>
    /// </summary>
    public interface IDBMapperTran
    {
        #region Transaction処理
        /// <summary>
        /// トランザクション開始処理
        /// </summary>
        void Transaction();

        /// <summary>
        /// コミット処理
        /// </summary>
        void Commit();

        /// <summary>
        /// ロールバック処理
        /// </summary>
        void Rollback();
        #endregion
    }
}
