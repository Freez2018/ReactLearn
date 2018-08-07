using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Data.Context;
using Data;

namespace ReactLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var serviceScope = host.Services.CreateScope())
            {
                var accountsRepository = serviceScope.ServiceProvider.GetService<UsersManagementContext>();
                ProductsDataSeeder.SeedProducts(accountsRepository);
              
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        }
    }
}
