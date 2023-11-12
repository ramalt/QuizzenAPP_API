using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.EFCore;

public static class Extensions
{
    public static void UseSqlServer(this IServiceCollection services, IConfiguration config)
    {
        var sqlServerOptions = config.GetSection("SqlServer");
        services.AddDbContext<QuizzerAppContext>(context => context.UseSqlServer(sqlServerOptions["ConnectionString"]));
    }
}
