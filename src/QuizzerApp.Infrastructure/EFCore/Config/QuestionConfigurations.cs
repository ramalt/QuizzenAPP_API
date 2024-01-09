using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        builder.HasOne(q => q.Exam)
               .WithMany(e => e.Questions)
               .HasForeignKey(q => q.ExamId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

        // SUBJECAT
        builder.HasOne(q => q.Subject)
               .WithMany(s => s.Questions)
               .HasForeignKey(q => q.SubjectId)
               .IsRequired();

        //TOPIC
        builder.HasOne(q => q.Topic)
               .WithMany(t => t.Questions)
               .HasForeignKey(q => q.TopicId)
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

public class QuestionVoteConfiguration : IEntityTypeConfiguration<QuestionVote>
{
    public void Configure(EntityTypeBuilder<QuestionVote> builder)
    {
        //ID
        builder.HasKey(qv => qv.Id);

        //QUESTION
        builder.HasOne(qv => qv.Question)
               .WithMany(q => q.QuestionVotes)
               .HasForeignKey(qv => qv.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);

        //USER
        builder.HasOne(qv => qv.User)
               .WithMany(u => u.QuestionVotes)
               .HasForeignKey(qv => qv.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}




