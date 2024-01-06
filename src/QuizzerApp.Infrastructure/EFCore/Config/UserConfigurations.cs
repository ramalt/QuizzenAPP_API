using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Infrastructure.EFCore.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //ID
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("varchar(255)");

        // builder.OwnsOne(u => u.ProfilePic);

        // FIRSTNAME & LASTNAME
        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.LastName).IsRequired();
    

        // QUESTIONS
        builder.HasMany(u => u.Questions)
            .WithOne(q => q.User)
            .HasForeignKey(q => q.UserId);

        // ANSWERS
        builder.HasMany(u => u.Answers)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);


    }
}