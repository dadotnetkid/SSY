using Refit;
using SSY.Blazor.HttpClients.Data;
using SSY.Web.Blazor.PageModels.Collections;

namespace SSY.Blazor.HttpClients.RefitServices.Products.Collections;

public interface ICalendarApi
{
    [Get("/api/app/calendar/calendar-collection")]
    Task<ApiResponse<Results<CalendarCollectionModel>>> GetCalendar();
    [Post("/api/app/calendar/collection-to-calendar")]
    public Task<ApiResponse<object>> AddCollectionToCalendar([Body] AddCollectionToCalendarModel item);
    [Put("/api/app/calendar/calendar-by-status")]
    public Task<ApiResponse<object>> UpdateCollectionToCalendar([Body] UpdateCollectionCalendarModel item);
}