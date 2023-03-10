using Refit;

namespace SSY.Blazor.HttpClients.RefitServices.Settings.AutoEmails;

public interface IAutoEMailApi
{
    [Get("/Mail/Get")]
    Task<AutoEmailModel> GetAutoEmail([AliasAs("id")] Guid autoEmailId);

    [Get("/Mail/GetAll")]
    Task<List<AutoEmailModel>> GetAutoEmails(
        [AliasAs("SkipCount")] int? skipCount,
        [AliasAs("maxResultCount")] int? maxResultCount
        );

    [Post("/Mail/Create")]
    Task<AutoEmailModel> CreateAutoEmail([Body] AutoEmailModel autoEmail);

    [Put("/Mail/Update")]
    Task<AutoEmailModel> UpdateAutoEmail([Body] AutoEmailModel autoEmail);

    [Delete("/Mail/Delete")]
    Task DeleteAutoEmail([AliasAs("id")] Guid autoEmailId);
}