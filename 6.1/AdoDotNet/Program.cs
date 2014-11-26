using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "asdf";
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Email, Name FROM Foo WHERE ID = @id";

                    var idParm = cmd.CreateParameter();
                    idParm.ParameterName = "@id";
                    idParm.Value = 1;

                    cmd.Parameters.Add(idParm);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var ordName = reader.GetOrdinal("Name");
                        var ordEmail = reader.GetOrdinal("Email");

                        while (reader.Read())
                        {
                            var name = reader.GetString(ordName);
                            var email = reader.GetString(ordEmail);
                        }
                    }
                }
            }
        }
    }
}
