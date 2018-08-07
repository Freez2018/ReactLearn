using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Data.Context;

namespace Data
{
    public static class Startup
    {
        public static void AddProductsService(this IServiceCollection services, ProductsServiceSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            if (string.IsNullOrEmpty(settings.DatabaseConnectionString))
            {
                throw new Exception("Database connection string for AccountsService is empty.");
            }

            services.AddDbContext<UsersManagementContext>(options => options.UseSqlServer(settings.DatabaseConnectionString));
             //   services.AddDbContext<UsersManagementContext>(options => options.UseSqlServer(@"Server=IS-WKS107;Database=Epsilon;Trusted_Connection=True;"));//temp
            services.AddTransient<IMatchService, MatchService>();
        }
    }
}
