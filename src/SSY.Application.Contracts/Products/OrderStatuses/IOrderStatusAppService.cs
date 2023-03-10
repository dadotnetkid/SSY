using System;
using SSY.Products.OrderStatuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.OrderStatuses;

public interface IOrderStatusAppService : ICrudAppService<OrderStatusDto, int, PagedAndSortedResultRequestDto, CreateOrderStatusDto, UpdateOrderStatusDto>
{
}