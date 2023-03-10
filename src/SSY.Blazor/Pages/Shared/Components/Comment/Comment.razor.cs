using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.Administration.Users.Model;

namespace SSY.Blazor.Pages.Shared.Components.Comment
{

    public partial class Comment
    {
        #region Injections
        [Inject]
        public IWebHostEnvironment env { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private UserDetailService _userDetailService { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }
        private CommentService _commentService { get; set; }
        #endregion

        #region Parameters

        [Parameter]
        public string? PageName { get; set; }

        [Parameter]
        public Guid? RootId { get; set; }

        #endregion

        #region Models

        public CommentModel CommentModel { get; set; }
        private CommentModel ReplyModel { get; set; }
        private CommentModel SecondReplyModel { get; set; }
        private CommentModel ThirdReplyModel { get; set; }
        public int TotalCount = 0;
        public List<CommentModel> CommentListModel { get; set; }
        public List<Guid> CommentIds { get; set; }
        public SectionListModel SectionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CommentCategoryListModel CommentCategoryListModel { get; set; } = new() { Result = new() { Items = new() } };
        public SubjectListModel SubjectListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ProductTypeListModel ProductTypeListModel { get; set; } = new() { Items = new() };
        public GetAllCommentOutputModel GetAllCommentOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllUserDetailOutputModel GetAllUserDetailOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllUserDetailCCOutputModel UserDetailListModel { get; set; } = new() { Result = new() { Items = new() } };

        public UpdateCommentModel UpdateCommentModel { get; set; }
        public CollectionModel CollectionModel { get; set; }
        private string SelectedTab { get; set; }
        public string collapseInfluencers = string.Empty;
        public List<string> UploadedFiles { get; set; }
        public List<string> ToList { get; set; }
        public List<string> EmailList { get; set; }
        private IEnumerable<UserDetailModel> _userDetail { get; set; }
        private IEnumerable<UserDetailModelCC> _userDetailCC { get; set; }

        List<string> multipleSelectionData;
        List<string> multipleSelectionDataCC;
        List<string> multipleSelectionDataToCCEmpty;


        private List<IBrowserFile> loadedFiles;
        IReadOnlyList<IBrowserFile> selectedFile;
        private long maxFileSize = 1024 * 5000;
        private int maxAllowedFiles = 10;
        private bool isLoading;


        #endregion

        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                UpdateCommentModel = UpdateCommentModel ?? new();
                CommentModel = CommentModel ?? new();
                ReplyModel = ReplyModel ?? new();
                SecondReplyModel = SecondReplyModel ?? new();
                ThirdReplyModel = ThirdReplyModel ?? new();
                CommentListModel = CommentListModel ?? new();
                CommentIds = CommentIds ?? new();
                CollectionModel = CollectionModel ?? new();
                UploadedFiles = UploadedFiles ?? new();
                ToList = ToList ?? new();
                multipleSelectionData = multipleSelectionData ?? new();
                multipleSelectionDataCC = multipleSelectionDataCC ?? new();
                multipleSelectionDataToCCEmpty = multipleSelectionDataToCCEmpty ?? new();
                loadedFiles = loadedFiles ?? new();

                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
                _commentService = new(js, ClientFactory, NavigationManager, Configuration);
                _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
                _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);

                SectionListModel = await _getDropdownService.GetAllSection(null, null, null, 100);
                CommentCategoryListModel = await _getDropdownService.GetAllCommentCategory(null, null, null, 100);
                SubjectListModel = await _getDropdownService.GetAllSubject(null, null, null, 100);
                GetAllCommentOutputModel = await _commentService.GetAllComment(RootId, PageName, null, null, 100);
                UserDetailListModel = await _userDetailService.GetAllUserCC(null, null, null, null, null, 999);

                CollectionModel.Influencers = "Select Influencers";

                await GetCCs();
                await GetTos();
                await GetUploadedFiles();
                await AutoCompleteTo();

                IsLoading = false;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out? 
            }
        }

        public async Task AutoCompleteTo()
        {
            if (multipleSelectionData != null)
            {
                var response = await _userDetailService.GetAllUser(null, null, null, null, 100000);
                _userDetail = response.Result.Items;
                // var resourceNames = new List<string>();
                foreach (var to in response.Result.Items)
                {
                    to.NameAndEmailAddress = to.FullName + "(" + to.EmailAddress + ")";
                }
                // CommentModel.To = JsonSerializer.Serialize(multipleSelectionData);
                await base.OnInitializedAsync();
            }
        }
        public async Task AutoCompleteCC()
        {
            if (multipleSelectionDataCC != null)
            {
                var response = await _userDetailService.GetAllUserCC(null, null, null, null, null, 999);
                _userDetailCC = response.Result.Items;
                await base.OnInitializedAsync();
            }
        }
        public async Task GetUploadedFiles()
        {
            foreach (var item in GetAllCommentOutputModel?.Result?.Items)
            {
                if (item.File != null)
                {
                    UploadedFiles = JsonSerializer.Deserialize<List<string>>(item.File);
                    UploadedFiles.ForEach(x =>
                    {
                        FileInfo file = new FileInfo(x);
                        item.Files.Add(new Files() { Value = x, Extension = file.Extension.ToString() });
                    });
                }
            }
        }

        public async Task GetTos()
        {
            foreach (var item in GetAllCommentOutputModel?.Result?.Items)
            {
                if (item.To != null)
                {
                    item.Tos = JsonSerializer.Deserialize<List<string>>(item.To);
                }
            }
        }

        public async Task GetCCs()
        {
            foreach (var item in GetAllCommentOutputModel?.Result?.Items)
            {
                if (item.CC != null)
                {
                    item.CCs = JsonSerializer.Deserialize<List<string>>(item.CC);
                }
            }
        }
        public async Task AddComment(CommentModel input, Guid? parentId)
        {
            var session = await LocalStorage.GetAsync<UserSession>("userSession");
            if (selectedFile == null)
            {
                input.ParentId = parentId;
                input.To = JsonSerializer.Serialize(multipleSelectionData);
                input.CC = JsonSerializer.Serialize(multipleSelectionDataCC);
                CommentModel.From = session.Value.FullName;
                CommentModel.ReturnUrl = NavigationManager.Uri.ToString();
                ReplyModel.From = session.Value.FullName;
                ReplyModel.ReturnUrl = NavigationManager.Uri.ToString();
                SecondReplyModel.From = session.Value.FullName;
                SecondReplyModel.ReturnUrl = NavigationManager.Uri.ToString();
                ThirdReplyModel.From = session.Value.FullName;
                ThirdReplyModel.ReturnUrl = NavigationManager.Uri.ToString();
                await _commentService.CreateComment(input);
                GetAllCommentOutputModel = await _commentService.GetAllComment(RootId, PageName, null, null, 100);
                await GetTos();
                await GetCCs();
                await GetUploadedFiles();
                await ClearAll();
            }
            else if (selectedFile != null)
            {
                loadedFiles.Clear();
                List<string> files = new();
                foreach (var file in selectedFile)
                {
                    Stream stream = file.OpenReadStream(maxFileSize);
                    var path = $@"/Uploads/CommentsFile/{file.Name}";
                    var fullPath = $@"{env.WebRootPath}/Uploads/CommentsFile/{file.Name}";
                    FileStream fs = File.Create(fullPath);
                    await stream.CopyToAsync(fs);
                    fs.Close();
                    files.Add(path);
                }
                CommentModel.File = System.Text.Json.JsonSerializer.Serialize(files);
                input.ParentId = parentId;
                input.To = JsonSerializer.Serialize(multipleSelectionData);
                input.CC = JsonSerializer.Serialize(multipleSelectionDataCC);
                CommentModel.From = session.Value.FullName;
                CommentModel.ReturnUrl = NavigationManager.Uri.ToString();
                await _commentService.CreateComment(input);
                GetAllCommentOutputModel = await _commentService.GetAllComment(RootId, PageName, null, null, 100);
                await GetTos();
                await GetCCs();
                await GetUploadedFiles();
                await ClearAll();
            }

        }

        public async Task HandleSubmit(CommentModel input, Guid Id, string Message)
        {
            await _commentService.UpdateComment(input);

            ReplyModel.Message = string.Empty;
            SecondReplyModel.Message = string.Empty;
            ThirdReplyModel.Message = string.Empty;
            CommentModel.Message = string.Empty;
            CommentModel.File = string.Empty;
        }

        public async Task ClearAll()
        {
            CommentModel.Message = string.Empty;
            CommentModel.To = string.Empty;
            CommentModel.CC = string.Empty;
            CommentModel.SectionId = 0;
            CommentModel.SubjectId = 0;
            CommentModel.CategoryId = 0;
            ReplyModel.Message = string.Empty;
            SecondReplyModel.Message = string.Empty;
            ThirdReplyModel.Message = string.Empty;
        }
        public async Task DeleteSelectedIds(Guid id)
        {
            var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "Comment");

            GetAllCommentOutputModel = await _commentService.GetAllComment(RootId, PageName, null, null, 100);

            CommentIds.Clear();
        }

        public async Task ChangeTab(string tab)
        {
            SelectedTab = tab;
        }

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var dataFiles = e.GetMultipleFiles();
            selectedFile = dataFiles;
            var format = "all";
            List<string> files = new();


            foreach (var file in dataFiles)
            {
                var resizedImageFiles = await file.RequestImageFileAsync(format, 100, 100);
                var buffer = new byte[resizedImageFiles.Size];
                await resizedImageFiles.OpenReadStream().ReadAsync(buffer);
                var imageDataUrl = $"data: {format}; base64,{Convert.ToBase64String(buffer)}";
                files.Add(imageDataUrl);
            }
            this.StateHasChanged();
        }
    }
}