using System.Collections.Generic;
using Demo.Core.Data;
using Demo.Core.Data.Mapping;
using Demo.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username used to log in.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password used to log in.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the customer role.
        /// </summary>
        public CustomerRole Role { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Represents a map.
        /// </summary>
        public class Map : BaseEntityTypeConfiguration<Customer>
        {
            public override void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.MapDefaults();

                // basic columns
                builder.Property(m => m.Name).IsRequired();
                builder.Property(m => m.Username).IsRequired();
                builder.Property(m => m.Password).IsRequired();

                base.Configure(builder);
            }
        }
    }
}