using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Products.Collections.CalendarConfigurations;
using SSY.Products.Collections.Calendars.Dtos;
using SSY.Products.Collections.Dtos;
using SSY.Products.Helpers;
using SSY.Products.Holidays;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Local;

namespace SSY.Products.Collections.Calendars
{
    public class CalendarAppService : CrudAppService<Calendar, CalendarDto, Guid, PagedAndSortedResultRequestDto, CreateCalendarDto, UpdateCalendarDto>, ICalendarAppService
    {
        private readonly IRepository<CalendarConfiguration, int> _calendarConfigurationRepository;
        private readonly IRepository<Holiday, long> _holidayRepository;
        private readonly ILocalEventBus _localEventBus;

        public CalendarAppService(IRepository<Calendar, Guid> repository,
            IRepository<CalendarConfiguration, int> calendarConfigurationRepository,
            IRepository<Holiday, long> holidayRepository,
            ILocalEventBus localEventBus
            ) : base(repository)
        {
            _calendarConfigurationRepository = calendarConfigurationRepository;
            _holidayRepository = holidayRepository;
            _localEventBus = localEventBus;
        }
        protected override async Task<IQueryable<Calendar>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {

            try
            {
                return await base.CreateFilteredQueryAsync(input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = "{ex.Message}{innerException}";
                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }

        }
        public override async Task<CalendarDto> CreateAsync(CreateCalendarDto input)
        {

            try
            {
                return await base.CreateAsync(input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }

        }
        public override async Task<CalendarDto> UpdateAsync(Guid id, UpdateCalendarDto input)
        {
            try
            {
                return await base.UpdateAsync(id, input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public async Task UpdateCalendarByStatus(CollectionUpdateEventDto item)
        {
            await _localEventBus.PublishAsync(item);
        }
        public async Task<PagedResultDto<GetCalendarCollectionDto>> GetCalendarCollection()
        {

            try
            {
                var query = await Repository.GetQueryableAsync();
                var calendarConfig = await _calendarConfigurationRepository.GetQueryableAsync();
                var holiday = await _holidayRepository.GetQueryableAsync();
                var list = query.Select(c => new GetCalendarCollectionDto()
                {
                    CollectionName = c.Collection.Name,
                    CollectionDevelopmentTarget = c.CollectionDevelopmentTarget,
                    CollectionDevelopmentActual = c.Collection.CreationTime,
                    ActualSalesQuantity = c.ActualSalesQuantity,
                    SalesForecastQuantity = c.SalesForecastQuantity,
                    CollectionStatuses = calendarConfig.Select(cc => new CollectionStatusDto()
                    {
                        Name = cc.ProductStatus.Label,
                        TargetDay = cc.Value,

                        ProductStatus = new CalendarProductStatusDto()
                        {
                            Label = cc.ProductStatus.Label,
                            Id = cc.ProductStatus.Id,
                            DesignStatus = new DesignStatuses.Dtos.DesignStatusDto()
                            {
                                Label = cc.ProductStatus.DesignStatus.Label,
                                Id = cc.ProductStatus.DesignStatus.Id,
                            }
                        }
                    }).ToList(),
                    ActualCollectionStatus = c.CalendarDetails.Select(cd => new CollectionStatusDto
                    {
                        Actual = cd.CreationTime,
                        ProductStatus = new CalendarProductStatusDto()
                        {
                            Label = cd.ProductStatus.Label,
                            Id = cd.ProductStatus.Id,
                        }
                    }).ToList()
                }).ToList();
                var holidayDates = holiday.Select(c => c.HolidayDate).ToList();
                foreach (var i in list)
                {
                    var index = 0;
                    foreach (var d in i.CollectionStatuses)
                    {
                        var collectionStatus = index == 0 ? null : i.CollectionStatuses[index - 1];
                        d.Target = collectionStatus is null ? i.CollectionDevelopmentTarget.ToBusinessDay(d.TargetDay, holidayDates) : collectionStatus.Target?.ToBusinessDay(d.TargetDay, holidayDates);
                        index++;
                    }
                }
                return new PagedResultDto<GetCalendarCollectionDto>()
                {
                    Items = list,
                    TotalCount = list.Count()
                };
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public async Task AddCollectionToCalendar(AddCollectionToCalendarDto item)
        {
            await CreateAsync(new CreateCalendarDto()
            {
                IsActive = true,
                CollectionId = item.CollectionId,
                SalesForecastQuantity = item.SalesForecastQuantity,
                ActualSalesQuantity = 0,
                CollectionDevelopmentTarget = item.CollectionDevelopmentTarget,
            });
        }
    }
}
