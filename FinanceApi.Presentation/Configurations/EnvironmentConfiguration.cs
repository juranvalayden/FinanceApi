using Scalar.AspNetCore;

namespace FinanceApi.Presentation.Configurations;

public static class EnvironmentConfiguration
{
    public static void UseEnvironment(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.MapScalarApiReference(options =>
            {
                options
                    .WithTitle("Finance API")
                    .WithTheme(ScalarTheme.DeepSpace)
                    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
            });
        }
        else
        {
            app.UseExceptionHandler();
        }
    }
}
