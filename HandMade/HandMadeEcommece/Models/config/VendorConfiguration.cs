using HandMadeEcommece.Models.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Banner).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x=>x.Description).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.FbLink).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.InstaLink).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.TwLink).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.ShopName).HasColumnType("VARCHAR").HasMaxLength(255);

            builder.HasOne(e => e.Role)
               .WithMany(e => e.Vendors)
               .HasForeignKey(e => e.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
