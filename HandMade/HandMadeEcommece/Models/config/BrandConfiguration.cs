using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.Status).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.Slug).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            //logo
            builder.Property(e => e.UpdatedAt).HasColumnType("DATETIME");
            builder.Property(e => e.CreatedAt).HasColumnType("DATETIME");
        }
    }
}
