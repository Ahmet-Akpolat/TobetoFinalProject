using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LectureFavouriteConfiguration : IEntityTypeConfiguration<LectureFavourite>
{
    public void Configure(EntityTypeBuilder<LectureFavourite> builder)
    {
        builder.ToTable("LectureFavourites").HasKey(lf => lf.Id);

        builder.Property(lf => lf.Id).HasColumnName("Id").IsRequired();
        builder.Property(lf => lf.StudentId).HasColumnName("StudentId");
        builder.Property(lf => lf.LectureId).HasColumnName("LectureId");
        builder.Property(lf => lf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lf => lf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lf => lf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lf => !lf.DeletedDate.HasValue);
    }
}