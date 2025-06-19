using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class VendorConditionConfiguration : IEntityTypeConfiguration<VendorCondition>
    {
        public void Configure(EntityTypeBuilder<VendorCondition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.Content).IsRequired();

        }
    }
}
