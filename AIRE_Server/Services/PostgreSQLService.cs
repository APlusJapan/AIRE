using System.Data.Common;
using AIRE_DB.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AIRE_Server.Services;

public class PostgreSQLService
{
    private readonly String connectionString;

    public PostgreSQLService(String connectionString)
    {
        this.connectionString = connectionString;
    }

    public DbDataSource GetDataSource()
    {
        var dataSource = NpgsqlDataSource.Create(connectionString);

        return dataSource;
    }

    public AireDbContext GetAireDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<AireDbContext>()
            .UseNpgsql(connectionString).Options;

        return new AireDbContext(dbContextOptions);
    }

    public AireDbContext GetAireDbContext(Action<String> action)
    {
        var dbContextOptions = new DbContextOptionsBuilder<AireDbContext>()
            .UseNpgsql(connectionString)
            .LogTo(action).Options;

        return new AireDbContext(dbContextOptions);
    }
}