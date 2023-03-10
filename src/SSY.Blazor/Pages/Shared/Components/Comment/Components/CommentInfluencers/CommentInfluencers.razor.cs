using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace SSY.Blazor.Pages.Shared.Components.Comment.Components.CommentInfluencers
{

    public partial class CommentInfluencers
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

       
        public CommentModel CommentModel { get; set; } = new();
        private CommentModel ReplyModel { get; set; } = new();
        private CommentModel SecondReplyModel { get; set; } = new();
        private CommentModel ThirdReplyModel { get; set; } = new();
        public int TotalCount = 0;
        public List<CommentModel> CommentListModel { get; set; } = new();
        public List<Guid> CommentIds { get; set; } = new();
        public SectionListModel SectionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CommentCategoryListModel CommentCategoryListModel { get; set; } = new() { Result = new() { Items = new() } };
        public SubjectListModel SubjectListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ProductTypeListModel ProductTypeListModel { get; set; } = new() { Items = new() };
        public GetAllCommentOutputModel GetAllCommentOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllUserDetailOutputModel GetAllUserDetailOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        
        private string SelectedTab { get; set; }
        public List<string> UploadedFiles { get; set; } = new();
        public List<string> ToList { get; set; } = new();
        private IEnumerable<UserDetailModel> _userDetail {get; set;}
        private IEnumerable<UserDetailModelCC> _userDetailCC {get; set;}

        List<string> multipleSelectionData = new();
        List<string> multipleSelectionDataCC = new();
        
        private List<IBrowserFile> loadedFiles = new();
        IReadOnlyList<IBrowserFile> selectedFile;
        private long maxFileSize = 1024 * 5000;
        private int maxAllowedFiles = 10;
        private bool isLoading;

        
        #endregion
         
   
        protected override async Task OnInitializedAsync()
        {   
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _commentService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);

            SectionListModel = await _getDropdownService.GetAllSection(null, null, null, 100);
            CommentCategoryListModel = await _getDropdownService.GetAllCommentCategory(null, null, null, 100);
            SubjectListModel = await _getDropdownService.GetAllSubject(null, null, null, 100);
            ProductTypeListModel = await _getDropdownService.GetAllProductType(null, null, null, 100);
            GetAllCommentOutputModel = await _commentService.GetAllComment(RootId, PageName, null, null, 100);
            
            await GetCCs();
            await GetTos();
            await GetUploadedFiles();
            await AutoCompleteTo();
            await AutoCompleteCC();
          
        }

         public async Task AutoCompleteTo()
        {
            if(multipleSelectionData == null){
            var response = await _userDetailService.GetAllUser(null, null, null, null, 100000);
            _userDetail = response.Result.Items;
            response.Result.Items.ForEach(x => {
                 multipleSelectionData.Add(x.Name);
             });
            await base.OnInitializedAsync();
            }
            
        }
         public async Task AutoCompleteCC()
        {
            if(multipleSelectionDataCC == null){
            var response = await _userDetailService.GetAllUserCC(null, null, null, null, null, 100000);
            _userDetailCC = response.Result.Items;
            response.Result.Items.ForEach(y => {
            multipleSelectionDataCC.Add(y.Name);
             });
            await base.OnInitializedAsync();
            }
        }
        public async Task GetUploadedFiles()
        {
            foreach (var item in GetAllCommentOutputModel?.Result?.Items)
            {
                if(item.File != null)
                {
                    UploadedFiles = JsonSerializer.Deserialize<List<string>>(item.File);
                    UploadedFiles.ForEach(x =>
                    {
                        FileInfo file = new FileInfo(x);
                        item.Files.Add(new Files() { Value = x,Extension = file.Extension.ToString() });
                    });
                }
            }
        }

         public async Task GetTos()
        {
            foreach (var item in GetAllCommentOutputModel?.Result?.Items)
            {   
                 if(item.To != null)
                  {
                item.Tos = JsonSerializer.Deserialize<List<string>>(item.To);
                  }
            }
        }

        public async Task GetCCs()
        {
            foreach (var item in GetAllCommentOutputModel?.Result?.Items)
            {   
                  if(item.CC != null)
                  {
                    item.CCs = JsonSerializer.Deserialize<List<string>>(item.CC);
                  }
            }
        }
        public async Task AddComment(CommentModel input, Guid? parentId)
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
            input.To = JsonSerializer.Serialize(input.Tos);
            input.CC = JsonSerializer.Serialize(input.CCs); 
            await _commentService.CreateComment(input);
            GetAllCommentOutputModel = await _commentService.GetAllComment(RootId, PageName, null, null, 100);
            await GetTos();
            await GetCCs();
            await GetUploadedFiles();

           
            await ClearAll();
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
