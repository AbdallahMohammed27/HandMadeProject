//using HandMadeEcommece.Models.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace HandMadeEcommece.Models.config
//{
//    public class ProductVariantItemConfiguration : IEntityTypeConfiguration<ProductVariantItem>
//    {
//        public void Configure(EntityTypeBuilder<ProductVariantItem> builder)
//        {
//            builder.HasKey(x => x.Id);
//            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
//            builder.Property(x=>x.Status);
//            builder.Property(x=>x.IsDefault);
//            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
//            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");
//            builder.Property(x => x.Price).HasPrecision(10, 2);
//            builder.Property(x => x.Name).HasColumnType("VARCHAR").IsRequired().HasMaxLength(255);

//            builder.HasOne(e => e.ProductVariant)
//                .WithMany(e => e.ProductVariantItems)
//                .HasForeignKey(e => e.ProductVariantId)
//                .IsRequired(false);
//        }
//    }
//}
