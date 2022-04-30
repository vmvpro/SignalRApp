using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SignalRServer.Models.DB
{
    public static class DapperExtensions
    {
        public static async Task<IEnumerable<T>> Query<T>(this IDbConnection connection, string sql, Func<T> typeBuilder)
        {
            return await connection.QueryAsync<T>(sql);
        }

        public static async Task<IEnumerable<T>> Query<T>(this IDbConnection connection, string sql, object param, Func<T> typeObject)
        {
            return await connection.QueryAsync<T>(sql, param);
        }
    }
}
