using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;

namespace HandMadeEcommece.Models.config
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionMoney>
    {
        public void Configure(EntityTypeBuilder<TransactionMoney> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e=>e.Amount).IsRequired().HasPrecision(10,2);
            builder.Property(e=>e.AmountRealCurrency).IsRequired().HasPrecision(10,2);
            builder.Property(e => e.AmountRealCurrencyName).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.PaymentMethod).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.CreatedAt).HasColumnType("DATETIME");
            builder.Property(e => e.UpdatedAt).HasColumnType("DATETIME");

            builder.HasMany(e => e.vendors)
                .WithMany(e => e.transactionMoney)
                .UsingEntity<VendorTransaction>();

            builder.HasOne(e => e.DeliveryCompany)
                .WithMany(e => e.transactionMoneys)
                .HasForeignKey(e => e.CompanyDeliveryId)
                .IsRequired(false);

            builder.HasOne(e=>e.user)
                .WithMany(e=>e.TransactionMoneys)
                .HasForeignKey(e=>e.UserId)
                .IsRequired(false);

            builder.HasOne(e=>e.DeliveryCompany)
                .WithMany(e=>e.transactionMoneys)
                .HasForeignKey(e=>e.CompanyDeliveryId)
                .IsRequired(false);
        }
    }
}
