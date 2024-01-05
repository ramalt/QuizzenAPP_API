using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzerApp.Infrastructure.EFCore.Config;

namespace QuizzerApp.Infrastructure.EFCore.Contexts;

public class QuizzerAppContext(DbContextOptions<QuizzerAppContext> options) : IdentityDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new QuestionConfiguration());
        // builder.ApplyConfiguration(new QuestionImageConfiguration());
        builder.ApplyConfiguration(new AnswerConfiguration());
        // builder.ApplyConfiguration(new AnswerImageConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(builder);
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<User> Users { get; set; }
}
