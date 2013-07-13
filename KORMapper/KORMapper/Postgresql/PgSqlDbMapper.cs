using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper.Postgresql
{
    /// <summary>
    /// Postgresql用DBマッピングクラス
    /// <para>依存関係：Postgresql用DB接続ライブラリs</para>
    /// </summary>
    public class PgSqlDbMapper : AbstractDbMapper, IDBMapperSelect, IDBMapperUpdate,IDBMapperInsert,IDBMapperTran
    {
        public T Select<T>(string table, System.Data.Common.DbCommand command)
        {
            throw new NotImplementedException();
        }

        public List<T> SelectList<T>(string table, System.Data.Common.DbCommand command)
        {
            throw new NotImplementedException();
        }

        public T Select<T, U>(string table, System.Data.Common.DbCommand command, U paramObject)
        {
            throw new NotImplementedException();
        }

        public List<T> SelectList<T, U>(string table, System.Data.Common.DbCommand command, U paramObject)
        {
            throw new NotImplementedException();
        }

        public long Update(System.Data.Common.DbCommand command)
        {
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
    }
}
