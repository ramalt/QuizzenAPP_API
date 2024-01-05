using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzerApp.Infrastructure.EFCore.Config;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
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
        // builder.HasMany(q => q.Images)
        //     .WithOne()
        //     .HasForeignKey(qi => qi.QuestionId)
        //     .OnDelete(DeleteBehavior.Cascade);


        builder.Property(q => q.CreatedDate).IsRequired();
        builder.Property(q => q.UpdatedDate).IsRequired();

    }

}

// public class QuestionImageConfiguration : IEntityTypeConfiguration<QuestionImage>
// {
//     public void Configure(EntityTypeBuilder<QuestionImage> builder)
//     {
//         builder.Property(qi => qi.Id)
//             .HasConversion(
//                 id => id.Value,
//                 value => new QuestionImageId(value))
//             .ValueGeneratedOnAdd()
//             .IsRequired();

//         builder.Property(qi => qi.Url)
//             .IsRequired();

//         builder.HasOne(qi => qi.Question)
//             .WithMany(q => q.Images)
//             .HasForeignKey(qi => qi.QuestionId)
//             .OnDelete(DeleteBehavior.Cascade);
//     }
// }




