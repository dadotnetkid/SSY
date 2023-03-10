// using Microsoft.AspNetCore.Components;
// using Microsoft.JSInterop;
// using Blazorise.RichTextEdit;


// namespace SSY.Blazor.Pages.Products.Components.ChildProduct.Components.ProductOptionNotes;

// public partial class ProductOptionNotes
// {

//     [Inject]
//     public IJSRuntime js { get; set; }
//     [Inject]
//     public IHttpClientFactory ClientFactory { get; set; }
//     [Inject]
//     public NavigationManager NavigationManager { get; set; }
//     [Inject]
//     public IConfiguration Configuration { get; set; }

//     [Parameter]
//     public ProductModel Product { get; set; }

//     [Parameter]
//     public EventCallback<ProductModel> AddProductOptionNotes { get; set; }

//     [Parameter]
//     public bool IsEditable { get; set; }

//     protected RichTextEdit richTextEditRef;
//     protected bool readOnly = true;
//     protected string contentAsHtml;
//     protected string contentAsDeltaJson;
//     protected string contentAsText;
//     protected string savedContent;

//     string aa = "<p>kelvin</p><p><strong>kelvin 2</strong></p>";

//     protected override async Task OnInitializedAsync()
//     {
//     }

//     protected override async Task OnParametersSetAsync()
//     {

//     }

//      public async Task OnContentChanged()
//     {
//         contentAsHtml = await richTextEditRef.GetHtmlAsync();
//         contentAsDeltaJson = await richTextEditRef.GetDeltaAsync();
//         contentAsText = await richTextEditRef.GetTextAsync();

//         System.Console.WriteLine(contentAsText);
//         System.Console.WriteLine(contentAsDeltaJson);
//         System.Console.WriteLine(contentAsHtml);

//         Product.ProductOptionNotes = contentAsHtml;

//         await AddProductOptionNotes.InvokeAsync(Product);
//     }

//     public async Task OnSave()
//     {
//         savedContent = await richTextEditRef.GetHtmlAsync();
//         await richTextEditRef.ClearAsync();
//     }
// }