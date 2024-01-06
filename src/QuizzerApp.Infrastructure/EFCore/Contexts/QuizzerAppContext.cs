using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzerApp.Infrastructure.EFCore.Config;

namespace QuizzerApp.Infrastructure.EFCore.Contexts;

public class QuizzerAppContext(DbContextOptions<QuizzerAppContext> options) : IdentityDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new QuestionConfiguration());
        builder.ApplyConfiguration(new AnswerConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new ExamConfigurations());
        builder.ApplyConfiguration(new SubjectConfigurations());
        builder.ApplyConfiguration(new TopicConfigurations());

        // builder.ApplyConfiguration(new QuestionImageConfiguration());
        // builder.ApplyConfiguration(new AnswerImageConfiguration());

        base.OnModelCreating(builder);
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Topic> Topics { get; set; }
}
