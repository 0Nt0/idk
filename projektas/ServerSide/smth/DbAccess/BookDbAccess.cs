using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace smth.DbAccess
{
    public class BookDbAccess : IBookDbAccess
    {
        private readonly IConfiguration _config;
        public BookDbAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadInfo<T, U>(string info, U need, string connect)
        {
            using IDbConnection connection = new SqlConnection(connect);
            var answ = await connection.QueryAsync<T>(info, need);
            return answ.ToList();
        }
        public async Task SaveInfo<T>(string info, T need, string connect)
        {
            using IDbConnection connection = new SqlConnection(connect);
            await  connection.ExecuteAsync(info, need);
        }

    }
}
