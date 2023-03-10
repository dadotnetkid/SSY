using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions;

namespace SSY.Blazor.Pages.Products.Components.ProductOption
{
    public partial class ProductOption
    {
        public ProductOption()
        {
        }
        
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
            public ProductOptionService _productOptionService { get; set; }
            public MaterialService _materialService { get; set; }
            public ReservationService _reservationService { get; set; }
            
        #endregion

        #region Parameters
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public ProductModel ProductModel { get; set; } = new() { };

        [Parameter]
        public ProductTypeModel ProductTypeModel{ get; set; }

        [Parameter]
        public List<PanelModel> Panels { get; set; }

        [Parameter]
        public Guid ProductParentId { get; set; }

        [Parameter]
        public EventCallback SaveParentProductOption { get; set; }

        [Parameter]
        public EventCallback OnSaveProductOption { get; set; }

        [Parameter]
        public EventCallback<Guid> UpdateProductOptionRollIds { get; set; }


        [Parameter]
        public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public MaterialListModel MaterialListModel { get; set; } = new () { Materials = new()};

        [Parameter]
        public List<Guid> ProductOptionRollIds { get; set; } = new ();

        [Parameter]
        public List<Guid> ReservedRollIds { get; set; } = new ();

        [Parameter]
        public double ForecastQuantity { get; set; } = new ();

        

        #endregion

        #region Models
            // public ProductOptionsModel ProductOptionsModel { get; set; } = new();
            // public GetAllProductOptionDropdownOutputModel ProductOptionDropdownModel { get; set; } = new() { Result = new() { Items = new() } };
            // public GetProductOptionsModel GetProductOptionsModel { get; set; } = new() { Result = new() };
            // public List<ProductOptionModel> ProductOptions { get; set; }
        public List<CreateRollReservationModel> CreateRollReservationsList {get;set;}
        #endregion


        #region ui usage
        Dictionary<string, List<OptionModel>> groupByOptionLabel = new();

        public List<int> SelectedIds = new ();
        

        #endregion

        protected override async Task OnInitializedAsync()
        {
            _productOptionService = new(js, ClientFactory, NavigationManager, Configuration);
            _productService = new(js, ClientFactory, NavigationManager, Configuration);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _reservationService = new(js, ClientFactory, NavigationManager, Configuration);

            ProductTypeModel = new() { Options = new() };
            Panels = new();
        }

        protected override async Task OnParametersSetAsync()
        {
            groupByOptionLabel.Clear();
            SelectedIds.Clear();
            if(ProductModel.TypeId != 0 || ProductTypeModel.Options.Any()){

                // group by option label (ex. Gender, Base, Hem, etc.)
                ProductTypeModel?.Options?.GroupBy(x => x.Label).ToList().ForEach(option => {
                    groupByOptionLabel.Add(option.First().Label, option.ToList());
                });

                // product option mother iteration
                foreach (var option in ProductTypeModel?.Options)
                {
                    // find if mother id exists in options
                    if(ProductModel.Options.Any(x=> x.OptionId == option.Id))
                    {
                        // add mother option id
                        SelectedIds.Add(option.Id);
                    }

                    // check if mother option has child option (1)
                    if(option.OptionOptions.Any()){
                        // mother 1st child option iteration
                        foreach (var childOption1 in option.OptionOptions)
                        {
                            //check if child product(1st) exist in option
                            if(ProductModel.Options.Any(x=> x.OptionId == childOption1.Id))
                            {
                                // add mother option id 
                                SelectedIds.Add(option.Id);
                                // add 1st child option id 
                                SelectedIds.Add(childOption1.Id);
                            }
                            // check if child option 1 has child option(2)
                            if(childOption1.OptionOptions.Any())
                            {
                                // mother 2nd child option iteration
                                foreach (var childOption2 in childOption1.OptionOptions)
                                {  
                                    //check if child product(2nd) exist in option
                                    if(ProductModel.Options.Any(x=> x.OptionId == childOption2.Id))
                                    {
                                        // add mother option id 
                                        SelectedIds.Add(option.Id);
                                        // add 1st child option id 
                                        SelectedIds.Add(childOption1.Id);
                                        // add 2nd child option id 
                                        SelectedIds.Add(childOption2.Id);
                                    }

                                    // check if child option 2 has child option(3)
                                    if(childOption2.OptionOptions.Any()){
                                        // mother 3rd child option iteration
                                        foreach (var childOption3 in childOption2.OptionOptions)
                                        {  
                                            //check if child product(3rd) exist in option
                                            if(ProductModel.Options.Any(x=> x.OptionId == childOption3.Id))
                                            {
                                                // add mother option id 
                                                SelectedIds.Add(option.Id);
                                                // add 1st child option id 
                                                SelectedIds.Add(childOption1.Id);
                                                // add 2nd child option id 
                                                SelectedIds.Add(childOption2.Id);
                                                // add 2nd child option id 
                                                SelectedIds.Add(childOption3.Id);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        public async Task SaveChanges()
        {
            try
            {
                List<UpdateProductOptionDto> productOptionDto = new();
                List<CreateRollReservationModel> CreateRollReservationsList = new();
                // check if equal to parent product of the updating option if yes apply to all child product if not apply to child only
                if(ProductParentId == ProductModel.Id){
                    Console.WriteLine("All");
                    // call product option saving of parent in details.cs
                    await SaveParentProductOption.InvokeAsync();
                }else {
                    Console.WriteLine("child");
                    ProductModel.Options.ForEach(o => {
                        productOptionDto.Add(new UpdateProductOptionDto(){
                            ProductId = ProductModel.Id,
                            OptionId = o.OptionId,
                            MaterialId = o.MaterialId,
                            RollIds = o.RollIds,
                            RollNames = o.RollNames,
                            MaterialName = o.MaterialName,
                            UnitOfMeasurementId = o.UnitOfMeasurementId,
                            Consumption = o.Consumption
                        });
                    });
                    // var rollIds = JsonSerializer.Deserialize<List<Guid>>(option.RollIds);
                    foreach (var item in productOptionDto)
                    {

                        if (!string.IsNullOrEmpty(item.RollIds))
                        {
                            var rollIds = JsonSerializer.Deserialize<List<Guid>>(item.RollIds);

                            if(rollIds.Any()){

                                var material = MaterialListModel.Materials.FirstOrDefault (x => x.Id == (Guid)item.MaterialId);
                                var RollReservations = new List<RollReservation>();

                                foreach (var id in rollIds){
                                    var roll = material.RollsAndLocations.FirstOrDefault(x => x.Id == id);
                                    RollReservations.Add(new RollReservation()
                                    {
                                        RollId = roll.Id,
                                        RollNumber = roll.RollNumber,
                                        ReservedCount = roll.TotalCount.Value
                                    });
                                }

                                CreateRollReservationsList.Add(new() 
                                {
                                    IsActive = true,
                                    CollectionId = ProductModel.CollectionId.ToString(),
                                    MaterialId = (Guid)item.MaterialId,
                                    CollectionName = ProductModel.CollectionName,
                                    InfluencerNames = ProductModel.InfluencerNames,
                                    RollReservations = RollReservations,
                                });

                            }
                        }
                    }
                    // Console.WriteLine(JsonSerializer.Serialize("productOptionDto"));
                    // Console.WriteLine(JsonSerializer.Serialize(productOptionDto));
                    // Console.WriteLine(JsonSerializer.Serialize("CreateRollReservationsList"));
                    // Console.WriteLine(JsonSerializer.Serialize(CreateRollReservationsList));

                    Console.WriteLine(JsonSerializer.Serialize("CreateRollReservationsList"));
                    Console.WriteLine(JsonSerializer.Serialize(ReservedRollIds));
                    // delete all reservation
                    // then create new reservation upon saving the product option

                    if (ReservedRollIds.Count != 0)
                    {
                        var deleteRes = await _reservationService.DeleteMaterialReservationList(ReservedRollIds);
                        if (deleteRes)
                        {
                            // ReservedRollIds.Clear();
                            if(CreateRollReservationsList.Any())
                            {
                                var res = await _materialService.CreateRollReservation(CreateRollReservationsList);
                                if (res){
                                    await _productOptionService.UpdateProductOption(productOptionDto);
                                }
                            }else {
                                await _productOptionService.UpdateProductOption(productOptionDto);
                            }
                        }
                    }else {

                        if(CreateRollReservationsList.Any()){
                            var res = await _materialService.CreateRollReservation(CreateRollReservationsList);
                            if (res){
                                await _productOptionService.UpdateProductOption(productOptionDto);
                            }
                        }else {
                            await _productOptionService.UpdateProductOption(productOptionDto);
                        }
                    }

                    await OnSaveProductOption.InvokeAsync();
                    
                }

                StateHasChanged();
                // refresh ung buong page para mag reflect ung changes
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

