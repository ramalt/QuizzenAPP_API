using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizzenApp.Domain.Entities.ExamAggregate;

namespace QuizzerApp.Infrastructure.EFCore.Config;

public class ExamConfigurations : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        // ID
        builder.HasKey(e => e.Id);

        //NAME
        builder.Property(e => e.Name)
               .IsRequired();
    }
}

public class SubjectConfigurations : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        //ID
        builder.HasKey(s => s.Id);

        //NAME
        builder.Property(s => s.Name).IsRequired();

        //EXAM
        builder.HasOne(s => s.Exam)
               .WithMany(e => e.Subjects)
               .HasForeignKey(s => s.ExamId)
               .OnDelete(DeleteBehavior.Restrict);

        //TOPIC
        builder.HasMany(s => s.Topics)
               .WithOne(t => t.Subject)
               .HasForeignKey(t => t.SubjectId);

        //QUESTION
        builder.HasMany(s => s.Questions)
               .WithOne(q => q.Subject)
               .HasForeignKey(q => q.SubjectId);
    }
}

public class TopicConfigurations : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        //ID
        builder.HasKey(t => t.Id);

        //NAME
        builder.Property(t => t.Name).IsRequired();

        //EXAM
        builder.HasOne(t => t.Exam)
               .WithMany(e => e.Topics)
               .HasForeignKey(t => t.ExamId)
               .OnDelete(DeleteBehavior.Restrict);

        //SUBJECT
        builder.HasOne(t => t.Subject)
               .WithMany(s => s.Topics)
               .HasForeignKey(t => t.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);

        //QUESTION
        builder.HasMany(t => t.Questions)
               .WithOne(q => q.Topic)
               .HasForeignKey(q => q.TopicId);
    }
}
