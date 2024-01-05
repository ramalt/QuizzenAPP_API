using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

namespace QuizzerApp.Infrastructure.EFCore.Config;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
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

        // STATUS
        builder.Property(a => a.Status)
               .HasConversion<string>()
               .IsRequired();

        // USER
        builder.HasOne(a => a.User)
            .WithMany(a => a.Answers)
            .HasForeignKey(a => a.UserId)
            .IsRequired();

        // QUESTION
        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        // IMAGES
        // builder.HasMany(a => a.Images)
        //     .WithOne(ai => ai.Answer)
        //     .HasForeignKey(ai => ai.AnswerId)
        //     .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.UpdatedDate).IsRequired();

    }
}

// public class AnswerImageConfiguration : IEntityTypeConfiguration<AnswerImage>
// {
//     public void Configure(EntityTypeBuilder<AnswerImage> builder)
//     {
//         builder.Property(ai => ai.Id)
//             .HasConversion(
//                 id => id.Value,
//                 value => new AnswerImageId(value))
//             .IsRequired();

//         builder.Property(ai => ai.Url)
//         .IsRequired();

//         builder.HasOne(ai => ai.Answer)
//            .WithMany(a => a.Images)
//            .HasForeignKey(ai => ai.AnswerId)
//            .OnDelete(DeleteBehavior.Cascade);
//     }
// }
