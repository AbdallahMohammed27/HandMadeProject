using HandMadeEcommece.Models.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Slug).HasColumnType("VARCHAR").HasMaxLength(255);
            //image
            builder.Property(x => x.Qty).IsRequired();
            builder.Property(x=>x.ShortDescription).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.LongDescription).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            //video
            builder.Property(x => x.Price).HasPrecision(10, 2);
            builder.Property(x => x.OfferPrice).HasPrecision(10, 2);
            builder.Property(x => x.Sku).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.OfferStartDate).HasColumnType("DATETIME");
            builder.Property(x => x.OfferEndDate).HasColumnType("DATETIME");
            builder.Property(x => x.ProductType).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x=>x.IsApproved);
            builder.Property(x=>x.SeoDescription).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.SeoTitle).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);

            builder.HasOne(e => e.Brand)
               .WithMany(e => e.products)
               .HasForeignKey(e => e.BrandId)
               .IsRequired(false);

            builder.HasOne(e => e.Coupon)
               .WithMany(e => e.products)
               .HasForeignKey(e => e.CouponId)
               .IsRequired(false);

            builder.HasOne(e=>e.Vendor)
                .WithMany(e=>e.products)
                .HasForeignKey(e=>e.VendorId)
                .IsRequired(false);
        }
    }
}
