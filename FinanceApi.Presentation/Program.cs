using FinanceApi.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

try
{
    builder.RegisterServices();

    var app = builder.Build();

    app.UseEnvironment();

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        _ = endpoints.MapControllers();
    });

    app.Run();
}
catch (Exception exception)
{
    Console.WriteLine(exception);
    throw;
}