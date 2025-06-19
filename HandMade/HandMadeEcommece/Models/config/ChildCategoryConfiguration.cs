//using HandMadeEcommece.Models.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace HandMadeEcommece.Models.config
//{
//    public class ChildCategoryConfiguration : IEntityTypeConfiguration<ChildCategory>
//    {
//        public void Configure(EntityTypeBuilder<ChildCategory> builder)
//        {
//            builder.HasKey(x => x.Id);
//            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
//            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(255);
//            builder.Property(x => x.Slug).HasColumnType("VARCHAR").HasMaxLength(255);
//            builder.Property(x => x.Status);
//            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
//            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");

//            builder.HasOne(x => x.SubCategory)
//                .WithMany(x => x.ChildCategories)
//                .HasForeignKey(x => x.SubCategoryId)
//                .IsRequired(false);
//        }
//    }
//}
