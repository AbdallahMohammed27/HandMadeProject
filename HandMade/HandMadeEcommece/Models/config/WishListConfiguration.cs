using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(e => new { e.UserId, e.ProductId });
        }
    }
}
