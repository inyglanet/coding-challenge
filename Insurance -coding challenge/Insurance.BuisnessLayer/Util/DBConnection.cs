using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Insurance.Entity;


namespace Insurance.BuisnessLayer.Util
{
    public class DBConnection
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection connection;
            string connectionString = "Data Source=LENOVO ;Initial Catalog= Insurance Database ; Integrated Security=True ;";
            connection = new SqlConnection();
            connectionString = connection.ConnectionString;
            connection.Open();
            return connection;
        }

        internal void Add(Policy policy)
        {
            throw new NotImplementedException();
        }

        internal Policy Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal void Remove(Policy policy)
        {
            throw new NotImplementedException();
        }
    }
}
