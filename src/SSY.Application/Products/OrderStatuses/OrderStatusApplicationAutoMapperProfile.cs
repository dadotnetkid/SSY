using AutoMapper;
using SSY.Products.OrderStatuses.Dtos;

namespace SSY.Products.OrderStatuses;

public class OrderStatusApplicationAutoMapperProfile : Profile
{
    public OrderStatusApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<OrderStatus, OrderStatusDto>();
        CreateMap<CreateOrderStatusDto, OrderStatus>();
        CreateMap<UpdateOrderStatusDto, OrderStatus>();
    }
}