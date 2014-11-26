using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet02
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private async static Task DoQueryAsync()
        {
            using (var connection = await DbHelper.GetOpenConnectionAsync<SqlConnection>("asdf"))
            {
                var sql = "SELECT Email, Age, Name FROM Foo WHERE ID = @id";
                var parms = new Dictionary<string, object> {
                    {"@id", 1}
                };

                using (var reader = await connection.ExecuteReaderAsync(sql, parms))
                {
                    while (reader.Read())
                    {
                        var name = reader.GetAsync<string>("Name");
                        var email = reader.GetAsync<string>("Email");
                        var age = reader.GetAsync<int?>("Age");
                    }
                }
            }
        }
    }
}
