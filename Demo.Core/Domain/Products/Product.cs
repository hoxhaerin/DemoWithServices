using System;
using System.Collections.Generic;
using Demo.Core.Data;
using Demo.Core.Data.Mapping;
using Demo.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Core.Domain.Products
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        public Guid? ProductCategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the order items.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Represents a map.
        /// </summary>
        public class Map : BaseEntityTypeConfiguration<Product>
        {
            public override void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.MapDefaults();

                // basic columns
                builder.Property(m => m.Name).IsRequired();
                builder.Property(m => m.Description).IsRequired();
                builder.Property(m => m.Price).IsRequired().HasColumnType("decimal(14, 4)");

                builder.HasOne(m => m.Category)
                    .WithMany(m => m.Products)
                    .HasForeignKey(m => m.ProductCategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

                base.Configure(builder);
            }

            protected override void PostConfigure(EntityTypeBuilder<Product> builder)
            {
                builder.HasData(
                    Seeds.Products.Apple,
                    Seeds.Products.Banana
                    );

                base.PostConfigure(builder);
            }
        }
    }
}