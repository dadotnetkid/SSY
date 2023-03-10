// using System;
// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
// using Microsoft.JSInterop;
// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products;
// using Microsoft.AspNetCore.Components.Forms;
// using SSY.Web.Blazor.Core.Data.MediaFile.Model;
// using SSY.Web.Blazor.Core.Data.MediaFile;
// using System.Text;
// using System.Text.Json;
// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products.RejectionNotes.Model;

// namespace SSY.Web.Blazor.Pages.Products.Components.ProductMediaFile
// {
//     public partial class ProductMediaFile
//     {
//         public ProductMediaFile()
//         {
//         }

//         [Inject]
//         public IWebHostEnvironment env { get; set; }

//         [Inject]
//         public IJSRuntime js { get; set; }
//         [Inject]
//         public IHttpClientFactory ClientFactory { get; set; }
//         [Inject]
//         public NavigationManager NavigationManager { get; set; }
//         [Inject]
//         public IConfiguration Configuration { get; set; }

//         #region Services

//         public ProductService _productService { get; set; }
//         public MediaFileService _mediaFileService { get; set; }

//         #endregion

//         #region Parameters

//         [Parameter]
//         public ProductModel ProductModel { get; set; } = new();

//         [Parameter]
//         public bool IsEditable { get; set; }

//         [Parameter]
//         public string Title { get; set; }

//         [Parameter]
//         public int CategoryId { get; set; }

//         [Parameter]
//         public List<RejectionNoteModel> RejectionNotes { get; set; } = new();

//         [Parameter]
//         public EventCallback<RejectionNoteModel> AddRejection { get; set; } = new();


//         #endregion

//         #region Models

//         public List<RejectionNoteModel> RejectionNotesByCategory { get; set; } = new();
        
//         #endregion

//         #region UI Usage

//         IReadOnlyList<IBrowserFile> selectedFile;

//         private long maxFileSize = 1024 * 5000;

//         private string frontPath = "";
//         private string backPath = "";
//         private string leftPath = "";
//         private string rightPath = "";

//         private Guid frontId = Guid.Empty;
//         private Guid backId = Guid.Empty;
//         private Guid leftId = Guid.Empty;
//         private Guid rightId = Guid.Empty;

//         bool isDisabledApproval = false;
//         bool isHaveDetails = false;

//         #endregion

//         protected override async Task OnInitializedAsync()
//         {
//             _productService = new(js, ClientFactory, NavigationManager, Configuration);
//             _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);
//         }

//         protected override async Task OnParametersSetAsync()
//         {
//             RejectionNotesByCategory = RejectionNotes.FindAll(x => x.MediaFileCategoryId == CategoryId);
//             if (ProductModel.ProductMediaFiles.Any())
//             {                
//                 await SetupMediaFilesLink();
//             }
//         }

//         private async Task SetupMediaFilesLink()
//         {        
//             ProductModel.ProductMediaFiles.ForEach(x =>
//             {
//                 var mediaFile = x.MediaFile;

//                 if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Details")
//                 {
//                     isHaveDetails = true;
//                 }

//                 if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Front")
//                 {
//                     frontPath = mediaFile.FilePath;
//                     frontId = mediaFile.Id;
                    
//                     if(x.InternalIsApproved == true || x.InfluencerIsApproved == true)
//                         isDisabledApproval = true;
//                 }

//                 if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Back")
//                 {
//                     backPath = mediaFile.FilePath;
//                     backId = mediaFile.Id;
//                     if(x.InternalIsApproved == true || x.InfluencerIsApproved == true)
//                         isDisabledApproval = true;
//                 }

//                 if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Left")
//                 {
//                     leftPath = mediaFile.FilePath;
//                     leftId = mediaFile.Id;
//                     if(x.InternalIsApproved == true || x.InfluencerIsApproved == true)
//                         isDisabledApproval = true;
//                 }

//                 if (CategoryId == mediaFile.CategoryId && mediaFile.Name == "Right")
//                 {
//                     rightPath = mediaFile.FilePath;
//                     rightId = mediaFile.Id;
//                     if(x.InternalIsApproved == true || x.InfluencerIsApproved == true)
//                         isDisabledApproval = true;
//                 }

//             });
//         }

//         private async Task UploadFile(InputFileChangeEventArgs e, string name)
//         {
//             try
//             {
//                 IBrowserFile dataFile = e.File;
//                 CreateMediaFileModel mediaFile = new();

//                 //create file directory if the directory do not exist
//                 var directoryPath = $@"{env.WebRootPath}/Uploads/Products/{ProductModel.Id}/{Title}-{CategoryId}/{name}/";
//                 if (!Directory.Exists(directoryPath))
//                 {
//                     Directory.CreateDirectory(directoryPath);
//                 }

//                 Stream stream = dataFile.OpenReadStream(maxFileSize);
//                 var path = $@"/Uploads/Products/{ProductModel.Id}/{Title}-{CategoryId}/{name}/{dataFile.Name}";
//                 var fullPath = $@"{env.WebRootPath}/Uploads/Products/{ProductModel.Id}/{Title}-{CategoryId}/{name}/{dataFile.Name}";
//                 FileStream fs = File.Create(fullPath);
//                 await stream.CopyToAsync(fs);
//                 fs.Close();

//                 if (name == "Front") frontPath = path;
//                 if (name == "Back") backPath = path;
//                 if (name == "Left") leftPath = path;
//                 if (name == "Right") rightPath = path;

//                 mediaFile.TenantId = null;
//                 mediaFile.FilePath = path;
//                 mediaFile.Name = name;
//                 mediaFile.FileName = dataFile.Name;
//                 mediaFile.StorageFileName = dataFile.Name;
//                 mediaFile.ContentType = dataFile.ContentType;
//                 mediaFile.ContentDisposition = "";
//                 mediaFile.CategoryId = CategoryId;
//                 mediaFile.MediaFileType = 1;

//                 var uploadFile = await _mediaFileService.CreateProductMediaFile(mediaFile);

//                 if (name == "Front") frontId = uploadFile.Id;
//                 if (name == "Back") backId = uploadFile.Id;
//                 if (name == "Left") leftId = uploadFile.Id;
//                 if (name == "Right") rightId = uploadFile.Id;

//                 // Console.WriteLine(JsonSerializer.Serialize(uploadFile));

//                 // ProductModel.ProductMediaFileIds.Add(new MediaFilesIds()
//                 // {
//                 //     MediaFileId = uploadFile.Id
//                 // });

//                 ProductModel.ProductMediaFiles.Add(new ProductMediaFiles()
//                 {
//                     MediaFile = uploadFile,
//                     MediaFileId = uploadFile.Id
//                 });

//                 // Console.WriteLine(JsonSerializer.Serialize(ProductModel.ProductMediaFiles));
//             }
//             catch (Exception ex)
//             {
//                 string innerException = string.Empty;
//                 if (ex.InnerException != null)
//                     innerException = $"\nInnerException:{ex.InnerException.Message}";

//                 Console.WriteLine($"Error: {ex.Message}{innerException}");
//                 await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
//             }

//         }

//         private async Task UploadMultipleFile(InputFileChangeEventArgs e,string name)
//         {
//             try
//             {
//                 List<CreateMediaFileModel> mediaFiles = new();

//                 //create file directory if the directory do not exist
//                 var directoryPath = $@"{env.WebRootPath}/Uploads/Products/{ProductModel.Id}/{Title}-{CategoryId}/{name}/";
//                 if (!Directory.Exists(directoryPath))
//                 {
//                     Directory.CreateDirectory(directoryPath);
//                 }

//                 var dataFiles = e.GetMultipleFiles();
//                 selectedFile = dataFiles;

//                 foreach (var file in selectedFile)
//                 {
//                     Stream stream = file.OpenReadStream(maxFileSize);
//                     var path = $@"/Uploads/Products/{ProductModel.Id}/{Title}-{CategoryId}/{name}/{file.Name}";
//                     var fullPath = $@"{env.WebRootPath}/Uploads/Products/{ProductModel.Id}/{Title}-{CategoryId}/{name}/{file.Name}";
//                     FileStream fs = File.Create(fullPath);
//                     await stream.CopyToAsync(fs);
//                     fs.Close();

//                     mediaFiles.Add(new CreateMediaFileModel()
//                     {
//                         TenantId = null,
//                         FilePath = path,
//                         Name = name,
//                         FileName = file.Name,
//                         StorageFileName = file.Name,
//                         ContentType = file.ContentType,
//                         ContentDisposition = "",
//                         CategoryId = CategoryId,
//                         MediaFileType = 1
//                     });
//                 }

//                 var newMediaFiles = await _mediaFileService.CreateListMediaFileProduct(mediaFiles);
//                 // Console.WriteLine(JsonSerializer.Serialize("newMediaFiles"));
//                 // Console.WriteLine(JsonSerializer.Serialize(newMediaFiles));

//                 foreach (var media in newMediaFiles)
//                 {
//                     ProductModel.ProductMediaFiles.Add(new ProductMediaFiles()
//                     {
//                         MediaFile = media,
//                         MediaFileId = media.Id
//                     });
//                 }

//             }
//             catch (Exception ex)
//             {
//                 string innerException = string.Empty;
//                 if (ex.InnerException != null)
//                     innerException = $"\nInnerException:{ex.InnerException.Message}";

//                 Console.WriteLine($"Error: {ex.Message}{innerException}");
//                 await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
//             }

//         }

//         private async Task OnDelete(Guid id, string name)
//         {
//             try
//             {
//                 if (name == "Front") frontPath = "";
//                 if (name == "Back") backPath = "";
//                 if (name == "Left") leftPath = "";
//                 if (name == "Right") rightPath = "";

//                 // ProductModel.ProductMediaFileIds.Remove(ProductModel.ProductMediaFileIds.FirstOrDefault(x => x.MediaFileId == id));
//                 ProductModel.ProductMediaFiles.Remove(ProductModel.ProductMediaFiles.FirstOrDefault(x => x.MediaFile.Id == id));

//             }
//             catch (Exception ex)
//             {
//                 string innerException = string.Empty;
//                 if (ex.InnerException != null)
//                     innerException = $"\nInnerException:{ex.InnerException.Message}";

//                 Console.WriteLine($"Error: {ex.Message}{innerException}");
//                 await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
//             }

//         }

//         public async Task ClearMediaFileById(List<ProductMediaFiles> ProductMediaFilesByCategory)
//         {
//             try
//             {
//                 ProductMediaFilesByCategory.ForEach(x => {
//                     ProductModel.ProductMediaFiles.Remove(ProductModel.ProductMediaFiles.FirstOrDefault(y => y.MediaFileId == x.MediaFileId));
//                 });
//                 frontPath = "";
//                 backPath = "";
//                 leftPath = "";
//                 rightPath = "";
//                 StateHasChanged();
//             }
//             catch (Exception ex)
//             {
//                 string innerException = string.Empty;
//                 if (ex.InnerException != null)
//                     innerException = $"\nInnerException:{ex.InnerException.Message}";

//                 Console.WriteLine($"Error: {ex.Message}{innerException}");
//                 await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
//             }
//         }

//         public async Task AddRejectionNote(RejectionNoteModel note)
//         {
//             try
//             {
//                 await AddRejection.InvokeAsync(note);
//                 StateHasChanged();
//             }
//             catch (Exception ex)
//             {
//                 string innerException = string.Empty;
//                 if (ex.InnerException != null)
//                     innerException = $"\nInnerException:{ex.InnerException.Message}";

//                 Console.WriteLine($"Error: {ex.Message}{innerException}");
//                 await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
//             }
//         }

//     }
// }