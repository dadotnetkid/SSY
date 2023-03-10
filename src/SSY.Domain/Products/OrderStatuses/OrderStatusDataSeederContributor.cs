using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.OrderStatuses;

public class OrderStatusDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<OrderStatus, int> _orderStatusRepository;

    public OrderStatusDataSeederContributor(IRepository<OrderStatus, int> orderStatusRepository)
    {
        _orderStatusRepository = orderStatusRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _orderStatusRepository.GetCountAsync() <= 0)
        {
            await _orderStatusRepository.InsertAsync(new OrderStatus(1001, true, "Not Ordered", "Not Ordered", 1), autoSave: true);
            await _orderStatusRepository.InsertAsync(new OrderStatus(1002, true, "Approved", "Approved", 2), autoSave: true);
            await _orderStatusRepository.InsertAsync(new OrderStatus(1003, true, "Rejected", "Rejected", 3), autoSave: true);
            await _orderStatusRepository.InsertAsync(new OrderStatus(1004, true, "Ordered", "Ordered", 4), autoSave: true);
        }
    }
}