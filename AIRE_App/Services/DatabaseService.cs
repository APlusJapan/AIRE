using System.Data.Common;
using AIRE_DB.Models;
using AIRE_App.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AIRE_App.Services;

public static class DatabaseService
{
    public static DbDataSource GetDataSource()
    {
        var dataSource = NpgsqlDataSource.Create(Constants.PostgreSQLConnectionString);

        return dataSource;
    }

    public static AireDbContext GetAireDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<AireDbContext>()
            .UseNpgsql(Constants.PostgreSQLConnectionString).Options;

        return new AireDbContext(dbContextOptions);
    }

    public static AireDbContext GetAireDbContext(Action<String> action)
    {
        var dbContextOptions = new DbContextOptionsBuilder<AireDbContext>()
            .UseNpgsql(Constants.PostgreSQLConnectionString)
            .LogTo(action).Options;

        return new AireDbContext(dbContextOptions);
    }
}