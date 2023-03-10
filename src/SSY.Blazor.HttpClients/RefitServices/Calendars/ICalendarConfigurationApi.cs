using Refit;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Models.Products.Collections.CalendarConfigurations;

namespace SSY.Blazor.HttpClients.Refit.Services.Calendars;

public interface ICalendarConfigurationApi
{
    [Get("/api/app/calendar-configuration")]
    Task<ApiResponse<Results<CalendarConfigurationModel>>> GetAllConfiguration(
        [AliasAs("SkipCount")] int skipCount,
        [AliasAs("maxResultCount")] int maxResultCount
        );
}