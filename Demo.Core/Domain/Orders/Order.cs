using System;
using System.Collections.Generic;
using Demo.Core.Data;
using Demo.Core.Data.Mapping;
using Demo.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Core.Domain.Orders
{
    /// <summary>
    /// Represents an order.
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date order was placed.
        /// </summary>
        public DateTime PlacedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date order was paid on.
        /// </summary>
        public DateTime? PaidOnUtc { get; set; }
        
        /// <summary>
        /// Gets or sets the date the order was fulfilled on.
        /// </summary>
        public DateTime? FulfilledOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the order owner email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the customer id that may own this order.
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer that may own this order.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the order items.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Represents a map.
        /// </summary>
        public class Map : BaseEntityTypeConfiguration<Order>
        {
            public override void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.MapDefaults();

                // basic columns
                builder.Property(m => m.Number).IsRequired();
                builder.Property(m => m.Amount).IsRequired().HasColumnType("decimal(14, 4)");
                builder.Property(m => m.PlacedOnUtc).IsRequired();

                // mapped columns
                builder.HasOne(model => model.Customer)
                    .WithMany(other => other.Orders)
                    .HasForeignKey(model => model.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);

                base.Configure(builder);
            }
        }
    }
}