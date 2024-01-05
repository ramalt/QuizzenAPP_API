using System.Reflection;
using QuizzerApp.Infrastructure;
using QuizzerApp.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);


// builder.Services.Configure<RequestLocalizationOptions>(options =>
// {
//     options.DefaultRequestCulture = new RequestCulture("en-US");
//     options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
//     options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") };
// });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

