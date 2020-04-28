using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Demo.Services.Orders
{
    public class CreateOrderRequest
    {
        public string Email { get; set; }

        public IList<CreateOrderRequestItem> Items { get; set; } = new List<CreateOrderRequestItem>();

        public class Validator : AbstractValidator<CreateOrderRequest>
        {
            public Validator()
            {
                RuleFor(m => m.Email)
                    //.NotEmpty()
                    .EmailAddress();
                RuleFor(m => m.Items).NotNull().NotEmpty();
            }
        }
    }

    public class CreateOrderRequestItem
    {
        public string ProductName { get; set; }

        public Guid? ProductId { get; set; }

        public decimal Amount { get; set; }

        public class Validator : AbstractValidator<CreateOrderRequestItem>
        {
            public Validator()
            {
                RuleFor(m => m.ProductName).NotEmpty();
                RuleFor(m => m.Amount).NotNull();
            }
        }
    }
}