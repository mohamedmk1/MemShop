using System;
using MemShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace MemShop.API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                .ConfigureNLog("nlog.config")
                .GetCurrentClassLogger();

            try
            {
                logger.Info("Initializing application ...");
                var host = CreateHostBuilder(args)
                    .Build();

                using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<MemShopDbContext>();
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }

                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application stopped because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostingContext, logging) => {
                    logging.AddNLog(hostingContext.Configuration.GetSection("Logging"));
                });
    }
}
