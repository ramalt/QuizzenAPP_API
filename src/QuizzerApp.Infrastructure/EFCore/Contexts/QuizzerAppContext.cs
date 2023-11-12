using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizzerApp.Infrastructure.EFCore.Config;
using QuizzerApp.Infrastructure.EFCore.Models;

namespace QuizzerApp.Infrastructure.EFCore.Contexts;

public class QuizzerAppContext(DbContextOptions<QuizzerAppContext> options) : IdentityDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new QuestionConfiguration());
        builder.ApplyConfiguration(new AnswerConfiguration());
        builder.ApplyConfiguration(new AnswerImageModelConfiguration());
        builder.ApplyConfiguration(new ExamModelConfiguration());
        builder.ApplyConfiguration(new ExamTopicModelConfiguration());
        builder.ApplyConfiguration(new UserModelConfiguration());

        base.OnModelCreating(builder);
    }

    public DbSet<QuestionModel> Questions { get; set; }
    public DbSet<AnswerModel> Answers { get; set; }
    public DbSet<ExamModel> Exams { get; set; }
    public DbSet<UserModel> Users { get; set; }
}
