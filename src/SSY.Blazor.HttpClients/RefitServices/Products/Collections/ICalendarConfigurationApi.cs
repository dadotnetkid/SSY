using Refit;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Models.Products.Collections.CalendarConfigurations;

namespace SSY.Blazor.HttpClients.RefitServices.Products.Collections;

public interface ICalendarConfigurationApi
{
    [Get("/api/app/calendar-configuration")]
    Task<ApiResponse<Results<CalendarConfigurationModel>>> GetAllConfiguration(
        [AliasAs("SkipCount")] int skipCount,
        [AliasAs("maxResultCount")] int maxResultCount
        );
}