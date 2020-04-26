using System;
using System.Collections.Generic;

namespace Demo.Core.Services.Orders
{
    public class CreateOrderRequest
    {
        public string Email { get; set; }

        public IList<CreateOrderRequestItem> Items { get; set; } = new List<CreateOrderRequestItem>();
    }

    public class CreateOrderRequestItem
    {
        public string ProductName { get; set; }

        public Guid? ProductId { get; set; }

        public decimal Amount { get; set; }
    }

}