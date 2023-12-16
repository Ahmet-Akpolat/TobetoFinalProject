using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.EducationStatus).HasColumnName("EducationStatus");
        builder.Property(e => e.SchoolName).HasColumnName("SchoolName");
        builder.Property(e => e.Branch).HasColumnName("Branch");
        builder.Property(e => e.IsContinued).HasColumnName("IsContinued");
        builder.Property(e => e.StartDate).HasColumnName("StartDate");
        builder.Property(e => e.GraduationDate).HasColumnName("GraduationDate");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}