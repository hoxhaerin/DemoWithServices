using AutoMapper;
using Demo.Core.Domain.Orders;
using Demo.Core.Domain.Products;
using Demo.Services.Orders;
using Demo.Services.Products;

namespace Demo.Web.Infrastructure.MappingProfiles
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