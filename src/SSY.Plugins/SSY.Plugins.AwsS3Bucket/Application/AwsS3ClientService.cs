using Amazon.S3;
using Amazon.S3.Model;
using Blazorise;
using SSY.Plugins.AwsS3Bucket.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Plugins.AwsS3Bucket.Application
{
    public class AwsS3ClientService
    {
        private readonly IAmazonS3 _client;
        private readonly BucketOptionDto _bucketOption;

        public AwsS3ClientService(IConfiguration configuration, IAmazonS3 amazonS3)
        {
            _client = amazonS3;
            _bucketOption = new BucketOptionDto(configuration.GetSection(BucketOptionDto.ConfigurationSetting));
        }

        public async Task<List<S3Object>> GetAllObjects()
        {
            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = _bucketOption.BucketName,
                MaxKeys = 10
            };

            var response = await _client.ListObjectsV2Async(request);

            return response.S3Objects;
        }

        public async Task UploadAsync(string folder, string fileName, byte[] file)
        {
            await UploadAsync(folder, fileName, new MemoryStream(file));
        }

        public async Task UploadAsync(string folder, string fileName, Stream file)
        {
            var putRequest = new PutObjectRequest()
            {
                BucketName = _bucketOption.BucketName,
                Key = $"{folder.EnsureEndsWith('/')}{fileName}",
                InputStream = file,
            };
            await _client.PutObjectAsync(putRequest);
        }

        public async Task DeleteAsync(string folder, string fileName)
        {
            await DeleteAsync($"{folder.EnsureEndsWith('/')}{fileName}");
        }

        public async Task DeleteAsync(string fileName)
        {
            var deleteRequest = new DeleteObjectRequest()
            {
                BucketName = _bucketOption.BucketName,
                Key = fileName,
            };
            await _client.DeleteObjectAsync(deleteRequest);
        }
    }
}
