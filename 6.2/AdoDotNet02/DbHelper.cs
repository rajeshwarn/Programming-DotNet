using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet02
{
    public static class DbHelper
    {
        public async static Task<T> GetOpenConnectionAsync<T>(string connectionString)
            where T : DbConnection, new()
        {
            var connection = new T();
            connection.ConnectionString = connectionString;
            await connection.OpenAsync();

            return connection;
        }

        public async static Task<DbDataReader> ExecuteReaderAsync(this DbConnection connection, string sql, IDictionary<string, object> parameters = null)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = sql;

                if (parameters == null)
                {
                    return await cmd.ExecuteReaderAsync();
                }

                foreach (var kvp in parameters)
                {
                    var parm = cmd.CreateParameter();
                    parm.ParameterName = kvp.Key;
                    parm.Value = kvp.Value;

                    cmd.Parameters.Add(parm);
                }

                return await cmd.ExecuteReaderAsync();

            }
        }

        public async static Task<T> GetAsync<T>(this DbDataReader reader, string columnName)
        {
            var ord = reader.GetOrdinal(columnName);

            return await GetAsync<T>(reader, ord);
        }

        public async static Task<T> GetAsync<T>(this DbDataReader reader, int ordinal)
        {
            if (await reader.IsDBNullAsync(ordinal))
            {
                return default(T);
            }

            return (T)reader[ordinal];
        }
    }
}
