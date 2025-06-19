using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class ProductReviewGalleryConfiguration : IEntityTypeConfiguration<ProductReviewGallery>
    {
        public void Configure(EntityTypeBuilder<ProductReviewGallery> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            //image
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");

            builder.HasOne(e => e.ProductReview)
                .WithMany(e => e.ImageGallery)
                .HasForeignKey(e => e.ProductReviewId)
                .IsRequired(false);
        }
    }
}
