using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using SSY.Common.Extensions;

namespace SSY.Blazor.HttpClients.RefitServices;

public static class RefitDependencyRegistrar
{
    public static void RegisterRefitApi(this IServiceCollection services, ConfigurationManager configuration)
    {
        var baseUrl = configuration["App:ProductClientRootAddress"];
        var setting = new RefitSettings()
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            })
        };
        services
            .AddRefitClient<ICalendarConfigurationApi>(setting)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        services
            .AddRefitClient<ICalendarApi>(setting)
            .ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrl); });
        services
             .AddRefitClient<ICalendarApi>(setting)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        services
             .AddRefitClient<ITypeFormApi>(setting)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        services
             .AddRefitClient<IAwsClientApi>(setting)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{baseUrl.EnsureEndsWith('/')}api/app/aws-s3Bucket"));
        services
             .AddRefitClient<IShopifyApi>(setting)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{baseUrl.EnsureEndsWith('/')}api/app/shopify"));
        services
             .AddRefitClient<ICollectionApi>(setting)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{baseUrl.EnsureEndsWith('/')}api/app/collection"));
    }
}