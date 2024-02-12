using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistance
{
    public class DeleteAuthorService : IDeleteAuthor
    {
        private readonly string connectionString = "";

        public DeleteAuthorService(IConfiguration _configuration)
        {
            this.connectionString = _configuration.GetConnectionString("Project2") ?? throw new InvalidOperationException("Connection String 'Project2' not found");
        }

        public async Task<bool> DeleteAuthorAsync(string name)
        {
            SqlDataReader reader = null;

            using (SqlConnection _conn = new SqlConnection(connectionString))
            {
                _conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.spAuthors_GetAuthorByName", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // add parameter
                    //cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50);
                    //cmd.Parameters["@name"].Value = (name);

                    cmd.Parameters.AddWithValue("@name", name);

                    // open connection, execute command, close connection

                    reader = await cmd.ExecuteReaderAsync();
                }

                if (!reader.HasRows)
                {
                    return false;
                }
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                }
                reader.Close();
                using (SqlCommand cmd = new SqlCommand("dbo.spAuthors_DeleteAuthorByName", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // add parameter
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = (id);

                    // open connection, execute command, close connection
                    await cmd.ExecuteNonQueryAsync();
                }
                _conn.Close();
            }
            return true;
        }
    }
}