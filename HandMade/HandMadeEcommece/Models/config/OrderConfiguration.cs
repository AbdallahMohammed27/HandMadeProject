using HandMadeEcommece.Models.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e=>e.Amount).HasPrecision(10,2);
            builder.Property(e => e.CreatedAt).HasColumnType("DATETIME");
            builder.Property(e => e.OrderStatus).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.CurrencyName).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e=>e.PaymentMethod).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.UpdatedAt).HasColumnType("DATETIME");
            builder.Property(e => e.OrderAddress).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            //currency icon

            builder.HasOne(e => e.DeliveryCompany)
                .WithMany(e => e.orders)
                .HasForeignKey(e => e.CompanyDeliveryId)
                .IsRequired(false);

            builder.HasOne(e => e.user)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            //builder.HasOne(e=>e.Cart)
            //    .WithOne(e=>e.Order)
            //    .HasForeignKey<Order>(e=>e.CartId)
            //    .IsRequired(false);

            builder.HasMany(e => e.product)
                .WithMany(e => e.orders)
                .UsingEntity<OrderProduct>();

            builder.HasMany(e=>e.vendor)
                .WithMany(e=>e.orders)
                .UsingEntity<OrderVendor>();
        }
    }
}
