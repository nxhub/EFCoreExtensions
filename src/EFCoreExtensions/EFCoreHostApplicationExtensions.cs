using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                try
                {
                    IServiceScope scope = app.ApplicationServices.CreateScope();

                    TDbContext context = scope.ServiceProvider.GetService<TDbContext>();

                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });

            return host;
        }
    }
}
