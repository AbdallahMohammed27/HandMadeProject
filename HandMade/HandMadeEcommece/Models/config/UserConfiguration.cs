using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");

            builder.HasMany(e => e.Products)
                .WithMany(e => e.Users)
                .UsingEntity<WishList>();

            builder.HasOne(e => e.Role)
               .WithMany(e => e.Users)
               .HasForeignKey(e => e.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
