using System;
using Demo.Core.Data;
using Demo.Core.Data.Mapping;
using Demo.Core.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Core.Domain.Orders
{
    /// <summary>
    /// Represents an order item.
    /// </summary>
    public class OrderItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the selling price.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Represents a map.
        /// </summary>
        public class Map : BaseEntityTypeConfiguration<OrderItem>
        {
            public override void Configure(EntityTypeBuilder<OrderItem> builder)
            {
                builder.MapDefaults();

                // basic columns
                builder.Property(m => m.Name).IsRequired();
                builder.Property(m => m.Amount).IsRequired().HasColumnType("decimal(14, 4)");

                // mapped columns
                builder.HasOne(model => model.Order)
                    .WithMany(other => other.OrderItems)
                    .HasForeignKey(model => model.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(model => model.Product)
                    .WithMany(other => other.OrderItems)
                    .HasForeignKey(model => model.ProductId)
                    .OnDelete(DeleteBehavior.SetNull);

                base.Configure(builder);
            }
        }
    }
}