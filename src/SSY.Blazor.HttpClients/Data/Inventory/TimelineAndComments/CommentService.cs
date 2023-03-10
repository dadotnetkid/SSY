using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Comments;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments
{
    public class CommentService
    {
        public CommentService(IJSRuntime js,
        IHttpClientFactory ClientFactory,
        NavigationManager NavigationManager,
        IConfiguration Configuration)
        {
            _js = js;
            _clientFactory = ClientFactory;
            _navigationManager = NavigationManager;
            _configuration = Configuration;
        }

        #region Injects

        private readonly IJSRuntime _js;
        private readonly IHttpClientFactory _clientFactory;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;
        private CommentModel ReplyModel { get; set; } = new();
        #endregion


        public async Task<GetAllCommentOutputModel> GetAllComment(Guid? rootId, string? pageName, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Comment/GetAll?";
            if (rootId != null)
                url += "RootId=" + HttpUtility.UrlEncode("" + rootId) + "&";
            if (pageName != null)
                url += "PageName=" + HttpUtility.UrlEncode("" + pageName) + "&";
            if (sorting != null)
                url += "Sorting=" + HttpUtility.UrlEncode("" + sorting) + "&";
            if (skipCount != null)
                url += "SkipCount=" + HttpUtility.UrlEncode("" + skipCount) + "&";
            if (maxResultCount != null)
                url += "MaxResultCount=" + HttpUtility.UrlEncode("" + maxResultCount) + "&";
            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllCommentOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllCommentOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Adjustment Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<CreateOutputCommentModel> CreateComment(CommentModel comment)
        {
            CreateOutputCommentModel results = new();

            CreateCommentModel commentModel = new()
            {
                TenantId = comment.TenantId,
                IsActive = comment.IsActive,
                SectionId = comment.SectionId,
                CategoryId = comment.CategoryId,
                SubjectId = comment.SubjectId,
                To = comment.To,
                CC = comment.CC,
                From = comment.From,
                File = comment.File,
                Message = comment.Message,
                PageName = comment.PageName,
                ParentId = comment.ParentId,
                RootId = comment.RootId
            };

            var json = JsonSerializer.Serialize(commentModel);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Comment/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOutputCommentModel>(commentResponseStream);
                results = data;
                await _js.InvokeVoidAsync("defaultMessage", "success", "Comment Success", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Comment Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

            return results;
        }

        public async Task UpdateComment(CommentModel commentModel)
        {


            UpdateCommentModel updateComment = new()
            {
                Id = commentModel.Id,
                TenantId = commentModel.TenantId,
                IsActive = commentModel.IsActive,
                SectionId = commentModel.SectionId,
                CategoryId = commentModel.CategoryId,
                SubjectId = commentModel.SubjectId,
                To = commentModel.To,
                CC = commentModel.CC,
                From = commentModel.From,
                File = commentModel.File,
                Message = commentModel.Message,
                PageName = commentModel.PageName,
                ParentId = commentModel.ParentId,
                RootId = commentModel.RootId
            };

            var json = JsonSerializer.Serialize(updateComment);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/Comment/Update";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            CommentModel comment = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetCommentOutputModel>(responseStream);
                comment = data.Result;
                await _js.InvokeVoidAsync("defaultMessage", "success", "Comment Update Success", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }
    }
}

