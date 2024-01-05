using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Infrastructure.EFCore;
using QuizzerApp.Infrastructure.Persistence;

namespace QuizzerApp.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.UseSqlServer(config);

        // services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
