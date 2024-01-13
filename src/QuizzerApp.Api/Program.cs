using System.Reflection;
using QuizzerApp.Infrastructure;
using QuizzerApp.Application;
using QuizzenApp.PhotoStock.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddScoped<IPhotoService, PhotoService>();


// builder.Services.Configure<RequestLocalizationOptions>(options =>
// {
//     options.DefaultRequestCulture = new RequestCulture("en-US");
//     options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
//     options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") };
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure metodunda


var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

