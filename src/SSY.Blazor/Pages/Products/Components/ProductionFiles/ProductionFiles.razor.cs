using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace SSY.Blazor.Pages.Products.Components.ProductionFiles
{
    public partial class ProductionFiles
    {
        public ProductionFiles()
        {
        }

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

        #region Services

        public ProductService _productService { get; set; }
        public MediaFileService _mediaFileService { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public ProductModel ProductModel { get; set; } = new();

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public int CategoryId { get; set; }

        #endregion

        #region Models



        #endregion

        #region UI Usage

        private long maxFileSize = 1024 * 5000;

        private string TechDesign2d = "";
        private string SizeSpecs = "";
        private string ObjFiles = "";
        private string Patterns = "";
        private string TechDesign3d = "";
        private string Workmanship = "";

        private Guid TechDesign2dId = Guid.Empty;
        private Guid SizeSpecsId = Guid.Empty;
        private Guid ObjFilesId = Guid.Empty;
        private Guid PatternsId = Guid.Empty;
        private Guid TechDesign3dId = Guid.Empty;
        private Guid WorkmanshipId = Guid.Empty;


        #endregion

        protected override async Task OnInitializedAsync()
        {
            _productService = new(js, ClientFactory, NavigationManager, Configuration);
            _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (ProductModel.ProductMediaFiles.Any())
            {
                ProductModel.ProductMediaFiles.ForEach(x =>
                {
                    var mediaFile = x.MediaFile;

                    if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "2D Technical Design Board")
                    {
                        TechDesign2d = mediaFile.FileName;
                        TechDesign2dId = mediaFile.Id;
                    }

                    if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Size Specs")
                    {
                        SizeSpecs = mediaFile.FileName;
                        SizeSpecsId = mediaFile.Id;
                    }

                    if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Obj Files")
                    {
                        ObjFiles = mediaFile.FileName;
                        ObjFilesId = mediaFile.Id;
                    }

                    if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Patterns")
                    {
                        Patterns = mediaFile.FileName;
                        PatternsId = mediaFile.Id;
                    }
                        

                    if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "3D Technical Design Board")
                    {
                        TechDesign3d = mediaFile.FileName;
                        TechDesign3dId = mediaFile.Id;
                    }
                        

                    if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Workmanship Guide")
                    {
                        Workmanship = mediaFile.FileName;
                        WorkmanshipId = mediaFile.Id;
                    }

                });
            }
        }

        private async Task UploadFile(InputFileChangeEventArgs e,string name)
        {
            try
            {
                IBrowserFile dataFile = e.File;
                CreateMediaFileModel mediaFile = new();

                //create file directory if the directory do not exist
                if (!Directory.Exists($@"../SSY.Content/Uploads/Products/{ProductModel.Id}/Production Files/{name}/"))
                {
                    Directory.CreateDirectory($@"../SSY.Content/Uploads/Products/{ProductModel.Id}/Production Files/{name}/");
                }

                Stream stream = dataFile.OpenReadStream(maxFileSize);
                var path = $@"../SSY.Content/Uploads/Products/{ProductModel.Id}/Production Files/{name}/{dataFile.Name}";
                // var fullPath = $@"{env.WebRootPath}/Uploads/Products/{ProductModel.Id}/Production Files-{CategoryId}/{name}/{dataFile.Name}";
                FileStream fs = File.Create(path);
                await stream.CopyToAsync(fs);
                fs.Close();
                if (name == "2D Technical Design Board") TechDesign2d = dataFile.Name ;
                if (name == "Size Specs") SizeSpecs = dataFile.Name ;
                if (name == "Obj Files") ObjFiles = dataFile.Name ;
                if (name == "Patterns") Patterns = dataFile.Name ;
                if (name == "3D Technical Design Board") TechDesign3d = dataFile.Name ;
                if (name == "Workmanship Guide") Workmanship = dataFile.Name ;


                mediaFile.TenantId = null;
                mediaFile.FilePath = path;
                mediaFile.Name = name;
                mediaFile.FileName = dataFile.Name;
                mediaFile.StorageFileName = dataFile.Name;
                mediaFile.ContentType = dataFile.ContentType;
                mediaFile.ContentDisposition = "";
                mediaFile.CategoryId = CategoryId;
                mediaFile.MediaFileType = 1;

                var uploadFile = await _mediaFileService.CreateProductMediaFile(mediaFile);

                Console.WriteLine(JsonSerializer.Serialize(uploadFile));

                // ProductModel.ProductMediaFileIds.Add(new MediaFilesIds()
                // {
                //     MediaFileId = uploadFile.Id
                // });

                ProductModel.ProductMediaFiles.Add(new ProductMediaFiles()
                {
                    MediaFile = uploadFile,
                    MediaFileId = uploadFile.Id
                });

                // Console.WriteLine(JsonSerializer.Serialize(ProductModel.ProductMediaFiles));
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }

        }

        private async Task OnDelete(Guid id,string name)
        {
            try
            {
                if (name == "2D Technical Design Board") TechDesign2d = "";
                if (name == "Size Specs") SizeSpecs = "";
                if (name == "Obj Files") ObjFiles = "";
                if (name == "Patterns") Patterns = "";
                if (name == "3D Technical Design Board") TechDesign3d = "";
                if (name == "Workmanship Guide") Workmanship = "";

                
                // ProductModel.ProductMediaFileIds.Remove(ProductModel.ProductMediaFileIds.FirstOrDefault(x => x.MediaFileId == id));
                ProductModel.ProductMediaFiles.Remove(ProductModel.ProductMediaFiles.FirstOrDefault(x => x.MediaFile.Id == id));

            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }

        }

    }
}