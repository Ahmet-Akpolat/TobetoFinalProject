using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MediaAccountConfiguration : IEntityTypeConfiguration<MediaAccount>
{
    public void Configure(EntityTypeBuilder<MediaAccount> builder)
    {
        builder.ToTable("MediaAccounts").HasKey(ma => ma.Id);

        builder.Property(ma => ma.Id).HasColumnName("Id").IsRequired();
        builder.Property(ma => ma.Name).HasColumnName("Name");
        builder.Property(ma => ma.MediaUrl).HasColumnName("MediaUrl");
        builder.Property(ma => ma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ma => ma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ma => ma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ma => !ma.DeletedDate.HasValue);
    }
}