namespace SSY.Plugins.AwsS3Bucket.Contracts.Dto
{
    public class BucketOptionDto
    {
        public BucketOptionDto(IConfigurationSection configuration)
        {
            BucketName = configuration.GetValue<string>(nameof(BucketName));
            Region = configuration.GetValue<string>(nameof(Region));
            AccessKey = configuration.GetValue<string>(nameof(AccessKey));
            SecretKey = configuration.GetValue<string>(nameof(SecretKey));
            Token = configuration.GetValue<string>(nameof(Token));
        }

        public const string ConfigurationSetting = "S3Bucket";
        public string BucketName { get; set; }
        public string Region { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Token { get; set; }
    }
}
