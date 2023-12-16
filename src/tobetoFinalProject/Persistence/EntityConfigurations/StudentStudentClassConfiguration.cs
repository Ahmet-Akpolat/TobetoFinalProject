using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentStudentClassConfiguration : IEntityTypeConfiguration<StudentStudentClass>
{
    public void Configure(EntityTypeBuilder<StudentStudentClass> builder)
    {
        builder.ToTable("StudentStudentClasses").HasKey(ssc => ssc.Id);

        builder.Property(ssc => ssc.Id).HasColumnName("Id").IsRequired();
        builder.Property(ssc => ssc.StudentId).HasColumnName("StudentId");
        builder.Property(ssc => ssc.StudentClassId).HasColumnName("StudentClassId");
        builder.Property(ssc => ssc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ssc => ssc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ssc => ssc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ssc => !ssc.DeletedDate.HasValue);
    }
}