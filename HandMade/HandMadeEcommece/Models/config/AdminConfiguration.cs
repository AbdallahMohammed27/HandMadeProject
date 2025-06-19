using HandMadeEcommece.Models.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(e=>e.Salary).HasPrecision(10,2).IsRequired();
            //image

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Admins)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.orders)
                .WithMany(e => e.admins)
                .UsingEntity<AdminOrder>();

            builder.HasMany(e => e.brands)
                    .WithMany(e => e.admins)
                    .UsingEntity<AdminBrand>();

            builder.HasMany(e => e.vendors)
                   .WithMany(e => e.admins)
                   .UsingEntity<AdminVendor>();

            builder.HasMany(e => e.categories)
                   .WithMany(e => e.admins)
                   .UsingEntity<AdminCategory>();

            builder.HasMany(e => e.products)
                   .WithMany(e => e.admins)
                   .UsingEntity<AdminProduct>();

            builder.HasMany(e => e.transactionMoneys)
                   .WithMany(e => e.admins)
                   .UsingEntity<AdminTransaction>();

            builder.HasMany(e => e.vendorConditions)
                   .WithMany(e => e.admins)
                   .UsingEntity<AdminVendorConditions>();
        }
    }
}
