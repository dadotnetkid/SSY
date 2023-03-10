using Volo.Abp.Content;

namespace SSY.Plugins.AwsS3Bucket.Contracts.Dto;

public class CreateFileInput
{
    public string? FileName { get; set; }
    public IRemoteStreamContent File { get; set; }
    public string? FolderName { get; set; }
}