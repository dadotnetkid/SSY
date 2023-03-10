using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSY.Products.Collections.Calendars;
using SSY.Products.Collections.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;

namespace SSY.Products.Collections.Events
{
    public class CollectionStatusUpdateHandler : ILocalEventHandler<CollectionUpdateEventDto>, ITransientDependency
    {
        private readonly IRepository<Calendar, Guid> _calendarRepository;

        public CollectionStatusUpdateHandler(IRepository<Calendar, Guid> calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }
        public async Task HandleEventAsync(CollectionUpdateEventDto eventData)
        {
            if (eventData.StatusId == 1003)
                await UpdateCalendarToActive(eventData);
            else
                await UpdateCalendarToInActive(eventData);

        }

        private async Task UpdateCalendarToInActive(CollectionUpdateEventDto eventData)
        {
            if (eventData.StatusId == 1003) return;
            var res = (await _calendarRepository.WithDetailsAsync()).IgnoreQueryFilters()
                .AsNoTracking()
                .FirstOrDefault(c => c.CollectionId == eventData.CollectionId);
            if (res == null) return;
            res.SetActive(isActive: false);
            await _calendarRepository.UpdateAsync(res);
        }

        private async Task UpdateCalendarToActive(CollectionUpdateEventDto eventData)
        {
            if (eventData.StatusId != 1003) return;
            var res = (await _calendarRepository.WithDetailsAsync()).IgnoreQueryFilters()
                .AsNoTracking()
                .FirstOrDefault(c => c.CollectionId == eventData.CollectionId);
            if (res == null)
            {
                await CreateCalendar(eventData);
                return;
            }
            res.SetActive(isActive: true);
            await _calendarRepository.UpdateAsync(res);
        }

        private async Task CreateCalendar(CollectionUpdateEventDto eventData)
        {
            await _calendarRepository.InsertAsync(new Calendar(Guid.NewGuid(), eventData.CollectionId, eventData.SalesForecastQuantity, 0,
                   eventData.CollectionDevelopmentTarget, true));
        }
    }
}
