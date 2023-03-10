using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.Administration.Users.Model;
using SSY.Blazor.HttpClients.Data.Inventory.SwatchList;
using SSY.Blazor.HttpClients.Data.Inventory.SwatchList.Model;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

namespace SSY.Blazor.Pages.Supplier.Components.RequestSwatches
{
    public partial class RequestSwatches
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
        private SwatchListService _swatchListService { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }
        private MediaFileService _mediaFileService { get; set; }

        #endregion

        #region Models
        public MediaFileModel MediaFileModel { get; set; }
        public SwatchListModel SwatchListModel { get; set; } = new();
        private IEnumerable<MaterialModel> _materials { get; set; }

        private IEnumerable<SwatchListModel> _swatchList { get; set; }
        public List<Guid> RequestSwatchesIds { get; set; } = new();
        private MaterialModel _selectedMaterial;
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public CompanyModel SupplierModel { get; set; } = new();
        public GetAllSwatchListOutputModel GetAllSwatchListOutputModel { get; set; } = new() { Result = new() { Items = new() } };
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
            _swatchListService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var response = await _swatchListService.GetAllSwatchList(null, Id, null, null, 100);
                _swatchList = response.Result.Items;
                await GetUploadedFiles();

            }
            StateHasChanged();
        }

        public async Task GetUploadedFiles()
        {
            foreach (var item in _swatchList)
            {
                item.Name = "Request for Swatches List - " + item.CreationTime.ToString("MMMM d, yyyy hh:mm tt");
                //for local testing
                item.MediaFile.FilePath = "../../../abpCore/aspnet-core/src/" + item.MediaFile.FilePath;
                Console.WriteLine(item.MediaFile.FilePath);
                Console.WriteLine("item.MediaFile.FilePath");
            }
        }

        private bool OnCustomFilter(SwatchListModel model)
        {
            // System.Console.WriteLine(JsonSerializer.Serialize(model));
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task AddSwatchList()
        {
            try
            {
                var session = await LocalStorage.GetAsync<UserSession>("userSession");
                if (selectedFile != null)
                {

                    //// web server  path (do not delete)
                    if (!Directory.Exists("../SSY.Content/Uploads/Companies/" + Id + "/SwatchList/"))
                    {
                        Directory.CreateDirectory("../SSY.Content/Uploads/Companies/" + Id + "/SwatchList/");
                    }

                    // local development path (do not delete)(for s3 bucket intergration)
                    //if (!Directory.Exists("../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/" + Id + "/SwatchList/"))
                    //{
                    //    Directory.CreateDirectory("../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/" + Id + "/SwatchList/");
                    //}

                    Stream stream = selectedFile.OpenReadStream(maxFileSize);

                    // web server  path (do not delete)
                    var path = $@"../SSY.Content/Uploads/Companies/{Id}/SwatchList/{selectedFile.Name}";

                    // local development path (do not delete)(for s3 bucket intergration)
                    //var path = $@"../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/{Id}/SwatchList/{selectedFile.Name}";

                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    fs.Close();
                    SwatchListModel.MediaFile.FilePath = $@"SSY.Content/Uploads/Companies/{Id}/SwatchList/{selectedFile.Name}";
                    SwatchListModel.MediaFile.Name = selectedFile.Name;
                    SwatchListModel.MediaFile.FileName = selectedFile.Name;
                    SwatchListModel.MediaFile.StorageFileName = selectedFile.Name;
                    SwatchListModel.MediaFile.ContentType = selectedFile.ContentType;
                    SwatchListModel.MediaFile.ContentDisposition = "";
                    SwatchListModel.CompanyId = Id;
                    SwatchListModel.AddedBy = session.Value.FullName;

                    await _swatchListService.CreateSwatchList(SwatchListModel);
                    var response = await _swatchListService.GetAllSwatchList(null, Id, null, null, 100);
                    _swatchList = response.Result.Items;
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

        public async Task onChangeReceivedStatus(Guid id)
        {
            System.Console.WriteLine(id);
            await _swatchListService.ChangeReceivedStatusAsync(id);
        }

        public async Task DeleteSelectedIds(Guid id)
        {
            var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "SwatchList");

            var response = await _swatchListService.GetAllSwatchList(null, Id, null, null, 100);
            _swatchList = response.Result.Items;
            await GetUploadedFiles();
            RequestSwatchesIds.Clear();
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