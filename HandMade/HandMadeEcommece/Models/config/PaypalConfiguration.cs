using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class PaypalConfiguration : IEntityTypeConfiguration<PaypalSetting>
    {
        public void Configure(EntityTypeBuilder<PaypalSetting> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x=>x.AccountId).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Status);
            builder.Property(x => x.Mode);
            builder.Property(x=>x.CountryName).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.CurrencyName).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.CurrencyRate).HasPrecision(10, 2);
            builder.Property(x => x.SecretKey).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");

            builder.HasOne(x => x.User)
                .WithMany(x => x.PaypalSettings)
                .HasForeignKey(x => x.UserId)
                .IsRequired(false);

            builder.HasOne(x=>x.DeliveryCompany)
                .WithMany(x=>x.paypalSetting)
                .HasForeignKey(x=>x.CompanyDeliveryId)
                .IsRequired(false);

            builder.HasOne(e=>e.Vendor)
                .WithMany(e=>e.paypalSettings)
                .HasForeignKey(e=>e.VendorId)
                .IsRequired(false);
        }
    }
}
