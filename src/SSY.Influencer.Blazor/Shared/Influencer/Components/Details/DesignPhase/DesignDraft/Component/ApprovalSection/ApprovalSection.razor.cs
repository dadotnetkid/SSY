// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Microsoft.JSInterop;
// using Microsoft.AspNetCore.Components.Forms;

// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products;
// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products.Model;
// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products.RejectionNotes.Model;
// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products.RejectionNotes;
// using SSY.Web.Blazor.Core.Data.Users.Model;
// using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Products.Dto;
// using SSY.Web.Blazor.Core.Data.MediaFile.Model;


// namespace SSY.Web.Blazor.Pages.Products.Components.ProductMediaFile.Components.ApprovalSection
// {
//     public partial class ApprovalSection
//     {
//         #region Injections

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
//         [Inject]
//         public ProtectedLocalStorage LocalStorage { get; set; }
//         public RejectionNoteService _rejectionNoteService { get; set; }
//         public ProductService _productService { get; set; }

//         #endregion

//         #region Parameters

//         [CascadingParameter(Name = "ModuleType")]
//         private string ModuleType { get; set; }

//         [Parameter]
//         public Guid ProductId { get; set; }

//         [Parameter]
//         public List<ProductMediaFiles> ProductMediaFiles { get; set; }

//         [Parameter]
//         public List<RejectionNoteModel> RejectionNotes { get; set; } = new();

//         [Parameter]
//         public int CategoryId { get; set; }

//         [Parameter]
//         public EventCallback<List<ProductMediaFiles>> OnRejection { get; set; } = new();

//         [Parameter]
//         public EventCallback<RejectionNoteModel> AddRejection { get; set; } = new();


//         #endregion

//         #region Models

//         public List<string> UploadedFiles { get; set; } = new();
//         public List<ProductMediaFiles> ProductMediaFilesByCategory { get; set; } = new ();
//         public List<RejectionNoteModel> RejectionNotesByCategory { get; set; } = new();
//         public List<RejectionNoteModel> FilteredRejectionNotes { get; set; } = new();

//         Guid uniqueModalId = Guid.NewGuid();

        
//         #endregion


//         #region Approval Images

//         bool? isInternalApproved = null;
//         bool? isInfluencerApproved = null;

//         bool isInternalComment = false;

//         bool isDisabledInternalRadio = false;
//         bool isDisabledInfluencerRadio = false;

//         public string UserName = "";

//         public string internalNotes = "";
//         public string influencerNotes = "";
//         public string RejectionNoteComment = "";

//         #endregion

//         #region ImagesUploading

//         IReadOnlyList<IBrowserFile> selectedFile;
//         private long maxFileSize = long.MaxValue;
//         private int maxAllowedFiles = 10;
//         public string Files = "";
//         public string button = "";
//         public string HideElements = "True";
//         public string modal = "";
//         public string approveModal = "";
//         public string approveBackModal = string.Empty;
//         public string name = "1st Design Draft";

//         #endregion
//         protected override async Task OnInitializedAsync()
//         {
//             _productService = new(js, ClientFactory, NavigationManager, Configuration);
//             _rejectionNoteService = new(js, ClientFactory, NavigationManager, Configuration);
//         }

//         protected override async Task OnAfterRenderAsync(bool firstRender)
//         {
//             var session = await LocalStorage.GetAsync<UserSession>("userSession");
//             UserName = session.Value.FullName;
//         }

//         protected override async Task OnParametersSetAsync()
//         {
//             RejectionNotesByCategory = RejectionNotes.FindAll(x => x.MediaFileCategoryId == CategoryId);
            

//             if(RejectionNotesByCategory.Any()){
//                 RejectionNotesByCategory = RejectionNotesByCategory.OrderBy(x => x.creationTime).ToList();
               
//                 var RejectionNotesByInternal = RejectionNotesByCategory.FindAll(x => x.IsInternal == true);
//                 var RejectionNotesByInfluencer = RejectionNotesByCategory.FindAll(x => x.IsInternal == false);
//                 internalNotes = RejectionNotesByInternal.LastOrDefault()?.Notes;
//                 influencerNotes = RejectionNotesByInfluencer.LastOrDefault()?.Notes;
                
//             }
//             if (ProductMediaFiles.Any())
//             {
//                 ProductMediaFilesByCategory = ProductMediaFiles.FindAll(x => x.MediaFile.CategoryId == CategoryId);
                
//                 if(ProductMediaFilesByCategory.FirstOrDefault()?.InternalIsApproved != null)
//                     isDisabledInternalRadio = true;

//                 isInternalApproved = ProductMediaFilesByCategory.FirstOrDefault()?.InternalIsApproved;

//                 if(ProductMediaFilesByCategory.FirstOrDefault()?.InfluencerIsApproved != null)
//                     isDisabledInfluencerRadio = true;

//                 isInfluencerApproved = ProductMediaFilesByCategory.FirstOrDefault()?.InfluencerIsApproved;

//                 // Console.WriteLine(JsonSerializer.Serialize("kelvin " + CategoryId));
//                 // Console.WriteLine(JsonSerializer.Serialize(ProductMediaFilesByCategory));
//                 // Console.WriteLine(JsonSerializer.Serialize(CategoryId));
//                 // Console.WriteLine(JsonSerializer.Serialize(CategoryId));
//                 // Console.WriteLine(JsonSerializer.Serialize(RejectionNotesByCategory));
//             }
//         }

//         public async Task onChangeApprove(bool input, string type)
//         {
//             if(type == "internal") isInternalApproved = input;
//             if(type == "influencer") isInfluencerApproved = input;
//             internalNotes = "";
//             influencerNotes = "";
//         }

//         public async Task onApproveInternal()
//         {
//             try
//             {
//                 MediaFileApprovalDto approvalData = new();

//                 approvalData.ProductId = ProductId;
//                 approvalData.MediaFileCategoryId = CategoryId;
//                 approvalData.ApprovedBy = UserName;

//                 var approval = await _productService.InternalApproval(approvalData);

//                 if(approval){
//                     ProductMediaFilesByCategory.ForEach(x => {
//                         x.InternalIsApproved = true;
//                         x.InternalIsApprovedDateTime = DateTime.Now;
//                         x.InternalApprovedBy = UserName;
//                     });
//                     isDisabledInternalRadio = true;
//                     isInternalApproved = true;
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

//         public async Task onRejectInternal()
//         {
//             try
//             {
//                 MediaFileRejectionDto rejectionData = new() { MediaFiles = new ()};
//                 List<RejectionNoteMediaFile> rejectionNoteMediaFile = new();
//                 RejectionNoteModel note = new();

//                 rejectionData.ProductId = ProductId;
//                 rejectionData.MediaFileCategoryId = CategoryId;
//                 rejectionData.UserName = UserName;
//                 rejectionData.Notes = internalNotes;
//                 rejectionData.IsInternal = true;

//                 ProductMediaFilesByCategory.ForEach(x => {
//                     rejectionData.MediaFiles.Add(new MediaFilesDto(){
//                         TenantId = null,
//                         IsActive = true,
//                         MediaFileId = x.MediaFile.Id
//                     });
//                     rejectionNoteMediaFile.Add( new RejectionNoteMediaFile() {
//                         MediaFile = x.MediaFile
//                     });
//                 });

//                 var rejection = await _productService.InternalRejection(rejectionData);

//                 if(rejection){
//                     await OnRejection.InvokeAsync(ProductMediaFilesByCategory);

//                     ProductMediaFilesByCategory.Clear();

//                     note.ProductId = ProductId;
//                     note.Notes = rejectionData.Notes;
//                     note.IsInternal = true;
//                     note.UserName = UserName;
//                     note.creationTime = DateTime.Now;
//                     note.MediaFileCategoryId = CategoryId;
//                     note.MediaFiles = rejectionNoteMediaFile;

//                     await AddRejection.InvokeAsync(note);

//                     var RejectionNotesByInternal= RejectionNotesByCategory.FindAll(x => x.IsInternal == true);
//                     internalNotes = RejectionNotesByInternal.FirstOrDefault()?.Notes;
//                     isInternalApproved = null;
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

//         public async Task onApproveInfluencer()
//         {
//             try
//             {
//                 MediaFileApprovalDto approvalData = new();

//                 approvalData.ProductId = ProductId;
//                 approvalData.MediaFileCategoryId = CategoryId;
//                 approvalData.ApprovedBy = UserName;

//                 var approval = await _productService.InfluencerApproval(approvalData);

//                 if(approval){
//                     ProductMediaFilesByCategory.ForEach(x => {
//                         x.InfluencerIsApproved = true;
//                         x.InfluencerIsApprovedDateTime = DateTime.Now;
//                         x.InfluencerApprovedBy = UserName;
//                     });
//                     isDisabledInfluencerRadio = true;
//                     isInfluencerApproved = true;
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

//         public async Task onRejectInfluencer()
//         {
//             try
//             {
//                 MediaFileRejectionDto rejectionData = new() { MediaFiles = new ()};
//                 List<RejectionNoteMediaFile> rejectionNoteMediaFile = new();
//                 RejectionNoteModel note = new();

//                 rejectionData.ProductId = ProductId;
//                 rejectionData.MediaFileCategoryId = CategoryId;
//                 rejectionData.UserName = UserName;
//                 rejectionData.Notes = influencerNotes;
//                 rejectionData.IsInternal = false;

//                 ProductMediaFilesByCategory.ForEach(x => {
//                     rejectionData.MediaFiles.Add(new MediaFilesDto(){
//                         TenantId = null,
//                         IsActive = true,
//                         MediaFileId = x.MediaFile.Id
//                     });
//                     rejectionNoteMediaFile.Add( new RejectionNoteMediaFile() {
//                         MediaFile = x.MediaFile
//                     });
//                 });

//                 var rejection = await _productService.InfluencerRejection(rejectionData);

//                 if(rejection){
//                     await OnRejection.InvokeAsync(ProductMediaFilesByCategory);

//                     ProductMediaFilesByCategory.Clear();

//                     note.ProductId = ProductId;
//                     note.Notes = rejectionData.Notes;
//                     note.IsInternal = false;
//                     note.UserName = UserName;
//                     note.creationTime = DateTime.Now;
//                     note.MediaFileCategoryId = CategoryId;
//                     note.MediaFiles = rejectionNoteMediaFile;

//                     await AddRejection.InvokeAsync(note);

//                     var RejectionNotesByInfluencer = RejectionNotesByCategory.FindAll(x => x.IsInternal == false);
//                     influencerNotes = RejectionNotesByInfluencer.FirstOrDefault()?.Notes;
//                     isInfluencerApproved = null;
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

//         public async Task FilterRejectionNotes(bool isInternal)
//         {
//             try
//             {
//                 FilteredRejectionNotes = RejectionNotesByCategory.FindAll(x => x.IsInternal == isInternal);
//                 isInternalComment = isInternal;
//                 Console.WriteLine(JsonSerializer.Serialize(isInternal));
//                 Console.WriteLine(JsonSerializer.Serialize(FilteredRejectionNotes));
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

//         public async Task OnChangeNote(string note)
//         {
//             try
//             {
//                 RejectionNoteComment = note;
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

//         public async Task AddRejectionComment()
//         {
//             try
//             {
//                 MediaFileRejectionDto rejectionData = new() { MediaFiles = new ()};
//                 List<RejectionNoteMediaFile> rejectionNoteMediaFile = new();
//                 RejectionNoteModel note = new();

//                 rejectionData.ProductId = ProductId;
//                 rejectionData.MediaFileCategoryId = CategoryId;
//                 rejectionData.UserName = UserName;
//                 rejectionData.Notes = RejectionNoteComment;
//                 rejectionData.IsInternal = isInternalComment;

//                 // // Console.WriteLine(JsonSerializer.Serialize(rejectionData));
//                 var rejection = await _productService.AddRejectionComment(rejectionData);
//                 RejectionNoteComment = "";
//                 if(rejection){

//                     note.ProductId = ProductId;
//                     note.Notes = rejectionData.Notes;
//                     note.IsInternal = isInternalComment;
//                     note.UserName = UserName;
//                     note.creationTime = DateTime.Now;
//                     note.MediaFileCategoryId = CategoryId;
//                     note.MediaFiles = rejectionNoteMediaFile;

//                     await AddRejection.InvokeAsync(note);

//                     RejectionNotesByCategory = RejectionNotesByCategory.OrderBy(x => x.creationTime).ToList();
//                     FilteredRejectionNotes = RejectionNotesByCategory.FindAll(x => x.IsInternal == isInternalComment);
                    
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
//     }
// }