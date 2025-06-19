using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x=>x.Message).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Seen);
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME");
            builder.Property(x => x.UpdatedAt).HasColumnType("DATETIME");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Chats)
                .HasForeignKey(x => x.UserId)
                .IsRequired(false);

            builder.HasOne(x => x.Vendor)
                .WithMany(x => x.Chats)
                .HasForeignKey(x => x.VendorId)
                .IsRequired(false);
        }
    }
}
