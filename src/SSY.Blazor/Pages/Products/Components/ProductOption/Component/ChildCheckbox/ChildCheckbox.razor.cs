namespace SSY.Blazor.Pages.Products.Components.ProductOption.Component.ChildCheckbox
{
    public partial class ChildCheckbox
    {
        public ChildCheckbox()
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
        public List<OptionOptionsModel> OptionListModel { get; set; } = new() { };

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<PanelModel> Panels { get; set; } = new ();

        [Parameter]
        public List<ProductOptionModel> ProductOptions { get; set; } = new ();

        [Parameter]
        public EventCallback<List<ProductOptionModel>> OnChangeCheckbox { get; set; }

        [Parameter]
        public List<int> SelectedIds { get; set; } = new ();

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

        [Parameter]
        public double ForecastQuantity { get; set; } = new ();

        #endregion

        #region Models
        #endregion


        #region ui usage

        public List<int> SelectedParentIds { get; set; } = new();


        #endregion

        protected override async Task OnInitializedAsync()
        {
        }


        protected override async Task OnParametersSetAsync()
        {
            // if(ProductOptions.Any()){
            //     OptionListModel?.ForEach( x => {
            //         if( ProductOptions?.FirstOrDefault(o => o.OptionId == x.Id) != null) SelectedParentIds.Add(x.Id);
            //         if(x.OptionOptions.Any()){
            //             // Console.WriteLine(JsonSerializer.Serialize(x.OptionOptions));
            //             x.OptionOptions.ForEach( option => {
            //                 if( ProductOptions?.FirstOrDefault(o => o.OptionId == option.Id) != null){
            //                     var parentId = (int)option.ParentId;
            //                     if(!SelectedParentIds.Contains(parentId)){
            //                         SelectedParentIds.Add((int)option.ParentId);
            //                     }
            //                 } 
            //             });
            //         }
            //     });
            // }
        }

        public async Task OnClickCheckBox(bool isChecked, int optionId)
        {
            try
            {
                bool hasSelectedChildOption = false;
                // Console.WriteLine(isChecked);
                // Console.WriteLine(optionId);
                // Console.WriteLine(JsonSerializer.Serialize(OptionListModel));
                var option = OptionListModel.FirstOrDefault(x=> x.Id == optionId);

                if(isChecked){
                    ProductOptionModel ProductOption = new ();
                    ProductOption.OptionId = optionId;
                    ProductOption.ProductId = ProductId;
                    ProductOptions.Add(ProductOption);
                    //remove parent Id of child checkbox oncheck
                    ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == option.ParentId));
                    SelectedIds.Add(optionId);
                    hasSelectedChildOption = true;
                }else {
                    // Console.WriteLine(JsonSerializer.Serialize(SelectedParentIds));

                    SelectedIds.Remove(optionId);
                    ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == optionId));

                    // checking if any of the mutli option select if not then set hasSelectedChildOption to default false
                    OptionListModel.ForEach(o =>
                    {
                        Console.WriteLine(JsonSerializer.Serialize(o.Id));
                        if(SelectedIds.Contains(o.Id)){
                            hasSelectedChildOption = true;
                        }
                    });
                    // Console.WriteLine(JsonSerializer.Serialize(SelectedParentIds));
                    // remove all child option selected on or not
                    option.OptionOptions.ForEach(async o =>
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
                }
                // add parent option if no selected child option
                if(!hasSelectedChildOption){
                    ProductOptionModel ProductOption = new ();
                    ProductOption.OptionId = (int)option.ParentId;
                    ProductOption.ProductId = ProductId;
                    ProductOptions.Add(ProductOption);
                }
                Console.WriteLine(JsonSerializer.Serialize(hasSelectedChildOption));
                Console.WriteLine(JsonSerializer.Serialize(SelectedIds));
                StateHasChanged();
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

