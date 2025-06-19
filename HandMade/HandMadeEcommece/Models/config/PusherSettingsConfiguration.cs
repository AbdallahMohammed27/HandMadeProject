using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class PusherSettingsConfiguration : IEntityTypeConfiguration<PusherSetting>
    {
        public void Configure(EntityTypeBuilder<PusherSetting> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.PusherCluster).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x=>x.PusherKey).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.PusherSecret).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.PusherAppId).HasColumnType("VARCHAR").HasMaxLength(255);

            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");
        }
    }
}
