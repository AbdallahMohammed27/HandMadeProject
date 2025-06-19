using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class ProductImageGalleryConfiguration : IEntityTypeConfiguration<ProductImageGallery>
    {
        public void Configure(EntityTypeBuilder<ProductImageGallery> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");
            //image

            builder.HasOne(e => e.Product)
                .WithMany(e => e.ProductImagesGallery)
                .HasForeignKey(e => e.ProductId)
                .IsRequired(false);
        }
    }
}
