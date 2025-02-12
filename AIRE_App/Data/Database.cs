using System.Data.Common;
using Npgsql;

namespace AIRE_App.Data
{
    public static class Database
    {
        public static DbDataSource GetDataSource()
        {
            var dataSource = NpgsqlDataSource.Create(Constants.PostgreSQLConnectionString);

            return dataSource;
        }
    }
}