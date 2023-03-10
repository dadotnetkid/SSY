using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SSY.Blazor.Pages.Shared.Components.ModalMassUpload
{
    public partial class ModalMassUpload
    {

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private MaterialService _materialService { get; set; }

        private SubMaterialService _subMaterialService { get; set; }
        [Parameter]
        public string Module { get; set; }



        public MaterialListModel MaterialListModel { get; set; }
        public CreateSubMaterialListModel CreateSubMaterialListModel { get; set; }
        public CreateSubMaterialModel CreateSubMaterialDto { get; set; }
        public MaterialModel MaterialModel { get; set; }
        public TypeListModel typeListModel { get; set; }
        public ColorListModel colorListModel { get; set; }
        public CategoryListModel categoryListModel { get; set; }
        public WeightListModel weightListModel { get; set; }
        public ShadingListModel shadingListModel { get; set; }
        public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; }
        public RecycledListModel recycledListModel { get; set; }
        public PFPListModel pFPListModel { get; set; }
        public CompressionListModel compressionListModel { get; set; }
        public FabricStretchListModel fabricStretchListModel { get; set; }
        public CreaseListModel creaseListModel { get; set; }
        public PrintRepeatListModel printRepeatListModel { get; set; }
        public ExcessListModel excessListModel { get; set; }
        public HandFeelListModel handFeelListModel { get; set; }
        public CareInstructionTypeListModel careInstructionTypeListModel { get; set; }
        public GetAllCompanyOutputModel supplierData { get; set; }
        public RollAndLocationModel RollAndLocationModel { get; set; } = new();
        public PricingTypeListModel pricingTypeListModel { get; set; } = new();
        public string MassUploadSheetName = "";
        public bool isReady = false;
        public bool isInvalidFile = false;
        public bool isValidating = false;
        public bool isUploading = false;
        public bool isUploadingImages = false;
        public string MassUploadMessage = "";
        public List<string> MUFErrors { get; set; } = new();

        [Parameter]
        public EventCallback OnMassUpload { get; set; }

        IList<string> imageDataUrls = new List<string>();
        IReadOnlyList<IBrowserFile> selectedImage;
        string labelText = "";
        string classAlert = "";

        protected override async Task OnInitializedAsync()
        {

            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
            MaterialListModel = new() { Materials = new() };
            CreateSubMaterialListModel = new() { CreateSubMaterialList = new() };
            CreateSubMaterialDto = new() { Accountability = new(), Location = new() };
            MaterialModel = new() { Accountability = new(), CompositionAndConstruction = new(), RollsAndLocations = new(), Company = new() };
            MaterialModel.RollsAndLocations = new();
            typeListModel = new() { Result = new() { Items = new() } };
            colorListModel = new() { Result = new() { Items = new() } };
            categoryListModel = new() { Result = new() { Items = new() } };
            weightListModel = new() { Result = new() { Items = new() } };
            unitOfMeasurementListModel = new() { Result = new() { Items = new() } };
            recycledListModel = new() { Result = new() { Items = new() } };
            pFPListModel = new() { Result = new() { Items = new() } };
            compressionListModel = new() { Result = new() { Items = new() } };
            fabricStretchListModel = new() { Result = new() { Items = new() } };
            creaseListModel = new() { Result = new() { Items = new() } };
            printRepeatListModel = new() { Result = new() { Items = new() } };
            excessListModel = new() { Result = new() { Items = new() } };
            handFeelListModel = new() { Result = new() { Items = new() } };
            careInstructionTypeListModel = new() { Result = new() { Items = new() } };
            supplierData = new() { Result = new() { Items = new() } };
            pricingTypeListModel = new() { Result = new() { Items = new() } };
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                categoryListModel = await GetDropdown<CategoryListModel>("MaterialCategory");
                typeListModel = await GetDropdown<TypeListModel>("MaterialType");
                weightListModel = await GetDropdown<WeightListModel>("WeightUnit");
                unitOfMeasurementListModel = await GetDropdown<UnitOfMeasurementListModel>("UnitOfMeasurement");
                colorListModel = await GetDropdown<ColorListModel>("Color");
                shadingListModel = await GetDropdown<ShadingListModel>("Shading");
                excessListModel = await GetDropdown<ExcessListModel>("Excess");
                pFPListModel = await GetDropdown<PFPListModel>("PreparedForPrint");
                compressionListModel = await GetDropdown<CompressionListModel>("Compression");
                fabricStretchListModel = await GetDropdown<FabricStretchListModel>("FabricStretch");
                creaseListModel = await GetDropdown<CreaseListModel>("Crease");
                handFeelListModel = await GetDropdown<HandFeelListModel>("HandFeel");
                printRepeatListModel = await GetDropdown<PrintRepeatListModel>("PrintRepeat");
                careInstructionTypeListModel = await GetDropdown<CareInstructionTypeListModel>("CareInstructionType");
                supplierData = await GetDropdown<GetAllCompanyOutputModel>("Company");
                recycledListModel = await GetDropdown<RecycledListModel>("Recycled");
                pricingTypeListModel = await GetDropdown<PricingTypeListModel>("PricingType");
                StateHasChanged();
            }
        }

        public async Task<T> GetDropdown<T>(string type)
        {
            var url = $"{Configuration["App:ServerRootAddress"]}/{type}/GetAll?MaxResultCount=100";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = ClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<T>(responseStream);
                return data;
            }
            else
            {
                return default(T);
            }
        }


        public async Task ImportExcelFile(InputFileChangeEventArgs e)
        {
            try
            {
                MUFErrors.Clear();
                isValidating = true;
                isInvalidFile = false;
                MaterialListModel = new() { Materials = new() };
                CreateSubMaterialListModel = new() { CreateSubMaterialList = new() };
                isReady = false;
                MassUploadMessage = "There is an error on your mass upload form";
                var fileName = e.File.Name;
                var fileStream = e.File.OpenReadStream(maxAllowedSize: 100000000);
                var ms = new MemoryStream();
                await fileStream.CopyToAsync(ms);
                fileStream.Close();
                ms.Position = 0;

                ISheet sheet;
                var xsswb = new XSSFWorkbook(ms);
                var rl = new List<string>();
                var keys = new List<string>();
                MaterialListModel.Materials.Clear();
                CreateSubMaterialListModel.CreateSubMaterialList.Clear();
                for (int k = 0; k < xsswb.NumberOfSheets; k++)
                {
                    // }
                    rl.Clear();
                    keys.Clear();
                    sheet = xsswb.GetSheetAt(k);
                    var sheetName = xsswb.GetSheetAt(k).SheetName;

                    // System.Console.WriteLine(xsswb.GetSheetAt(k).SheetName);
                    IRow hr = sheet.GetRow(1);
                    // System.Console.WriteLine(sheetName);
                    // System.Console.WriteLine(xsswb.NumberOfSheets);
                    MassUploadSheetName = sheetName;



                    int cc = hr.LastCellNum;

                    for (var j = 0; j < cc; j++)
                    {
                        ICell cell = hr.GetCell(j);
                        // dt.Columns.Add(cell.ToString());
                        keys.Add(ti.ToTitleCase(cell.ToString()).Replace("(filename)", "").Replace(" ", "").Replace("(OEM)", "").Replace("/", "").Replace("(Years)", "").Replace("-", "").Replace("#(TCXCode)", "Number").Replace("*", ""));

                    }
                    // Console.WriteLine(sheet.LastRowNum);
                    for (var j = (sheet.FirstRowNum + 2); j <= sheet.LastRowNum; j++)
                    {
                        var r = sheet.GetRow(j);
                        // System.Console.WriteLine(JsonSerializer.Serialize(r.Cells.ToList()));

                        // System.Console.WriteLine(r.FirstCellNum);
                        // return;

                        var index = j - 2;
                        // System.Console.WriteLine("row number/index  = " + (index));

                        if (sheetName.ToLower().Contains("fabric") || sheetName.ToLower().Contains("yarn") || sheetName.ToLower().Contains("material") || sheetName.ToLower().Contains("greige") || sheetName.ToLower() == "fabric" || sheetName.ToLower() == "material" || sheetName.ToLower() == "yarn" || sheetName.ToLower() == "greige")
                        {
                            MaterialListModel.Materials.Add(MaterialModel);
                            MaterialListModel.Materials[index].RollsAndLocations.Add(RollAndLocationModel);
                            MaterialModel = new() { Accountability = new(), CompositionAndConstruction = new(), RollsAndLocations = new(), Company = new(), PurchaseDetail = new() };
                            RollAndLocationModel = new();
                        }

                        if (sheetName.ToLower().Contains("packaging") || sheetName.ToLower().Contains("trims and accessories") || sheetName.ToLower().Contains("other") || sheetName.ToLower().Contains("submaterial") || sheetName.ToLower() == "packaging" || sheetName.ToLower() == "trims and accessories" || sheetName.ToLower() == "other" || sheetName.ToLower() == "submaterial")
                        {
                            CreateSubMaterialListModel.CreateSubMaterialList.Add(CreateSubMaterialDto);
                            CreateSubMaterialDto = new() { Accountability = new(), Location = new() };
                        }
                        if (r.FirstCellNum != 0) continue;
                        for (var i = r.FirstCellNum; i < cc; i++)
                        {
                            // rl.Add(currentValue);
                            var currentValue = r.GetCell(i) == null ? null : r.GetCell(i).ToString();

                            var rowError = index + 3;
                            if (sheetName.ToLower().Contains("fabric") || sheetName.ToLower().Contains("material") || sheetName.ToLower().Contains("greige") || sheetName.ToLower() == "fabric" || sheetName.ToLower() == "material" || sheetName.ToLower() == "greige")
                            {
                                var data = MaterialListModel.Materials[index];
                                //System.Console.WriteLine("index: " + keys[i] + " value: " + currentValue + " " + index);

                                if (keys[i] == "DateOfInventory")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.DateOfInventory = isSuccess ? date : null;
                                }

                                if (keys[i] == "Stocktaker") data.Accountability.StockTaker = currentValue;


                                if (keys[i] == "Validator") data.Accountability.Validator = currentValue;

                                if (keys[i] == "SwatchSent")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.SwatchSent = isSuccess ? date : null;
                                }

                                if (keys[i] == "SwatchReceived")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.SwatchRecieved = isSuccess ? date : null;
                                }

                                if (keys[i] == "ConfirmedSwatchReceived")
                                    data.Accountability.ConfirmedSwatchRecieved = currentValue.ToLower() == "yes" ? true : false;

                                if (keys[i] == "Image")

                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        data.Image = currentValue;
                                    }
                                    else
                                    {
                                        data.Image = "/Uploads/Images/" + currentValue;
                                    }


                                if (keys[i] == "Category")
                                {
                                    var category = categoryListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (category == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CategoryId = category.Id;
                                    }
                                }

                                if (keys[i] == "MaterialType")
                                {
                                    var type = typeListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (type == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.TypeId = type.Id;
                                    }
                                }


                                if (keys[i] == "ColorGroup")
                                {
                                    var color = colorListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (color == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorId = color.Id;
                                        data.ColorGroup = color.Value;
                                    }
                                }

                                if (keys[i] == "ColorName")
                                {
                                    var color = colorListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (color == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorId = color.Id;
                                        data.ColorGroup = color.Value;
                                    }
                                }

                                if (keys[i] == "ColorCodeName")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorCode = currentValue;
                                    }
                                }

                                if (keys[i] == "ColorCode") data.ColorCode = currentValue;

                                if (keys[i] == "ItemCode") data.ItemCode = currentValue;

                                if (keys[i] == "PantoneNumber") data.Pantone = currentValue;

                                if (keys[i] == "Weight")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Weight = Convert.ToDouble(currentValue);
                                    }
                                }

                                if (keys[i] == "WeightUnit")
                                {
                                    var weight = weightListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (weight == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.WeightUnitId = weight.Id;
                                    }
                                }

                                if (keys[i] == "CuttableWidth") data.CuttableWidth = currentValue;

                                if (keys[i] == "TotalCount")
                                {
                                    data.TotalCount = Convert.ToDouble(currentValue);
                                    data.AvailableCount = Convert.ToDouble(currentValue);
                                    data.ReservedCount = 0;
                                    data.UsedCount = 0;
                                }

                                if (keys[i] == "UnitOfMeasurement")
                                {
                                    var unit = unitOfMeasurementListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (unit == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.UnitOfMeasurementId = unit.Id;
                                    }
                                }

                                // if (keys[i] == "RollNumber") data.RollAndLocation.RollNumber = Convert.ToInt32(currentValue);
                                if (keys[i] == "RollNumber")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].RollNumber = currentValue;
                                    }
                                }

                                if (keys[i] == "DateAcquired")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].DateAcquired = DateTime.Parse(currentValue);
                                    }
                                }

                                if (keys[i] == "ShelfLife")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].ShelfLife = isSuccess ? number : null;
                                }

                                // if (keys[i] == "ConsumeBeforeDate") data.ConsumeBeforeDate = DateTime.Parse(currentValue) ;

                                if (keys[i] == "Shading")
                                {
                                    data.RollsAndLocations[0].ShadingId = shadingListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower())?.Id;
                                }

                                if (keys[i] == "BuildingWarehouse") data.RollsAndLocations[0].BuildingOrWarehouse = currentValue;

                                if (keys[i] == "TRackNumber")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].TRackNumber = currentValue;
                                    }
                                }

                                // if (keys[i] == "Rack") data.RollAndLocation.Rack = Convert.ToInt32(currentValue);
                                if (keys[i] == "Rack")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].Rack = currentValue;
                                    }
                                }

                                if (keys[i] == "ForDisposal") data.RollsAndLocations[0].IsDisposal = currentValue.ToLower() == "yes" ? true : false;

                                if (keys[i] == "DisposalDate")
                                {
                                    if ((bool)data.RollsAndLocations[0].IsDisposal)
                                    {

                                        if (string.IsNullOrEmpty(currentValue))
                                        {
                                            data.RollsAndLocations[0].DisposalDate = DateTime.Now;
                                        }
                                        else
                                        {
                                            data.RollsAndLocations[0].DisposalDate = DateTime.Parse(currentValue);
                                        }
                                    }
                                }

                                if (keys[i] == "PONumber") data.RollsAndLocations[0].PONumber = currentValue;

                                if (keys[i] == "ShippedCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].ShippedCount = isSuccess ? number : null;
                                }

                                if (keys[i] == "ReceivedCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].ReceivedCount = isSuccess ? number : null;
                                }


                                if (keys[i] == "Content") data.CompositionAndConstruction.Content = currentValue;

                                if (keys[i] == "Construction") data.CompositionAndConstruction.Construction = currentValue;

                                if (keys[i] == "Gauge") data.CompositionAndConstruction.Gauge = currentValue;

                                if (keys[i] == "Recycled")
                                {
                                    var recycle = recycledListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (recycle == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.RecycledId = recycle.Id;
                                    }
                                }

                                if (keys[i] == "Excess")
                                {
                                    var excess = excessListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (excess == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.ExcessId = excess.Id;
                                        data.ExcessOrNew = excess.Value.ToLower() == "yes" ? "E" : "N";
                                    }
                                }

                                if (keys[i] == "PFP")
                                {
                                    var pfp = pFPListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (pfp == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.PreparedForPrintId = pfp.Id;
                                    }
                                }

                                if (keys[i] == "Compression")
                                {
                                    data.CompositionAndConstruction.CompressionId = compressionListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower())?.Id;
                                }

                                if (keys[i] == "FabricStretch")
                                {
                                    var fabstrech = fabricStretchListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (fabstrech == null)
                                    {
                                        data.CompositionAndConstruction.FabricStretchId = null;
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.FabricStretchId = fabstrech.Id;
                                    }
                                }

                                if (keys[i] == "Crease")
                                {
                                    var crease = creaseListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (crease == null)
                                    {
                                        data.CompositionAndConstruction.CreaseId = null;
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.CreaseId = crease.Id;
                                    }
                                }

                                if (keys[i] == "HandFeel")
                                {

                                    if (!string.IsNullOrEmpty(currentValue))
                                    {
                                        data.CompositionAndConstruction.HandFeelIdList.Add(handFeelListModel.Result.Items.Find(x => x.Value.ToLower() == currentValue.ToLower()).Id);
                                        data.CompositionAndConstruction.HandFeelIds = JsonSerializer.Serialize(data.CompositionAndConstruction.HandFeelIdList);
                                    }

                                }

                                if (keys[i] == "PrintRepeat")
                                {
                                    var print = printRepeatListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (print == null)
                                    {
                                        data.CompositionAndConstruction.PrintRepeatId = null;
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.PrintRepeatId = print.Id;
                                    }
                                }

                                if (keys[i] == "CareInstructionsType")
                                {
                                    var care = careInstructionTypeListModel.Result.Items.FirstOrDefault(x => x.Label.ToLower() == currentValue.ToLower());
                                    if (care == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CareInstructionTypeId = care.Id;
                                    }
                                }

                                if (keys[i] == "CompanyName")
                                {
                                    var supplier = supplierData.Result.Items.FirstOrDefault(x => x.Name.ToLower() == currentValue.ToLower());

                                    if (supplier == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Company.Id = supplier.Id;
                                        data.CompanyId = supplier.Id;
                                    }
                                }

                                if (keys[i] == "PricingType")
                                {
                                    var pricingType = pricingTypeListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (pricingType == null)
                                    {
                                        data.PurchaseDetail.PricingTypeId = null;
                                    }
                                    else
                                    {
                                        data.PurchaseDetail.PricingTypeId = pricingType.Id;
                                    }
                                }

                                if (keys[i] == "IncomingCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].IncomingCount = isSuccess ? number : 0;
                                }
                            }

                            if (sheetName.ToLower().Contains("yarn") || sheetName.ToLower() == "yarn")
                            {
                                var data = MaterialListModel.Materials[index];
                                //System.Console.WriteLine("index: " + keys[i] + " value: " + currentValue + " " + index);

                                if (keys[i] == "DateOfInventory")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.DateOfInventory = isSuccess ? date : null;
                                }

                                if (keys[i] == "Stocktaker") data.Accountability.StockTaker = currentValue;


                                if (keys[i] == "Validator") data.Accountability.Validator = currentValue;

                                if (keys[i] == "SwatchSent")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.SwatchSent = isSuccess ? date : null;
                                }

                                if (keys[i] == "SwatchReceived")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.SwatchRecieved = isSuccess ? date : null;
                                }

                                if (keys[i] == "ConfirmedSwatchReceived")
                                    data.Accountability.ConfirmedSwatchRecieved = currentValue.ToLower() == "yes" ? true : false;

                                if (keys[i] == "Image")

                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        data.Image = currentValue;
                                    }
                                    else
                                    {
                                        data.Image = "/Uploads/Images/" + currentValue;
                                    }


                                if (keys[i] == "Category")
                                {
                                    var category = categoryListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (category == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CategoryId = category.Id;
                                    }
                                }

                                if (keys[i] == "MaterialType")
                                {
                                    var type = typeListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (type == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.TypeId = type.Id;
                                    }
                                }


                                if (keys[i] == "ColorGroup")
                                {
                                    var color = colorListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (color == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorId = color.Id;
                                        data.ColorGroup = color.Value;
                                    }
                                }

                                if (keys[i] == "ColorName")
                                {
                                    var color = colorListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (color == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorId = color.Id;
                                        data.ColorGroup = color.Value;
                                    }
                                }

                                if (keys[i] == "ColorCodeName")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorCode = currentValue;
                                    }
                                }

                                if (keys[i] == "ColorCode") data.ColorCode = currentValue;

                                if (keys[i] == "ItemCode") data.ItemCode = currentValue;

                                if (keys[i] == "PantoneNumber") data.Pantone = currentValue;

                                if (keys[i] == "YarnCount")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Weight = Convert.ToDouble(currentValue);
                                    }
                                }

                                if (keys[i] == "TotalCount")
                                {
                                    data.TotalCount = Convert.ToDouble(currentValue);
                                    data.AvailableCount = Convert.ToDouble(currentValue);
                                    data.ReservedCount = 0;
                                    data.UsedCount = 0;
                                }

                                if (keys[i] == "UnitOfMeasurement")
                                {
                                    var unit = unitOfMeasurementListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (unit == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.UnitOfMeasurementId = unit.Id;
                                    }
                                }

                                // if (keys[i] == "RollNumber") data.RollAndLocation.RollNumber = Convert.ToInt32(currentValue);
                                if (keys[i] == "RollNumber")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].RollNumber = currentValue;
                                    }
                                }

                                if (keys[i] == "DateAcquired")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].DateAcquired = DateTime.Parse(currentValue);
                                    }
                                }

                                if (keys[i] == "ShelfLife")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].ShelfLife = isSuccess ? number : null;
                                }

                                // if (keys[i] == "ConsumeBeforeDate") data.ConsumeBeforeDate = DateTime.Parse(currentValue) ;

                                if (keys[i] == "Shading")
                                {
                                    data.RollsAndLocations[0].ShadingId = shadingListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower())?.Id;
                                }

                                if (keys[i] == "BuildingWarehouse") data.RollsAndLocations[0].BuildingOrWarehouse = currentValue;

                                if (keys[i] == "TRackNumber")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].TRackNumber = currentValue;
                                    }
                                }

                                // if (keys[i] == "Rack") data.RollAndLocation.Rack = Convert.ToInt32(currentValue);
                                if (keys[i] == "Rack")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.RollsAndLocations[0].Rack = currentValue;
                                    }
                                }

                                if (keys[i] == "ForDisposal") data.RollsAndLocations[0].IsDisposal = currentValue.ToLower() == "yes" ? true : false;

                                if (keys[i] == "DisposalDate")
                                {
                                    if ((bool)data.RollsAndLocations[0].IsDisposal)
                                    {

                                        if (string.IsNullOrEmpty(currentValue))
                                        {
                                            data.RollsAndLocations[0].DisposalDate = DateTime.Now;
                                        }
                                        else
                                        {
                                            data.RollsAndLocations[0].DisposalDate = DateTime.Parse(currentValue);
                                        }
                                    }
                                }

                                if (keys[i] == "PONumber") data.RollsAndLocations[0].PONumber = currentValue;

                                if (keys[i] == "ShippedCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].ShippedCount = isSuccess ? number : null;
                                }

                                if (keys[i] == "ReceivedCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].ReceivedCount = isSuccess ? number : null;
                                }


                                if (keys[i] == "Content") data.CompositionAndConstruction.Content = currentValue;

                                if (keys[i] == "Construction") data.CompositionAndConstruction.Construction = currentValue;

                                if (keys[i] == "Recycled")
                                {
                                    var recycle = recycledListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (recycle == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.RecycledId = recycle.Id;
                                    }
                                }

                                if (keys[i] == "Excess")
                                {
                                    var excess = excessListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (excess == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.ExcessId = excess.Id;
                                        data.ExcessOrNew = excess.Value.ToLower() == "yes" ? "E" : "N";
                                    }
                                }

                                if (keys[i] == "PFP")
                                {
                                    var pfp = pFPListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (pfp == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompositionAndConstruction.PreparedForPrintId = 1002;
                                    }
                                }

                                if (keys[i] == "CareInstructionsType")
                                {
                                    var care = careInstructionTypeListModel.Result.Items.FirstOrDefault(x => x.Label.ToLower() == currentValue.ToLower());
                                    if (care == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CareInstructionTypeId = care.Id;
                                    }
                                }

                                if (keys[i] == "CompanyName")
                                {
                                    var supplier = supplierData.Result.Items.FirstOrDefault(x => x.Name.ToLower() == currentValue.ToLower());

                                    if (supplier == null)
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Company.Id = supplier.Id;
                                        data.CompanyId = supplier.Id;
                                    }
                                }

                                if (keys[i] == "PricingType")
                                {
                                    var pricingType = pricingTypeListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (pricingType == null)
                                    {
                                        data.PurchaseDetail.PricingTypeId = null;
                                    }
                                    else
                                    {
                                        data.PurchaseDetail.PricingTypeId = pricingType.Id;
                                    }
                                }

                                if (keys[i] == "IncomingCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.RollsAndLocations[0].IncomingCount = isSuccess ? number : 0;
                                }
                            }

                            if (sheetName.ToLower().Contains("packaging") || sheetName.ToLower().Contains("trims and accessories") || sheetName.ToLower().Contains("other") || sheetName.ToLower().Contains("submaterial") || sheetName.ToLower() == "packaging" || sheetName.ToLower() == "trims and accessories")
                            {
                                // var data = MaterialListModel.Materials[index];
                                var data = CreateSubMaterialListModel.CreateSubMaterialList[index];

                                // System.Console.WriteLine("packaging index: " + keys[i] + " value: " + currentValue + " " + index);

                                if (keys[i] == "DateOfInventory")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.DateOfInventory = isSuccess ? date : null;
                                }

                                if (keys[i] == "Stocktaker") data.Accountability.StockTaker = currentValue;


                                if (keys[i] == "Validator") data.Accountability.Validator = currentValue;

                                if (keys[i] == "SwatchSent")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.SwatchSent = isSuccess ? date : null;
                                }

                                if (keys[i] == "SwatchReceived")
                                {
                                    DateTime date;
                                    bool isSuccess = DateTime.TryParse(currentValue, out date);
                                    data.Accountability.SwatchRecieved = isSuccess ? date : null;
                                }

                                if (keys[i] == "ConfirmedSwatchReceived")
                                    data.Accountability.ConfirmedSwatchRecieved = currentValue.ToLower() == "yes" ? true : false;

                                if (keys[i] == "Image") data.Image = currentValue;

                                if (keys[i] == "Category")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CategoryId = categoryListModel.Result.Items.FirstOrDefault(x => x.Label.ToLower() == currentValue.ToLower()).Id;
                                    }
                                }

                                if (keys[i] == "MaterialName")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Name = currentValue;
                                    }
                                }

                                if (keys[i] == "MaterialType")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.TypeId = typeListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower()).Id;
                                    }
                                }
                                if (keys[i] == "Color")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.ColorId = colorListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower()).Id;
                                    }
                                }

                                if (keys[i] == "Weight")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        data.Weight = null;
                                    }
                                    else
                                    {
                                        data.Weight = Convert.ToDouble(currentValue);
                                    }
                                }
                                if (keys[i] == "WeightUnit")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.WeightUnitId = weightListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower()).Id;
                                    }
                                }
                                if (keys[i] == "TotalCount")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.TotalCount = Convert.ToDouble(currentValue);
                                    }
                                }
                                if (keys[i] == "UnitOfMeasurement")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.UnitOfMeasurementId = unitOfMeasurementListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower()).Id;
                                    }
                                }
                                if (keys[i] == "BuildingWarehouse")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Location.BuildingWarehouse = currentValue;
                                    }
                                }
                                if (keys[i] == "TRackNumber")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Location.Room = currentValue;
                                    }
                                }
                                if (keys[i] == "Rack")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.Location.Rack = currentValue;
                                    }
                                }

                                if (keys[i] == "PONumber") data.PONumber = currentValue;

                                if (keys[i] == "IncomingCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.IncomingCount = isSuccess ? number : 0;
                                }

                                if (keys[i] == "ShippedCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.ShippedCount = isSuccess ? number : null;
                                }

                                if (keys[i] == "ReceivedCount")
                                {
                                    double number;
                                    bool isSuccess = Double.TryParse(currentValue, out number);
                                    data.ReceivedCount = isSuccess ? number : null;
                                }
                                if (keys[i] == "CompanyName")
                                {
                                    if (string.IsNullOrEmpty(currentValue))
                                    {
                                        MUFErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                    }
                                    else
                                    {
                                        data.CompanyId = supplierData.Result.Items.FirstOrDefault(x => x.Name.ToLower() == currentValue.ToLower()).Id;
                                    }
                                }
                                if (keys[i] == "PricingType")
                                {
                                    var pricingType = pricingTypeListModel.Result.Items.FirstOrDefault(x => x.Value.ToLower() == currentValue.ToLower());
                                    if (pricingType == null)
                                    {
                                        data.PurchaseDetail.PricingTypeId = null;
                                    }
                                    else
                                    {
                                        data.PurchaseDetail.PricingTypeId = pricingType.Id;
                                    }
                                }


                            }


                        }


                        //  Console.WriteLine(JsonSerializer.Serialize(MaterialListModel.Materials));
                        //Console.WriteLine(JsonSerializer.Serialize(CreateSubMaterialListModel.CreateSubMaterialList));


                        rl.Clear();
                    }
                }

                isReady = true;
                isValidating = false;
                MassUploadMessage = "Mass upload for is validated and ready for uploading";

                Console.WriteLine("Ready for mass upload");
            }
            catch (Exception ex)
            {
                isInvalidFile = true;
                isValidating = false;
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }
        }
        public async Task HandleUploadSubmit()
        {
            try
            {
                if (MaterialListModel.Materials.Any())
                {
                    await HandleMaterialUploadSubmit();
                }

                if (CreateSubMaterialListModel.CreateSubMaterialList.Any())
                {
                    await HandleSubMaterialUploadSubmit();
                }

                await OnMassUpload.InvokeAsync();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }
        public async Task HandleMaterialUploadSubmit()
        {
            try
            {

                isUploading = true;
                isReady = false;
                var materials = MaterialListModel.Materials.Where(x => !string.IsNullOrWhiteSpace(x.ItemCode));
                // System.Console.WriteLine(materials.Count()); 
                // System.Console.WriteLine(JsonSerializer.Serialize(materials)); 
                await _materialService.BulkCreateMaterial(materials);
                isUploading = false;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task HandleSubMaterialUploadSubmit()
        {
            try
            {
                isUploading = true;
                isReady = false;
                var materials = CreateSubMaterialListModel.CreateSubMaterialList.Where(x => !string.IsNullOrWhiteSpace(x.Accountability.StockTaker));
                //System.Console.WriteLine(materials.Count()); 
                //System.Console.WriteLine(JsonSerializer.Serialize(materials));

                await _subMaterialService.BulkCreateMaterial(materials);
                isUploading = false;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        private async Task DownloadFileFromURL(string url, string name)
        {
            await js.InvokeVoidAsync("triggerFileDownload", name, url);
        }

        //Uploads Images


        async Task OnInputFileName(InputFileChangeEventArgs e)
        {
            var imagesFiles = e.GetMultipleFiles(1000);
            selectedImage = imagesFiles;
            var format = "image/png";

            foreach (var imageFile in imagesFiles)
            {
                var resizedImageFiles = await imageFile.RequestImageFileAsync(format, 100, 100);
                var buffer = new byte[resizedImageFiles.Size];
                await resizedImageFiles.OpenReadStream().ReadAsync(buffer);

                var imageDataUrl = $"data: {format}; base64,{Convert.ToBase64String(buffer)}";
                imageDataUrls.Add(imageDataUrl);
            }
        }
        public async void FileUpload()
        {
            isUploadingImages = true;
            foreach (var file in selectedImage)
            {
                Stream stream = file.OpenReadStream(1024 * 6000);
                var path = $@"{env.WebRootPath}/Uploads/Images/{file.Name}";
                FileStream fs = File.Create(path);
                await stream.CopyToAsync(fs);
                fs.Close();
            }
            labelText = "Uploaded Success";
            classAlert = "success";
            await js.InvokeVoidAsync("defaultMessage", "success", "Image Upload Success!", "");
            isUploadingImages = false;
        }

    }
}