using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class DeliveryCompanyConfiguration : IEntityTypeConfiguration<DeliveryCompany>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompany> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(225);
            builder.Property(x => x.Address).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Pricing).IsRequired().HasPrecision(10, 2);
            builder.Property(x => x.Delivery_Zones).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
            //logo
            builder.Property(x => x.IdTax).IsRequired().HasColumnType("VARCHAR").HasMaxLength(255);
        }
    }
}
