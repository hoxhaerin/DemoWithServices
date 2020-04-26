using System;
using System.Collections.Generic;
using Demo.Core.Domain.Orders;

namespace Demo.Core.Services.Orders
{
    public class OrderModel : BaseModel
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
        /// Gets or sets the order items.
        /// </summary>
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
    }
}