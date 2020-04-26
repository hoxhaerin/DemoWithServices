using System;
using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.Services.Products
{
    /// <summary>
    /// Represents a request to update a product.
    /// </summary>
    public class UpdateProductRequest
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

        public class Validator : AbstractValidator<UpdateProductRequest>
        {
            public Validator()
            {
                RuleFor(m => m.Name).NotEmpty();
                RuleFor(m => m.Description).NotEmpty();
                RuleFor(m => m.Price).NotEmpty();
            }
        }

    }

    /// <summary>
    /// Represents a request to create a product.
    /// </summary>
    public class CreateProductRequest
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


        public class Validator : AbstractValidator<CreateProductRequest>
        {
            public Validator()
            {
                RuleFor(m => m.Name).NotEmpty();
                RuleFor(m => m.Description).NotEmpty();
                RuleFor(m => m.Price).NotEmpty();
            }
        }
    }
}