using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KORMapper;

namespace TestApp
{
    public class ClsDataDao : IDisposable
    {
        /// <summary>
        /// 検索コマンド
        /// </summary>
        private SqlCommand command = null;

        private SqlConnection con = null;

        private ClsDataMapper mapper = new ClsDataMapper();

        public ClsDataDao()
        {
            SqlConnectionStringBuilder sqbuilder = new SqlConnectionStringBuilder();
            sqbuilder.DataSource = "(local)";
            sqbuilder.InitialCatalog = "AdventureWorksDW2008R2";
            sqbuilder.PersistSecurityInfo = true;
            sqbuilder.IntegratedSecurity = true;
            con = new SqlConnection(sqbuilder.ConnectionString);
            string sql = "SELECT TOP 100 [FirstName] + ' ' + ISNULL([MiddleName],'') + ' ' + [LastName] as Name ,[AddressLine1] + ISNULL([AddressLine2], '') as Address FROM [DimCustomer]";
            command = new SqlCommand(sql, con);
        }

        /// <summary>
        /// 顧客情報取得
        /// </summary>
        /// <returns></returns>
        public List<Model> ExecuteCustomer()
        {
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable("customer");

            da.Fill(dt);

            var list = mapper.GetDataToObject<Model>(dt);

            return list;
            
        }

        #region IDisposable メンバ

        public void Dispose()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }

        #endregion
    }
}
