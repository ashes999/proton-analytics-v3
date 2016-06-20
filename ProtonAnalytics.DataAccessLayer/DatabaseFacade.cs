using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace ProtonAnalytics.DataAccessLayer
{
    class DatabaseFacade
    {
        private string connectionString;

        public DatabaseFacade()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public DatabaseFacade(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Invalid (empty) connection string");
            }

            this.connectionString = connectionString;
        }

        public T ExecuteScalar<T>(string query, object parameters = null)
        {
            return this.ExecuteQuery<T>(query, parameters).Single();
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                return connection.Query<T>(query, parameters);
            }
        }
    }
}
