using Amazon;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using SSY.Plugins.AwsS3Bucket.Application;
using SSY.Plugins.AwsS3Bucket.Contracts.Dto;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace SSY.Plugins.AwsS3Bucket
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class AwsS3BucketModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

            base.OnApplicationInitialization(context);
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AwsS3BucketModule).Assembly);
                options.ConventionalControllers.FormBodyBindingIgnoredTypes.Add(typeof(CreateFileInput));
            });

            context.Services.AddScoped<IAmazonS3>(option =>
            {
                var res = context.Services.GetConfiguration().GetSection(BucketOptionDto.ConfigurationSetting);
                var bucketOption = new BucketOptionDto(res);
                var config = new AmazonS3Config()
                {
                    RegionEndpoint = RegionEndpoint.GetBySystemName(bucketOption.Region)
                };
                return new AmazonS3Client(bucketOption.AccessKey, bucketOption.SecretKey, config);
            });
            context.Services.AddScoped<AwsS3ClientService>();
        }
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                //Add plugin assembly
                mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(AwsS3BucketModule).Assembly));

                //Add CompiledRazorAssemblyPart if the PlugIn module contains razor views.
                mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(AwsS3BucketModule).Assembly));
            });
        }

    }
}