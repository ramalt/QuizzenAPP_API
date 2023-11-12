using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizzerApp.Infrastructure.EFCore.Models;

namespace QuizzerApp.Infrastructure.EFCore.Config;

public class QuestionConfiguration : IEntityTypeConfiguration<QuestionModel>
{
    public void Configure(EntityTypeBuilder<QuestionModel> builder)
    {
        builder.ToTable("Questions");
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Title).IsRequired();
        builder.Property(q => q.Description).IsRequired();
        builder.Property(q => q.Status).IsRequired();

        builder.HasOne(q => q.Exam)
            .WithMany(e => e.Questions)
            .HasForeignKey(q => q.ExamId);

        builder.HasOne(q => q.User)
            .WithMany(u => u.Questions)
            .HasForeignKey(q => q.UserId);
        
        builder.HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

    }

}

public class AnswerConfiguration : IEntityTypeConfiguration<AnswerModel>
{
    public void Configure(EntityTypeBuilder<AnswerModel> builder)
    {
        builder.ToTable("Answers");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Text).IsRequired();
                builder.Property(a => a.Status)
               .HasConversion<string>()
               .IsRequired();

        builder.HasOne(a => a.User)
            .WithMany(u => u.Answers)
            .HasForeignKey(a => a.UserId);

        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId);

        builder.HasMany(a => a.Images)
            .WithOne()
            .HasForeignKey(ai => ai.AnswerId);

    }
}

public class AnswerImageModelConfiguration : IEntityTypeConfiguration<AnswerImageModel>
{
    public void Configure(EntityTypeBuilder<AnswerImageModel> builder)
    {
        // builder.HasKey(ai => ai.Id);
        // builder.Property(ai => ai.Url).IsRequired();

        builder.Property(ai => ai.Url)
        .IsRequired();
    }
}

public class ExamModelConfiguration : IEntityTypeConfiguration<ExamModel>
{
    public void Configure(EntityTypeBuilder<ExamModel> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();

        builder.HasMany(e => e.Topics)
            .WithOne()
            .HasForeignKey(et => et.ExamId);

        builder.HasMany(e => e.Questions)
       .WithOne(q => q.Exam)
       .HasForeignKey(q => q.ExamId);

    }
}

public class ExamTopicModelConfiguration : IEntityTypeConfiguration<ExamTopicModel>
{
    public void Configure(EntityTypeBuilder<ExamTopicModel> builder)
    {
          builder.HasOne(et => et.Exam)
               .WithMany(e => e.Topics)
               .HasForeignKey(et => et.ExamId)
               .IsRequired();
    }
}


public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(u => u.Id);

        builder.OwnsOne(u => u.ProfilePic);

        builder.HasMany(u => u.Questions)
            .WithOne(q => q.User)
            .HasForeignKey(q => q.UserId);

        builder.HasMany(u => u.Answers)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
    }
}

