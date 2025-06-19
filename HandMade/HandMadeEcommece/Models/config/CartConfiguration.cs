using HandMadeEcommece.Models.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandMadeEcommece.Models.config
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e=>e.IsActived);
            builder.Property(e => e.CreatedAt).HasColumnType("DATETIME");
            builder.Property(e => e.UpdatedAt).HasColumnType("DATETIME");

          /*  builder.HasMany(e=>e.items)
                .WithOne(e=>e.car)*/

            builder.HasMany(e => e.products)
                .WithMany(e => e.Carts)
                .UsingEntity<CartItem>();
                
        }
    }
}
