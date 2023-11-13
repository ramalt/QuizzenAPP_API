using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Infrastructure.EFCore.Config;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");
        
        // ID
        builder.Property(q => q.Id)
            .HasConversion(
                id => id.Value,
                value => new QuestionId(value))
            .IsRequired();
        
        //TITLE
        builder.Property(q => q.Title)
            .HasConversion(qt => qt.Value, value => new QuestionTitle(value))
            .IsRequired();

        // DESCRIPTIOM

        builder.Property(q => q.Description)
            .HasConversion(qd => qd.Value, value => new QuestionDescription(value))
            .IsRequired();

        // STATUS
        builder.Property(q => q.Status)
               .HasConversion<string>()
               .IsRequired();

        // var examConvertion = new ValueConverter<Exam, string>(x => x.ToString(), x => Exam.Create(x));

        // EXAM
        builder.Property(q => q.Exam)
            .HasConversion(e => e.ToString(), value => Exam.Create(value))
            .IsRequired();

        // USER
        builder.HasOne(q => q.User)
            .WithMany(u => u.Questions)
            .HasForeignKey(q => q.UserId)
            .IsRequired();
        
        // ANSWERS
        builder.HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // IMAGES
        builder.HasMany(q => q.Images)
            .WithOne()
            .HasForeignKey(qi => qi.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
            

        builder.Property(q => q.CreatedDate).IsRequired();
        builder.Property(q => q.UpdatedDate).IsRequired();

    }

}

public class QuestionImageConfiguration : IEntityTypeConfiguration<QuestionImage>
{
    public void Configure(EntityTypeBuilder<QuestionImage> builder)
    {
        // builder.HasKey(qi => qi.Id);
        builder.Property(qi => qi.Id)
            .HasConversion(
                id => id.Value,
                value => new QuestionImageId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(qi => qi.Url)
            .IsRequired();

        builder.HasOne(qi => qi.Question)
            .WithMany(q => q.Images)
            .HasForeignKey(qi => qi.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");

        // ID
        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Value,
                value => new AnswerId(value))
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        // ANSWER TEXT
        builder.Property(a => a.Text)
            .HasConversion(at => at.Value, value => new AnswerText(value))
            .IsRequired();

        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.UpdatedDate).IsRequired();

        builder.Property(a => a.Status)
               .HasConversion<string>()
               .IsRequired();

        builder.HasOne(a => a.User)
            .WithMany(a => a.Answers)
            .HasForeignKey(a => a.UserId)
            .IsRequired();

        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasMany(a => a.Images)
            .WithOne(ai => ai.Answer)
            .HasForeignKey(ai => ai.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

public class AnswerImageConfiguration : IEntityTypeConfiguration<AnswerImage>
{
    public void Configure(EntityTypeBuilder<AnswerImage> builder)
    {
        builder.Property(ai => ai.Id)
            .HasConversion(
                id => id.Value,
                value => new AnswerImageId(value))
            .IsRequired();

        builder.Property(ai => ai.Url)
        .IsRequired();

         builder.HasOne(ai => ai.Answer)
            .WithMany(a => a.Images)
            .HasForeignKey(ai => ai.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("varchar(255)"); 

        builder.OwnsOne(u => u.ProfilePic);

        builder.HasMany(u => u.Questions)
            .WithOne(q => q.User)
            .HasForeignKey(q => q.UserId);

        builder.HasMany(u => u.Answers)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
    }
}

