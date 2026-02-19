using FinanceApi.Application.Interfaces;
using FinanceApi.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();

        serviceCollection.AddAutoMapper(cfg => { cfg.AddMaps(assembliesToScan); });

        serviceCollection.AddScoped<ISalesOrderService, SalesOrderService>();
    }
}
