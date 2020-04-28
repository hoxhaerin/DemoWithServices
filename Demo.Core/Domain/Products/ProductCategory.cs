using System.Collections.Generic;
using Demo.Core.Data;
using Demo.Core.Data.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Core.Domain.Products
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public class Map : BaseEntityTypeConfiguration<ProductCategory>
        {
            public override void Configure(EntityTypeBuilder<ProductCategory> builder)
            {
                builder.MapDefaults();

                builder.Property(m => m.Name);

                base.Configure(builder);
            }
        }
    }
}