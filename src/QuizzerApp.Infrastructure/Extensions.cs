using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizzerApp.Infrastructure.EFCore;

namespace QuizzerApp.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.UseSqlServer(config);
        // services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.ConfigureIdentity();

    }
}
