using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.Administration.Users.Model;
using SSY.Blazor.HttpClients.Data.Inventory.ExcessList.Model;
using ExcessListModel = SSY.Blazor.HttpClients.Data.Inventory.ExcessList.Model.ExcessListModel;

namespace SSY.Blazor.Pages.Supplier.Components.ExcessList
{
    public partial class ExcessList
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

        private ExcessListService _excessListService { get; set; }
        private MediaFileService _mediaFileService { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }

        public List<Guid> ExcessListIds { get; set; } = new();

        #endregion

        #region Models
        public MediaFileModel MediaFileModel { get; set; }
        public ExcessListModel ExcessListModel { get; set; } = new();
        private IEnumerable<ExcessListModel> _excessList { get; set; }
        [Parameter]
        public int Id { get; set; }
        public List<string> UploadedFiles { get; set; } = new();

        #endregion
        private string customFilterValue;

        IBrowserFile selectedFile;
        private long maxFileSize = 1024 * 5000;
        private int maxAllowedFiles = 10;
        private bool isLoading;
        string labelText = "";
        string classAlert = "";


        public string UserName = "";
        public bool IsAdmin = false;
        public UserSession UserSession { get; set; } = new();

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {

            _excessListService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var session = await LocalStorage.GetAsync<UserSession>("userSession");
            if (firstRender)
            {
                var response = await _excessListService.GetAllExcessList(null, Id, null, null, 100);
                _excessList = response.Result.Items;
                await GetUploadedFiles();
                UserName = session.Value.FullName;
                IsAdmin = session.Value.IsAdmin;

            }
            StateHasChanged();
        }

        public async Task GetUploadedFiles()
        {
            foreach (var item in _excessList)
            {
                item.Name = "Excess List - " + item.CreationTime.ToString("MMMM d, yyyy hh:mm tt");
                //for local testing
                item.MediaFile.FilePath = "../../../abpCore/aspnet-core/src/" + item.MediaFile.FilePath;
                Console.WriteLine(item.MediaFile.FilePath);
                Console.WriteLine("item.MediaFile.FilePath");
            }
        }

        private bool OnCustomFilter(ExcessListModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task AddExcessList()
        {
            try
            {
                var session = await LocalStorage.GetAsync<UserSession>("userSession");
                if (selectedFile != null)
                {

                    // web server  path (do not delete)
                    if (!Directory.Exists("../SSY.Content/Uploads/Companies/" + Id + "/Excess/"))
                    {
                        Directory.CreateDirectory("../SSY.Content/Uploads/Companies/" + Id + "/Excess/");
                    }

                    // local development path (do not delete)(for s3 bucket intergration)
                    //if (!Directory.Exists("../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/" + Id + "/Excess/"))
                    //{
                    //    Directory.CreateDirectory("../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/" + Id + "/Excess/");
                    //}

                    Stream stream = selectedFile.OpenReadStream(maxFileSize);

                    // web server  path (do not delete)
                    var path = $@"../SSY.Content/Uploads/Companies/{Id}/Excess/{selectedFile.Name}";

                    // local development path (do not delete)(for s3 bucket intergration)
                    //var path = $@"../../abpCore/aspnet-core/src/SSY.Content/Uploads/Companies/{Id}/Excess/{selectedFile.Name}";

                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    fs.Close();
                    ExcessListModel.MediaFile.FilePath = $@"SSY.Content/Uploads/Companies/{Id}/Excess/{selectedFile.Name}";
                    ExcessListModel.MediaFile.Name = selectedFile.Name;
                    ExcessListModel.MediaFile.FileName = selectedFile.Name;
                    ExcessListModel.MediaFile.StorageFileName = selectedFile.Name;
                    ExcessListModel.MediaFile.ContentType = selectedFile.ContentType;
                    ExcessListModel.MediaFile.ContentDisposition = "";
                    ExcessListModel.CompanyId = Id;
                    ExcessListModel.AddedBy = session.Value.FullName;

                    await _excessListService.CreateExcessList(ExcessListModel);
                    var response = await _excessListService.GetAllExcessList(null, Id, null, null, 100);
                    _excessList = response.Result.Items;
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

        private async Task FileDownload(Guid id, string contentType, string fileName)
        {
            string base64 =  await _mediaFileService.FileDownload(id);
            await js.InvokeVoidAsync("DownloadFromBase64", fileName, contentType, base64 );

            Console.WriteLine(base64);
        }

        public async Task DeleteSelectedIds(Guid id)
        {
            var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "ExcessList");

            var response = await _excessListService.GetAllExcessList(null, Id, null, null, 100);
            _excessList = response.Result.Items;
            await GetUploadedFiles();
            ExcessListIds.Clear();
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
    }

}