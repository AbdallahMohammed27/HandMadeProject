using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(225).HasColumnType("VARCHAR");

            
        }
    }
}
