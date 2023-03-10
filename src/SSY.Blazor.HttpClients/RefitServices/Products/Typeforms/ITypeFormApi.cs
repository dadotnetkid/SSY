using Refit;
using SSY.Blazor.HttpClients.Models.Requests;
using SSY.Blazor.HttpClients.Models.TypeForms.Response;

namespace SSY.Blazor.HttpClients.RefitServices.Products.Typeforms;

public interface ITypeFormApi
{
    [Post("/api/app/typeform/response-by-influencer-and-type")]
    public Task<ApiResponse<TypeFormResponseDto>> GetTypeFormResponse([Body] TypeFormRequestModel item);
}