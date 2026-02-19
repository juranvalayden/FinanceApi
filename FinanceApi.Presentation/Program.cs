using FinanceApi.Application;
using FinanceApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


try
{
    // Add services to the container.
    builder.Services.AddControllers(options =>
        {
            options.ReturnHttpNotAcceptable = true;
        })
        .AddNewtonsoftJson()
        .AddXmlDataContractSerializerFormatters();

    builder.Services.AddProblemDetails();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        _ = endpoints.MapControllers();
    });

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}