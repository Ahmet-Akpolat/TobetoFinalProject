using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentMediaAccountConfiguration : IEntityTypeConfiguration<StudentMediaAccount>
{
    public void Configure(EntityTypeBuilder<StudentMediaAccount> builder)
    {
        builder.ToTable("StudentMediaAccounts").HasKey(sma => sma.Id);

        builder.Property(sma => sma.Id).HasColumnName("Id").IsRequired();
        builder.Property(sma => sma.StudentId).HasColumnName("StudentId");
        builder.Property(sma => sma.MediaAccountId).HasColumnName("MediaAccountId");
        builder.Property(sma => sma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sma => sma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sma => sma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sma => !sma.DeletedDate.HasValue);
    }
}