using System.Text.Json;
using System.Text.Json.Serialization;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace SSY.Blazor.HttpClients.Services
{
    public class AccountAppService
    {
        public AccountAppService(IJSRuntime js,
        IHttpClientFactory ClientFactory,
        NavigationManager NavigationManager,
        IConfiguration Configuration,
        IMessageService MessageService)
        {
            _js = js;
            _clientFactory = ClientFactory;
            _navigationManager = NavigationManager;
            _configuration = Configuration;
            _messageService = MessageService;
        }

        #region Injects

        private readonly IJSRuntime _js;
        private readonly IHttpClientFactory _clientFactory;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;
        private readonly IMessageService _messageService;

        #endregion
    }
}