using Microsoft.EntityFrameworkCore;

namespace QuotesPlayback_NET
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Попытка получить переменные из окружения Render
            var host = Environment.GetEnvironmentVariable("RENDER_POSTGRES_HOST");
            var port = Environment.GetEnvironmentVariable("RENDER_POSTGRES_PORT");
            var db = Environment.GetEnvironmentVariable("RENDER_POSTGRES_DB");
            var user = Environment.GetEnvironmentVariable("RENDER_POSTGRES_USERNAME");
            var password = Environment.GetEnvironmentVariable("RENDER_POSTGRES_PASSWORD");

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(port) &&
                !string.IsNullOrEmpty(db) && !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
            {
                connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password};SSL Mode=Require";
            }

            serviceCollection.AddDbContext<QuoteContext>(options => options.UseNpgsql(connectionString));
            return serviceCollection;
        }
    }
}
