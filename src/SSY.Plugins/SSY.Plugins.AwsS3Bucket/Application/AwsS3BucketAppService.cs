using Amazon.S3.Model;
using SSY.Plugins.AwsS3Bucket.Contracts;
using SSY.Plugins.AwsS3Bucket.Contracts.Dto;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace SSY.Plugins.AwsS3Bucket.Application
{
    public class AwsS3BucketAppService :  ApplicationService, IAwsS3BucketAppService
    {
        private readonly AwsS3ClientService _awsS3ClientService;
        private readonly BucketOptionDto _bucketOption;

        public AwsS3BucketAppService(AwsS3ClientService awsS3ClientService)
        {
            _awsS3ClientService = awsS3ClientService;
        }


        public async Task Upload(IRemoteStreamContent file, string? folderName, string? fileName)
        {
            await _awsS3ClientService.UploadAsync(folderName,fileName, file.GetStream());
        }

        

        public async Task<List<S3Object>> GetAll()
        {
            var res=await _awsS3ClientService.GetAllObjects();
            return res;
        }

        public async Task DeleteByFolderNameAndFileName(string folder, string fileName)
        {
            await _awsS3ClientService.DeleteAsync(folder, fileName);
        }

        public async Task DeleteByFileName(string fileName)
        {
            await _awsS3ClientService.DeleteAsync(fileName);
        }
    }
}
