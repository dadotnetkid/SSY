namespace SSY.Blazor.Pages.Products.Components.ProductOption.Component.ChildDropdown
{
    public partial class ChildDropdown
    {
        public ChildDropdown()
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
        public bool IsEditable { get; set; }

        [Parameter]
        public List<OptionOptionsModel> OptionListModel { get; set; } = new();

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<PanelModel> Panels { get; set; } = new ();

        [Parameter]
        public List<ProductOptionModel> ProductOptions { get; set; } = new ();

        [Parameter]
        public int SelectedOption { get; set; } = new();

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

        public OptionOptionsModel SelectedProductOption { get; set; } = new () {OptionOptions = new()};

        public List<RollAndLocationModel> RollsAndLocations { get; set; } = new();
        public IEnumerable<RollAndLocationModel> _rolls;
        private string customRollFilterValue;

        public IEnumerable<MaterialModel> _materials;
        private string customFabricFilterValue;

        public Guid SelectedMaterialId = Guid.Empty;

        #endregion

        #region  ui uisage

        public string SelectMaterialName = "";

        private List<RollAndLocationModel> selectedRolls = new();
        private List<Guid> selectedRollIds = new();
        private List<string> selectedRollNames = new();

        private int UnitOfMeasurementId ;
        private double Consumption;
        public double TestRequirements = 10000;

        

        #endregion

        protected override async Task OnInitializedAsync()
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            _materials = MaterialListModel.Materials;
           Console.WriteLine(JsonSerializer.Serialize("xxxxxx"));
        Console.WriteLine(JsonSerializer.Serialize(ForecastQuantity));

            if(ProductOptions.Any()){
                OptionListModel?.ForEach( x => {
                    if( SelectedIds.Contains(x.Id)){
                        SelectedOption = x.Id;
                        SelectedProductOption = x;
                    } 
                });
                selectedRolls.Clear();
                selectedRollIds.Clear();
                var option = ProductOptions.FirstOrDefault(x=> x.OptionId == SelectedOption);
                if(option != null){
                    if(option.MaterialId != Guid.Empty){
                        var material = MaterialListModel.Materials.FirstOrDefault(x=> x.Id == option.MaterialId);
                        if(material != null){
                            if(!string.IsNullOrWhiteSpace(option.RollIds)){
                                var rollIds = JsonSerializer.Deserialize<List<Guid>>(option.RollIds);
                                rollIds.ForEach(x => {
                                    var roll = material.RollsAndLocations.FirstOrDefault(r=> r.Id == x);
                                    if(roll != null)
                                    {
                                        selectedRolls.Add(roll);
                                        selectedRollIds.Add(roll.Id);
                                    }
                                });
                            }
                            _rolls = material.RollsAndLocations;
                            SelectMaterialName = material.Name;
                            SelectedMaterialId = material.Id;
                        }
                       
                        UnitOfMeasurementId = option.UnitOfMeasurementId != null ? (int)option.UnitOfMeasurementId : 0;
                        Consumption = option.Consumption != null ? (double)option.Consumption : 0;
                    }
                    option.RollIds = JsonSerializer.Serialize(selectedRollIds);
                }

            }
            StateHasChanged();
        }

        public async Task OnClickDropdown(string id)
        {
            try
            {
                var optionId = 0;
                optionId = int.Parse(id);
                var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == SelectedProductOption.Id);

                // clear panel
                if(productOption != null)
                {
                    foreach (var rollId in selectedRollIds)
                    {
                        if(ProductOptionRollIds.Contains(rollId)){
                            await UpdateProductOptionRollIds.InvokeAsync(rollId);
                        }
                    }
                    selectedRolls.Clear();
                    selectedRollIds.Clear();
                    productOption.RollIds = "";
                    productOption.RollNames = "";

                    _rolls = new RollAndLocationModel[] { };
                    SelectMaterialName = "";
                    SelectedMaterialId = Guid.Empty;
                    productOption.MaterialId = null;
                    productOption.MaterialName = "";
                }
                // clear panel

                // OptionListModel.FirstOrDefault(x => x.Id == optionId);

                // Console.WriteLine(JsonSerializer.Serialize(OptionListModel.FirstOrDefault(x => x.Id == optionId)));
                var option = OptionListModel.FirstOrDefault(x => x.Id == optionId);
                
                //on select child product option parent id should be removed on current selected options and replace by child option
                ProductOptions.Remove(ProductOptions.FirstOrDefault(x => x.OptionId == option.ParentId));
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

        public async Task OnSelectMaterial(bool isChecked, Guid id)
        {
            try
            {
                var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == SelectedProductOption.Id);
                if(isChecked){
                    var material = MaterialListModel.Materials.FirstOrDefault(x => x.Id == id);
                    productOption.MaterialId = id;
                    productOption.MaterialName = material.Name;
                    _rolls = material.RollsAndLocations;
                    SelectedMaterialId = id;
                    SelectMaterialName = material.Name;
                }else {
                    _rolls = new RollAndLocationModel[] { };
                    SelectMaterialName = "";
                    productOption.MaterialId = null;
                    productOption.MaterialName = "";
                }

                foreach (var rollId in selectedRollIds)
                {
                    if(ProductOptionRollIds.Contains(rollId)){
                        await UpdateProductOptionRollIds.InvokeAsync(rollId);
                    }
                }

                selectedRolls.Clear();
                selectedRollIds.Clear();

                // Console.WriteLine(JsonSerializer.Serialize(material.RollsAndLocations));
                Console.WriteLine(JsonSerializer.Serialize(SelectMaterialName));
                productOption.RollIds = "";
                productOption.RollNames = "";
                
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

        public async Task OnSelectRolls(bool isChecked, RollAndLocationModel roll)
        {
            try
            {
                var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == SelectedProductOption.Id);

                if(isChecked){
                    selectedRolls.Add(roll);
                    selectedRollIds.Add(roll.Id);
                    selectedRollNames.Add(roll.RollNumber);
                }else {
                    selectedRolls.Remove(roll);
                    selectedRollIds.Remove(roll.Id);
                    selectedRollNames.Remove(roll.RollNumber);
                }

                await UpdateProductOptionRollIds.InvokeAsync(roll.Id);

                productOption.RollIds = JsonSerializer.Serialize(selectedRollIds);
                productOption.RollNames = JsonSerializer.Serialize(selectedRollNames);
                // Console.WriteLine(JsonSerializer.Serialize(productOption));
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

        public async Task OnSelectAllRolls(bool isChecked)
        {
            try
            {
                var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == SelectedProductOption.Id);
                
                productOption.RollIds = "";
                productOption.RollNames = "";

                if(isChecked){
                    
                    foreach (var roll in _rolls)
                    {
                        if(!ProductOptionRollIds.Contains(roll.Id)){
                            selectedRollIds.Add(roll.Id);
                            selectedRollNames.Add(roll.RollNumber);
                            selectedRolls.Add((RollAndLocationModel)roll);
                            await UpdateProductOptionRollIds.InvokeAsync(roll.Id);
                        }
                    }
                    productOption.RollIds = JsonSerializer.Serialize(selectedRollIds);
                    productOption.RollNames = JsonSerializer.Serialize(selectedRollNames);

                }else {

                    foreach (var id in selectedRollIds)
                    {
                        if(ProductOptionRollIds.Contains(id)){
                            await UpdateProductOptionRollIds.InvokeAsync(id);
                        }
                    }
                    selectedRolls.Clear();
                    selectedRollNames.Clear();
                    selectedRollIds.Clear();
                }
                // Console.WriteLine(JsonSerializer.Serialize(productOption));

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

         public async Task OnInputConsumption(string consumption)
        {
            try
            {
                var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == SelectedProductOption.Id);
                if(!string.IsNullOrWhiteSpace(consumption)){
                    productOption.Consumption = Convert.ToDouble(consumption);
                }else {
                    productOption.Consumption = 0;
                }
                // Console.WriteLine(JsonSerializer.Serialize(SelectedProductOption));
                // Console.WriteLine(JsonSerializer.Serialize(productOption));
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

        public async Task OnSelectUOM(string id)
        {
            try
            {
                var productOption = ProductOptions.FirstOrDefault(x => x.OptionId == SelectedProductOption.Id);
                productOption.UnitOfMeasurementId = int.Parse(id);
                // Console.WriteLine(JsonSerializer.Serialize(productOption));
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

        private bool OnCustomRollFilter(RollAndLocationModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customRollFilterValue))
                return true;

            return model.RollNumber?.Contains(customRollFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        private bool OnCustomFabricFilter(MaterialModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFabricFilterValue))
                return true;

            return model.Name?.Contains(customFabricFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

    }
}

