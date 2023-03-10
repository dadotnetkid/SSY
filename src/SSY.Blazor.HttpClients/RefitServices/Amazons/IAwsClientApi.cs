using Refit;

namespace SSY.Blazor.HttpClients.RefitServices.Amazons;

public interface IAwsClientApi
{
    [Multipart("----WebKitFormBoundary7MA4YWxkTrZu0gW")]
    [Post("/upload")]
    public Task<ApiResponse<object>> Upload([AliasAs("file")] StreamPart file,
        [AliasAs("fileName")] string? fileName,
        [AliasAs("folderName")] string? folderName);
}