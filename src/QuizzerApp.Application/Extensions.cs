using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
