using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KORMapper.SqlServer
{
    /// <summary>
    /// SQLServer用DBマッピングクラス
    /// <para>依存関係：SQLServerアクセスライブラリ</para>
    /// </summary>
    public class SqlServerDbMapper : AbstractDbMapper, IDBMapperSelect, IDBMapperUpdate, IDBMapperInsert, IDBMapperTran
    {
        public T Select<T>(string table, System.Data.Common.DbCommand command)
        {
            var sqlCommand = this.CastCommand(command);

            var da = new SqlDataAdapter(sqlCommand);

            var dt = new DataTable(table);

            int row = da.Fill(dt);

            T result = default(T);

            if (row > 0)
            {
                // マッピング処理
            }

            return result;
        }

        public List<T> SelectList<T>(string table, System.Data.Common.DbCommand command)
        {
            var sqlCommand = this.CastCommand(command);

            var da = new SqlDataAdapter(sqlCommand);

            var dt = new DataTable(table);

            var row = da.Fill(dt);

            List<T> resultList = null;

            if (row > 0)
            {
                // マッピング処理
            }

            return resultList;
        }

        public T Select<T, U>(string table, System.Data.Common.DbCommand command, U paramObject)
        {
            var sqlCommand = this.CastCommand(command);

            // パラメータ設定

            var da = new SqlDataAdapter(sqlCommand);

            var dt = new DataTable(table);

            var row = da.Fill(dt);

            T result = default(T);

            if (row > 0)
            {
                // マッピング処理
            }

            return result;
        }

        public List<T> SelectList<T, U>(string table, System.Data.Common.DbCommand command, U paramObject)
        {
            var sqlCommand = this.CastCommand(command);

            // パラメータ設定

            var da = new SqlDataAdapter(sqlCommand);

            var dt = new DataTable(table);

            var row = da.Fill(dt);

            List<T> resultList = null;

            if (row > 0)
            {
                // マッピング処理
            }

            return resultList;
        }

        public long Update(System.Data.Common.DbCommand command)
        {
            var sqlCommand = this.CastCommand(command);

            if (sqlCommand.Connection.State != ConnectionState.Open)
            {
                sqlCommand.Connection.Open();
            }



            throw new NotImplementedException();
        }

        public long Update<U>(System.Data.Common.DbCommand command, string table, U paramObject)
        {
            throw new NotImplementedException();
        }

        public long Insert(System.Data.Common.DbCommand command)
        {
            throw new NotImplementedException();
        }

        public long Insert<U>(System.Data.Common.DbCommand command, string table, U paramObject)
        {
            throw new NotImplementedException();
        }

        public void Transaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得したコマンドをSqlCommandにキャストして返却する
        /// </summary>
        /// <param name="command">仮引数:command(Type:DbCommand)</param>
        /// <returns>仮引数commandをキャストしたオブジェクト</returns>
        private SqlCommand CastCommand(DbCommand command)
        {
            var sqlCommand = command as SqlCommand;

            if (sqlCommand == null)
            {
                throw new ArgumentException("command is not SqlCommand.");
            }

            return sqlCommand;
        }
    }
}
