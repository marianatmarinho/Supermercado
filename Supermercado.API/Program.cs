using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Supermercado.API.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace Supermercado.API
{
    public class Program
    {
      /*  public static void Main(string[] args)
        {
           // CreateHostBuilder(args).Build().Run();

           var host = CreateHostBuilder(args);
           using (var scope = host.Build().Services.CreateScope())
           using(var context = scope.ServiceProvider.GetService<AppDbContext>())
           {
               context.Database.EnsureCreated();
           }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });*/

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using(var scope = host.Services.CreateScope())
            using(var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }
            host.Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
