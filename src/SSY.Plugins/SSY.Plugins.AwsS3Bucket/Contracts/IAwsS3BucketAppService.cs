using Amazon.S3.Model;
using SSY.Plugins.AwsS3Bucket.Contracts.Dto;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace SSY.Plugins.AwsS3Bucket.Contracts;

public interface IAwsS3BucketAppService : IApplicationService
{
    Task Upload(IRemoteStreamContent file, string? folderName, string? fileName);
    Task<List<S3Object>> GetAll();
    Task DeleteByFolderNameAndFileName(string folder, string fileName);
    Task DeleteByFileName(string fileName);
}