using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config {
    /// <summary>
    /// Configure constraint for entities in database 
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure (EntityTypeBuilder<Product> builder) {
            builder.Property (p => p.Id).IsRequired ();
            builder.Property (p => p.Name).IsRequired ().HasMaxLength (100);
            builder.Property (p => p.Description).IsRequired ().HasMaxLength (180);
            builder.Property (p => p.Price).HasColumnType ("decimal(18,2)");
            builder.Property (p => p.PictureUrl).IsRequired ();
            builder.HasOne (f => f.ProductBrand).WithMany ().HasForeignKey (
                p => p.ProductBrandId
            );
            builder.HasOne (f => f.ProductType).WithMany ().HasForeignKey (
                p => p.ProductTypeId
            );
        }
    }
}