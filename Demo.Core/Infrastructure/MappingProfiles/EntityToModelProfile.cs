using AutoMapper;
using Demo.Core.Domain.Orders;
using Demo.Core.Domain.Products;
using Demo.Core.Services.Orders;
using Demo.Core.Services.Products;

namespace Demo.Core.Infrastructure.MappingProfiles
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<Order, OrderModel>();
            CreateMap<OrderItem, OrderItemModel>();
        }
    }
}