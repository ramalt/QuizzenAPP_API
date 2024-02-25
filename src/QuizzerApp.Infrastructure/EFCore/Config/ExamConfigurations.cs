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

        builder.HasData(
              new Exam(new Guid("d8616b29-3b00-4f92-b160-df287298e9f7"), "EXAM1"),
              new Exam(new Guid("1442a173-834c-4a22-a2e3-d84d4bf3a05e"), "EXAM2"));
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

        builder.HasData(
                     new Subject(new Guid("e4993243-e075-41a3-9895-e824fbdceee9"), "subject-1", new Guid("d8616b29-3b00-4f92-b160-df287298e9f7")),
                     new Subject(new Guid("c6fc0003-e85f-4cf9-9801-c76b0cf41d7e"), "subject-2", new Guid("d8616b29-3b00-4f92-b160-df287298e9f7")),
                     new Subject(new Guid("0fb1d6f3-24ff-4b0c-8689-4472cc91f1ae"), "subject-3", new Guid("1442a173-834c-4a22-a2e3-d84d4bf3a05e")),
                     new Subject(new Guid("59be79c3-609b-4a04-a9a2-09bf7ee875f6"), "subject-4", new Guid("1442a173-834c-4a22-a2e3-d84d4bf3a05e")));
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


        builder.HasData(
             new Topic(new Guid("c85a592b-051c-452a-933d-bef85bf5c57b"), "topic1", new Guid("d8616b29-3b00-4f92-b160-df287298e9f7"), new Guid("e4993243-e075-41a3-9895-e824fbdceee9")),
             new Topic(new Guid("6ee4cc99-78e5-453b-b859-4f7284348f91"), "topic2", new Guid("d8616b29-3b00-4f92-b160-df287298e9f7"), new Guid("c6fc0003-e85f-4cf9-9801-c76b0cf41d7e")),
             new Topic(new Guid("745fe52f-f0f9-4140-b2eb-668b7f84a604"), "topic3", new Guid("1442a173-834c-4a22-a2e3-d84d4bf3a05e"), new Guid("0fb1d6f3-24ff-4b0c-8689-4472cc91f1ae")),
             new Topic(new Guid("98047d28-11a7-46a7-96ff-4171061af613"), "topic4", new Guid("1442a173-834c-4a22-a2e3-d84d4bf3a05e"), new Guid("59be79c3-609b-4a04-a9a2-09bf7ee875f6"))
         );


    }
}
