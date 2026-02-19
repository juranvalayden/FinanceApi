using FinanceApi.Domain.Repositories;
using FinanceApi.Infrastructure.DbContexts;
using FinanceApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AdventureWorksDbContext>(o =>
        {
            var connectionString = configuration["ConnectionStrings:AdventureWorksConnectionString"];
            o.UseSqlServer(connectionString);
        });

        serviceCollection.AddTransient<ISalesOrderRepository, SalesOrderRepository>();
    }
}
