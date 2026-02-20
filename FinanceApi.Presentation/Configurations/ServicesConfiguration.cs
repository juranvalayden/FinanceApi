using FinanceApi.Application;
using FinanceApi.Infrastructure;

namespace FinanceApi.Presentation.Configurations;

public static class ServicesConfiguration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();

        builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
            .AddNewtonsoftJson()
            .AddXmlDataContractSerializerFormatters();

        builder.Services.AddProblemDetails();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
    }
}
