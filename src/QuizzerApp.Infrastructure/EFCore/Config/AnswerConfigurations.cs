using System.Runtime.Intrinsics.X86;
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
        builder.HasMany(a => a.Images)
            .WithOne(ai => ai.Answer)
            .HasForeignKey(ai => ai.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.UpdatedDate).IsRequired();

    }
}

public class AnswerVoteConfigurations : IEntityTypeConfiguration<AnswerVote>
{
    public void Configure(EntityTypeBuilder<AnswerVote> builder)
    {
        //ID
        builder.HasKey(av => av.Id);

        //ANSWER
        builder.HasOne(av => av.Answer)
        .WithMany(a => a.AnswerVotes)
        .HasForeignKey(av => av.AnswerId)
        .OnDelete(DeleteBehavior.Restrict);

        //USER
        builder.HasOne(av => av.User)
               .WithMany(u => u.AnswerVotes)
               .HasForeignKey(av => av.UserId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}

public class AnswerImageConfigurations : IEntityTypeConfiguration<AnswerImage>
{
    public void Configure(EntityTypeBuilder<AnswerImage> builder)
    {
        //ID
        builder.HasKey(ai => ai.Id);

        //QUESTION
        builder.HasOne(ai => ai.Answer)
               .WithMany(q => q.Images)
               .HasForeignKey(ai => ai.AnswerId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}

