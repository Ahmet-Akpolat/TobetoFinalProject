using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentExperienceConfiguration : IEntityTypeConfiguration<StudentExperience>
{
    public void Configure(EntityTypeBuilder<StudentExperience> builder)
    {
        builder.ToTable("StudentExperiences").HasKey(se => se.Id);

        builder.Property(se => se.Id).HasColumnName("Id").IsRequired();
        builder.Property(se => se.StudentId).HasColumnName("StudentId");
        builder.Property(se => se.ExperienceId).HasColumnName("ExperienceId");
        builder.Property(se => se.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(se => se.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(se => se.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(se => !se.DeletedDate.HasValue);
    }
}