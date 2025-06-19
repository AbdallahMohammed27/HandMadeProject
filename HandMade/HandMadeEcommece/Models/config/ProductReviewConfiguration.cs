using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Review).HasColumnType("VARCHAR").IsRequired().HasMaxLength(255);
            builder.Property(e=>e.Rating).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(e => e.Status);
            builder.Property(e => e.CreatedAt).HasColumnType("DATETIME");
            builder.Property(e => e.UpdatedAt).HasColumnType("DATETIME");

            builder.HasOne(e => e.User)
                .WithMany(e => e.ProductReviews)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            builder.HasOne(e=>e.Product)
                .WithMany(e=>e.ProductReviews)
                .HasForeignKey(e => e.ProductId)
                .IsRequired(false);  
        }
    }
}
