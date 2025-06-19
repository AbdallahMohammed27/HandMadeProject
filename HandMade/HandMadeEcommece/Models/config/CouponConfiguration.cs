using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x=>x.StartDate).IsRequired().HasColumnType("DATETIME");
            builder.Property(x => x.EndDate).IsRequired().HasColumnType("DATETIME");
            builder.Property(x => x.MaxUse).IsRequired();
            builder.Property(x=>x.Discount).IsRequired().HasPrecision(10,2);
            builder.Property(x => x.TotalUsed);
            builder.Property(x=>x.Name).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Code).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);

            builder.HasMany(e => e.users)
                .WithMany(e => e.Coupons)
                .UsingEntity<UserCoupons>();
        }
    }
}
