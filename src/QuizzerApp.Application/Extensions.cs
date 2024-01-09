using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Utils;

namespace QuizzerApp.Application;

public static class Extensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        services.AddScoped<TokenProvider>();
    }
}
