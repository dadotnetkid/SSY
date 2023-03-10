using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.Administration.Users.Model;
using SSY.Blazor.HttpClients.Data.Inventory.FinalSelectionList;
using SSY.Blazor.HttpClients.Data.Inventory.FinalSelectionList.Model;

namespace SSY.Blazor.Pages.Supplier.Components.FinalSelection
{
    public partial class FinalSelection
    {
        #region Injections

        [Inject]
        public IWebHostEnvironment env { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private MaterialService _materialService { get; set; }
        private FinalSelectionListService _finalSelectionListService { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }
        private MediaFileService _mediaFileService { get; set; }

        #endregion

        #region Models
        public FinalSelectionListModel FinalSelectionListModel { get; set; } = new();

        private IEnumerable<FinalSelectionListModel> _finalSelectionList { get; set; }
        public List<Guid> FinalSelectionListIds { get; set; } = new();
        private MaterialModel _selectedMaterial;
        [Parameter]
        public int Id { get; set; }
        public GetAllFinalSelectionListOutputModel GetAllFinalSelectionListOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        List<string> multipleSelectionData = new();
        public List<string> UploadedFiles { get; set; } = new();

        #endregion
        private string customFilterValue;

        private List<IBrowserFile> loadedFiles = new();
        //IReadOnlyList<IBrowserFile> selectedFile;
        IBrowserFile selectedFile;
        private long maxFileSize = 1024 * 5000;
        private int maxAllowedFiles = 10;
        private bool isLoading;
        private string origFiles;
        string labelText = "";
        string classAlert = "";

        public string UserName = "";
        public bool IsAdmin = false;
        public UserSession UserSession { get; set; } = new();

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _finalSelectionListService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var response = await _finalSelectionListService.GetAllFinalSelectionList(null, Id, null, null, 100);
                _finalSelectionList = response.Result.Items;
                await GetUploadedFiles();

            }
            StateHasChanged();
        }

        public async Task GetUploadedFiles()
        {
            foreach (var item in _finalSelectionList)
            {
                item.Name = "Final Selection List - " + item.CreationTime.ToString("MMMM d, yyyy hh:mm tt");
                //for local testing
                item.MediaFile.FilePath = "../../../abpCore/aspnet-core/src/" + item.MediaFile.FilePath;
                Console.WriteLine(item.MediaFile.FilePath);
                Console.WriteLine("item.MediaFile.FilePath");
            }
        }

        private bool OnCustomFilter(FinalSelectionListModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }
        public async Task AddFinalSelectionList()
        {
            try
            {
                var session = await LocalStorage.GetAsync<UserSession>("userSession");
                if (selectedFile != null)
                {

                    //// web server  path (do not delete)
                    if (!Directory.Exists("../SSY.Content/Uploads/Companies/" + Id + "/FinalSelection/"))
                    {
                        Directory.CreateDirectory("../SSY.Content/Uploads/Companies/" + Id + "/FinalSelection/");
                    }

                    // local development path (do not delete)(for s3 bucket intergration)
                    //if (!Directory.Exists("../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/" + Id + "/FinalSelection/"))
                    //{
                    //    Directory.CreateDirectory("../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/" + Id + "/FinalSelection/");
                    //}

                    Stream stream = selectedFile.OpenReadStream(maxFileSize);

                    // web server  path (do not delete)
                    var path = $@"../SSY.Content/Uploads/Companies/{Id}/FinalSelection/{selectedFile.Name}";

                    // local development path (do not delete)(for s3 bucket intergration)
                    //var path = $@"../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/{Id}/FinalSelection/{selectedFile.Name}";

                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    fs.Close();
                    FinalSelectionListModel.MediaFile.FilePath = $@"SSY.Content/Uploads/Companies/{Id}/FinalSelection/{selectedFile.Name}";
                    FinalSelectionListModel.MediaFile.Name = selectedFile.Name;
                    FinalSelectionListModel.MediaFile.FileName = selectedFile.Name;
                    FinalSelectionListModel.MediaFile.StorageFileName = selectedFile.Name;
                    FinalSelectionListModel.MediaFile.ContentType = selectedFile.ContentType;
                    FinalSelectionListModel.MediaFile.ContentDisposition = "";
                    FinalSelectionListModel.CompanyId = Id;
                    FinalSelectionListModel.AddedBy = session.Value.FullName;

                    await _finalSelectionListService.CreateFinalSelectionList(FinalSelectionListModel);
                    var response = await _finalSelectionListService.GetAllFinalSelectionList(null, Id, null, null, 100);
                    _finalSelectionList = response.Result.Items;
                    await GetUploadedFiles();

                }
                else
                {
                    labelText = "Please Insert your File";
                    classAlert = "Failed";
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }

        }

        private async Task DownloadFileFromURL(string url, string name)
        {
            await js.InvokeVoidAsync("triggerFileDownload", name, url);
        }

        public async Task DeleteSelectedIds(Guid id)
        {
            var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "FinalSelectionList");

            var response = await _finalSelectionListService.GetAllFinalSelectionList(null, Id, null, null, 100);
            _finalSelectionList = response.Result.Items;
            await GetUploadedFiles();
            FinalSelectionListIds.Clear();
        }

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var dataFiles = e.File;
            selectedFile = dataFiles;
            var format = "all";
            var resizedImageFiles = await dataFiles.RequestImageFileAsync(format, 100, 100);
            var buffer = new byte[resizedImageFiles.Size];
            await resizedImageFiles.OpenReadStream().ReadAsync(buffer);
            var imageDataUrl = $"data: {format}; base64,{Convert.ToBase64String(buffer)}";
            this.StateHasChanged();

        }

        private async Task FileDownload(Guid id, string contentType, string fileName)
        {
            string base64 = await _mediaFileService.FileDownload(id);
            await js.InvokeVoidAsync("DownloadFromBase64", fileName, contentType, base64);

            Console.WriteLine(base64);
        }
    }

}