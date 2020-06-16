using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public static class EFCoreHostApplicationExtensions
    {
        public static IHostApplicationLifetime TryMigrateDb<TDbContext>(
            this IHostApplicationLifetime host,
            IApplicationBuilder app)
            where TDbContext : DbContext
        {
            host.ApplicationStarted.Register(() =>
            {
                using IServiceScope scope = app.ApplicationServices.CreateScope();

                try
                {
                    using TDbContext context = scope.ServiceProvider.GetService<TDbContext>();

                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    ILogger logger = scope.ServiceProvider.GetService<ILogger>();

                    logger?.LogWarning(ex, ex.Message);
                }
            });

            return host;
        }
    }
}
