

namespace SSY.Blazor.Pages.Products.Components.ProductOption.Component.ParentDropdown
{
    public partial class ParentDropdown
    {
        public ParentDropdown()
        {
        }

        #region Services
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        #endregion

        #region Parameters

        [Parameter]
        public Guid ProductId { get; set; }

        [Parameter]
        public int ProductTypeId { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public List<OptionModel> OptionListModel { get; set; } = new();

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<PanelModel> Panels { get; set; } = new ();

        [Parameter]
        public List<ProductOptionModel> ProductOptions { get; set; } = new ();

        [Parameter]
        public List<int> SelectedIds  { get; set; } = new ();

        [Parameter]
        public Guid ProductParentId { get; set; }

        [Parameter]
        public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public MaterialListModel MaterialListModel { get; set; } = new() { Materials = new() };

        [Parameter]
        public List<Guid> ProductOptionRollIds { get; set; } = new ();

        [Parameter]
        public EventCallback<Guid> UpdateProductOptionRollIds { get; set; }

        #endregion

        #region Models
        public OptionModel SelectedProductOption { get; set; } = new () {OptionOptions = new()};

        [Parameter]
        public double ForecastQuantity { get; set; } = new ();

        #endregion


        #region 

        public int SelectedOption { get; set; }

        #endregion

        protected override async Task OnInitializedAsync()
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            if(SelectedIds.Any()){
                OptionListModel?.ForEach( x => {
                    if( SelectedIds.Contains(x.Id)){
                        SelectedOption = x.Id;
                        SelectedProductOption = x;
                    } 
                });
            }
        }

        // public async Task ClearChildIds(){

        // }

        public async Task OnClickDropdown(string id)
        {
            try
            {
                var optionId = int.Parse(id);

                // OptionListModel.FirstOrDefault(x => x.Id == optionId);

                // Console.WriteLine(JsonSerializer.Serialize(OptionListModel.FirstOrDefault(x => x.Id == optionId)));
                var option = OptionListModel.FirstOrDefault(x => x.Id == optionId);

                // loop all option list to remove selected option on dropdown
                OptionListModel.ForEach(async o =>
                {
                    await ClearPanelMapping(o.Id);
                    ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == o.Id));
                    SelectedIds.Remove(o.Id);
                    if(o.OptionOptions.Any()){
                        // Console.WriteLine(JsonSerializer.Serialize(o.OptionOptions.Any()));
                        foreach (var childOption1 in o.OptionOptions)
                        {
                            await ClearPanelMapping(childOption1.Id);
                            ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == childOption1.Id));
                            SelectedIds.Remove(childOption1.Id);
                            // Console.WriteLine(JsonSerializer.Serialize(childOption1.OptionOptions.Any()));
                            if(childOption1.OptionOptions.Any()){
                                foreach (var childOption2 in childOption1.OptionOptions)
                                {
                                    await ClearPanelMapping(childOption2.Id);
                                    ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == childOption2.Id));
                                    SelectedIds.Remove(childOption2.Id);
                                    // Console.WriteLine(JsonSerializer.Serialize(childOption2.OptionOptions.Any()));
                                    if(childOption2.OptionOptions.Any()){
                                        foreach (var childOption3 in childOption2.OptionOptions)
                                        {
                                            await ClearPanelMapping(childOption3.Id);
                                            ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == childOption3.Id));
                                            SelectedIds.Remove(childOption3.Id);
                                            // Console.WriteLine(JsonSerializer.Serialize(childOption3.OptionOptions.Any()));
                                        }
                                    }
                                }
                            }
                        }
                    }
                });


                ProductOptionModel ProductOption = new ();
                ProductOption.OptionId = optionId;
                ProductOption.ProductId = ProductId;
                ProductOptions.Add(ProductOption);
                SelectedIds.Add(optionId);

                SelectedProductOption = option;

                // Console.WriteLine(JsonSerializer.Serialize(SelectedIds));
                // Console.WriteLine(JsonSerializer.Serialize(SelectedProductOption.OptionOptions.Any()));
                // Console.WriteLine(JsonSerializer.Serialize(SelectedProductOption.OptionOptions));

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

        private async Task ClearPanelMapping(int optionId)
        {
            var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == optionId);

            if (productOption != null)
            {
                if (!string.IsNullOrWhiteSpace(productOption.RollIds))
                {
                    var rollIds = JsonSerializer.Deserialize<List<Guid>>(productOption.RollIds);
                    foreach (var rollId in rollIds)
                    {
                        if (ProductOptionRollIds.Contains(rollId))
                        {
                            await UpdateProductOptionRollIds.InvokeAsync(rollId);
                        }
                    }
                }

                productOption.RollIds = "";
                productOption.RollNames = "";
                productOption.MaterialId = null;
                productOption.MaterialName = "";
            }
        }

    }
}

