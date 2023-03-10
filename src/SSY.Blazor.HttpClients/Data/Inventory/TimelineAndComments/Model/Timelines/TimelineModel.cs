using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Timelines
{
    public class TimelineModel
    {
        [JsonPropertyName("tenantId")]
        public int? TenantId { get; set; } = 1;

        [JsonPropertyName("userId")]
        public long? UserId { get; set; }

        [JsonPropertyName("serviceName")]
        public string ServiceName { get; set; }

        [JsonPropertyName("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyName("parameters")]
        public string Parameters { get; set; }

        // [JsonPropertyName("returnValue")]
        // public string ReturnValue { get; set; }

        [JsonPropertyName("executionTime")]
        public DateTime ExecutionTime { get; set; }

        // [JsonPropertyName("executionDuration")]
        // public int ExecutionDuration { get; set; }

        // [JsonPropertyName("clientIpAddress")]
        // public string ClientIpAddress { get; set; }

        // [JsonPropertyName("clientName")]
        // public string ClientName { get; set; }

        // [JsonPropertyName("browserInfo")]
        // public string BrowserInfo { get; set; }

        // [JsonPropertyName("exceptionMessage")]
        // public string ExceptionMessage { get; set; }

        // [JsonPropertyName("exception")]
        // public string Exception { get; set; }

        // [JsonPropertyName("impersonatorUserId")]
        // public long? ImpersonatorUserId { get; set; }

        // [JsonPropertyName("impersonatorTenantId")]
        // public int? ImpersonatorTenantId { get; set; }

        // [JsonPropertyName("customData")]
        // public string CustomData { get; set; }

    }


}


