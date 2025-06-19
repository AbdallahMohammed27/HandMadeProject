//using HandMadeEcommece.Models.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace HandMadeEcommece.Models.config
//{
//    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
//    {
//        public void Configure(EntityTypeBuilder<ProductVariant> builder)
//        {
//            builder.HasKey(x => x.Id);
//            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
//            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(255);
//            builder.Property(x => x.Status);
//            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
//            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");


//            builder.HasOne(e => e.Product)
//                .WithMany(e => e.ProductVariants)
//                .HasForeignKey(e=>e.ProductId)
//                .IsRequired(false);

//        }
//    }
//}
