using System;
using Demo.Core.Domain.Products;

namespace Demo.Core
{
    public static class Seeds
    {
        public static class Products
        {
            public static Product Banana = new Product()
            {
                Id = Guid.Parse("E4D7C33E-977F-4C8B-8129-DCECB158CE46"),
                Name = "Banana",
                Description = "A banana is an elongated, edible fruit – botanically a berry – produced by several kinds of large herbaceous flowering plants in the genus Musa. In some countries, bananas used for cooking may be called \"plantains\", distinguishing them from dessert bananas.",
                Price = 20m
            };
            public static Product Apple = new Product()
            {
                Id = Guid.Parse("5C38B90B-F5A6-4F74-9EB9-3B9BDF1AE3D1"),
                Name = "Apple",
                Description = "An apple is a sweet, edible fruit produced by an apple tree. Apple trees are cultivated worldwide and are the most widely grown species in the genus Malus. The tree originated in Central Asia, where its wild ancestor, Malus sieversii, is still found today.",
                Price = 15m
            };
        }
    }
}