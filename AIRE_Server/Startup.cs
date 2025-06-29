using AIRE_Server.Data;
using AIRE_Server.Services;

namespace AIRE_Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Constants.PostgreSQLConnectionString = Configuration.GetConnectionString("PostgreSQL");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Learn more about configuring Swagger/OpenAPI at
            // https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();

            services.AddScoped<PostgreSQLService>((_) => new PostgreSQLService(Constants.PostgreSQLConnectionString));

            // https://github.com/modelcontextprotocol/csharp-sdk/tree/main/src/ModelContextProtocol.AspNetCore
            services.AddMcpServer()
                .WithHttpTransport()
                .WithToolsFromAssembly();
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapMcp();
            app.MapControllers();
        }
    }
}
