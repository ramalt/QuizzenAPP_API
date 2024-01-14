using QuizzenApp.PhotoStock.Services;

namespace QuizzenApp.PhotoStock;

public static class Extensions
{
    public static void AddPhotoServices(this IServiceCollection services)
    {
        services.AddScoped<IPhotoService, PhotoService>();

    }
}
