using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;

namespace SSY.Blazor.Pages.Inventory.InventoryTable
{
    public partial class InventoryTable
    {


        #region Injections

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private ProductAssignmentService _productAssignmentService { get; set; }
        private MaterialService _materialService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }
        private WarehouseService _warehouseService { get; set; }

        private DeleteDataByIdService _deleteDataByIdService { get; set; }

        #endregion

        #region Parameters


        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public int CategoryId { get; set; }
        [Parameter]
        public WarehouseModel WarehouseModel { get; set; } = new();
        [Parameter]
        public List<string> _selectedWarehouses { get; set; } = new();
        [Parameter]
        public List<string> _selectedColors { get; set; } = new();
        [Parameter]
        public List<string> _selectedMaterialTypes { get; set; } = new();


        #endregion

        #region Models

        // models for Blazorise
        public ProtectedSessionStorage SessionStorage { get; set; }
        public MaterialListModel MaterialListModel { get; set; } = new();
        public MaterialListModel ExcelMaterialData { get; set; } = new();
        public List<Guid> MaterialIds { get; set; } = new();
        public SubMaterialListModel ExcelSubMaterialData { get; set; } = new();
        public GetAllSubMaterialOutputModel SubMaterialData { get; set; } = new();
        public SubMaterialListModel SubMaterialListModel { get; set; } = new();
        public GetAllWarehouseOutputModel WarehouseList { get; set; } = new() { Result = new() { Items = new() } };

        private int categoryId;

        // updates the internal value whwenever the component is updated
        // You may not want that??
        public TypeListModel MaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorDropdownListModel { get; set; } = new() { Result = new() { Items = new() } };
        public HandFeelListModel HandFeelListModel { get; set; } = new() { Result = new() { Items = new() } };
        public List<int> HandFeelIds { get; set; } = new();

        public IEnumerable<MaterialModel> _materials;
        public IEnumerable<SubMaterialModel> _subMaterials;
        private IEnumerable<WarehouseModel> _warehouses;

        private string customFilterValue;

        public List<int> ColorIds { get; set; } = new();

        #endregion
        //public string[] ColorIds {get;set;} = new string[] { };
        public string[] MaterialTypeIds { get; set; } = new string[] { };
        public string[] Warehouses { get; set; } = new string[] { };
        public MaterialListModel FilteredByColorMaterialListModel { get; set; } = new();
        public MaterialListModel FilteredByWarehouseMaterialListModel { get; set; } = new();
        public MaterialListModel FilteredByMaterialTypeMaterialListModel { get; set; } = new();

        public string WarehouseText = "Select Warehouse";
        public string ColorText = "Select Color";
        public string MaterialTypeText = "Select Material Type";

        private bool IsLoading;

        void OnEmployeeNewItemDefaultSetter(MaterialModel employee)
        {
            employee.IsActive = true;
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
                _productAssignmentService = new(js, ClientFactory, NavigationManager, Configuration);
                _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
                _warehouseService = new(js, ClientFactory, NavigationManager, Configuration);
                HandFeelListModel = new() { Result = new() { Items = new() } };
                MaterialListModel = new() { Materials = new() };
                FilteredByColorMaterialListModel = new() { Materials = new() };
                FilteredByWarehouseMaterialListModel = new() { Materials = new() };
                FilteredByMaterialTypeMaterialListModel = new() { Materials = new() };
                SubMaterialListModel = new() { SubMaterials = new() };
                ExcelMaterialData = new() { Materials = new() };
                ExcelSubMaterialData = new() { SubMaterials = new() };
                ColorDropdownListModel = await _getDropdownService.GetAllColor(null, null, null, 100);
                MaterialTypeModel = await _getDropdownService.GetAllMaterialType(CategoryId, null, null, null, 100);
                WarehouseList = await _warehouseService.GetAllWarehouse(null, null, null, 100);
                _warehouses = WarehouseList.Result.Items;
                var handfeel = await _getDropdownService.GetAllHandFeel(null, null, null, 100);
                HandFeelListModel = handfeel;

                if (Module == "All")
                {
                    MaterialTypeModel = await _getDropdownService.GetAllMaterialType(null, null, null, null, 100);
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out? 
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await GetMaterial();
                }
                await js.InvokeVoidAsync("loadMultiSelectSearch");

                IsLoading = false;

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
        public async Task GetMaterial()
        {
            if (Module == "Overview")
            {
                var result = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000);
                MaterialListModel.Materials = result.Result.Items;
                _materials = result.Result.Items;
            }
            if (Module == "All")
            {
                var result = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000);
                foreach (var item in result.Result.Items)
                {
                    if (item.RollsAndLocations != null || item.RollsAndLocations.Count() != 0)
                    {
                        if (item.RollsAndLocations.Exists(r => r.IsDisposal == false))
                            MaterialListModel.Materials.Add(item);
                    }
                }
                _materials = MaterialListModel.Materials;
            }
            if (Module == "Greige")
            {
                var result = await _materialService.GetAllMaterial(1, null, null, null, null, 1000000);
                foreach (var item in result.Result.Items)
                {
                    if (item.RollsAndLocations != null || item.RollsAndLocations.Count() != 0)
                    {
                        if (item.RollsAndLocations.Exists(r => r.IsDisposal == false))
                            MaterialListModel.Materials.Add(item);
                    }
                }
                _materials = MaterialListModel.Materials;

            }
            if (Module == "Fabric")
            {
                var result = await _materialService.GetAllMaterial(2, null, null, null, null, 1000000);
                foreach (var item in result.Result.Items)
                {
                    if (item.RollsAndLocations != null || item.RollsAndLocations.Count() != 0)
                    {
                        if (item.RollsAndLocations.Exists(r => r.IsDisposal == false))
                            MaterialListModel.Materials.Add(item);
                    }
                }
                _materials = MaterialListModel.Materials;
            }
            if (Module == "Yarn")
            {
                var result = await _materialService.GetAllMaterial(5, null, null, null, null, 1000000);
                foreach (var item in result.Result.Items)
                {
                    if (item.RollsAndLocations != null || item.RollsAndLocations.Count() != 0)
                    {
                        if (item.RollsAndLocations.Exists(r => r.IsDisposal == false))
                            MaterialListModel.Materials.Add(item);
                    }
                }
                _materials = MaterialListModel.Materials;
            }
            if (Module == "Trims and Accessories")
            {
                var result = await _subMaterialService.GetAllSubMaterial(3, null, null, null, 1000000);
                SubMaterialListModel.SubMaterials = result.Result.Items;
                _subMaterials = result.Result.Items;
            }
            if (Module == "Packaging")
            {
                var result = await _subMaterialService.GetAllSubMaterial(4, null, null, null, 1000000);
                SubMaterialListModel.SubMaterials = result.Result.Items;
                _subMaterials = result.Result.Items;

            }
            if (Module == "Others")
            {
                var result = await _subMaterialService.GetAllSubMaterial(99, null, null, null, 1000000);
                SubMaterialListModel.SubMaterials = result.Result.Items;
                _subMaterials = result.Result.Items;

            }
        }
        public async Task onChangeCheckBox(Guid id, bool checkedValue)
        {
            if (checkedValue)
            {
                if (!MaterialIds.Contains(id))
                {
                    MaterialIds.Add(id);
                }
            }
            else
            {
                if (MaterialIds.Contains(id))
                {
                    MaterialIds.Remove(id);
                }

            }
        }
        public async Task onChangeCheckBoxAll(bool checkedValue)
        {

            if (checkedValue)
            {

                if (Module == "All" || Module == "Greige" || Module == "Fabric")
                {
                    foreach (var item in MaterialListModel.Materials)
                    {
                        MaterialIds.Add(item.Id);
                    }
                }
                else if (Module == "Trims and Accessories" || Module == "Packaging" || Module == "Others")
                {
                    foreach (var item in SubMaterialListModel.SubMaterials)
                    {
                        MaterialIds.Add(item.Id);
                    }
                }
            }
            else
            {
                MaterialIds.Clear();

            }
        }
        public async Task UnCheckAll()
        {
            MaterialIds.Clear();
        }
        public async Task DeleteSelectedIds()
        {

            foreach (var id in MaterialIds)
            {
                if (Module == "Greige" || Module == "Fabric" || Module == "All")
                {
                    var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "Material");
                }

                if (Module == "Trims and Accessories" || Module == "Packaging" || Module == "Others")
                {
                    var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "SubMaterial");
                }
            }
            await GetMaterial();

            await js.InvokeVoidAsync("defaultMessage", "success", "Successfully Deleted!", "");
            MaterialIds.Clear();

        }

        public async Task checkMaterial()
        {
            if (Module == "All")
            {
                var result = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000); // udpate id and total count
                ExcelMaterialData.Materials = result.Result.Items;
            }
            if (Module == "Greige")
            {
                var result = await _materialService.GetAllMaterial(1, null, null, null, null, 1000000); // udpate id and total count
                ExcelMaterialData.Materials = result.Result.Items;
            }
            if (Module == "Fabric")
            {
                var result = await _materialService.GetAllMaterial(2, null, null, null, null, 1000000);
                ExcelMaterialData.Materials = result.Result.Items;
            }

            if (Module == "Trims and Accessories")
            {
                var result = await _subMaterialService.GetAllSubMaterial(3, null, null, null, 1000000);
                ExcelSubMaterialData.SubMaterials = result.Result.Items;
            }

            if (Module == "Packaging")
            {
                var result = await _subMaterialService.GetAllSubMaterial(4, null, null, null, 1000000);
                ExcelSubMaterialData.SubMaterials = result.Result.Items;
            }

            if (Module == "Others")
            {
                var result = await _subMaterialService.GetAllSubMaterial(99, null, null, null, 1000000);
                ExcelSubMaterialData.SubMaterials = result.Result.Items;
            }
        }

        public async Task GenerateMassAdjustmentExcel()
        {
            await checkMaterial();
            IWorkbook workbook = new XSSFWorkbook();
            var dataFormat = workbook.CreateDataFormat();
            var dataStyle = workbook.CreateCellStyle();
            dataStyle.DataFormat = dataFormat.GetFormat("MM/dd/yyyy HH:mm:ss");
            ISheet worksheet = workbook.CreateSheet(Module);

            // style center of sheet;
            ICellStyle CellStyle = workbook.CreateCellStyle();
            CellStyle.Alignment = HorizontalAlignment.Center;
            CellStyle.WrapText = true; //wrap the text in the cell
            // CellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            // CellStyle.FillPattern = FillPattern.SolidForeground;

            // font style bold setup
            var font = workbook.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            // sheet name


            int rowNumber = 0;
            IRow row = worksheet.CreateRow(rowNumber++);

            #region Header Main titles
            ICell cell = row.CreateCell(0);
            row.GetCell(0).CellStyle = CellStyle;
            cell.SetCellValue("Item Code*");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(1);
            row.GetCell(1).CellStyle = CellStyle;
            cell.SetCellValue("Color Code*");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(2);
            row.GetCell(2).CellStyle = CellStyle;
            cell.SetCellValue("Roll Number*");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(3);
            row.GetCell(3).CellStyle = CellStyle;
            cell.SetCellValue("Actual Count*");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(4);
            row.GetCell(4).CellStyle = CellStyle;
            cell.SetCellValue("Building/Warehouse");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(5);
            row.GetCell(5).CellStyle = CellStyle;
            cell.SetCellValue("T-Rack Number");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(6);
            row.GetCell(6).CellStyle = CellStyle;
            cell.SetCellValue("Rack");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(7);
            row.GetCell(7).CellStyle = CellStyle;
            cell.SetCellValue("PO Number");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(8);
            row.GetCell(8).CellStyle = CellStyle;
            cell.SetCellValue("Shipped Quantity");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(9);
            row.GetCell(9).CellStyle = CellStyle;
            cell.SetCellValue("Received Quantity");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(10);
            row.GetCell(10).CellStyle = CellStyle;
            cell.SetCellValue("Remarks");
            cell.CellStyle.SetFont(font);

            #endregion


            rowNumber = 1; // start of material details
            foreach (var item in ExcelMaterialData.Materials)
            {
                // System.Console.WriteLine(JsonSerializer.Serialize(item));
                // System.Console.WriteLine(item.RollsAndLocations.Count);
                row = worksheet.CreateRow(rowNumber++);
                if (item.RollsAndLocations.Count == 1 || item.RollsAndLocations.Count == 0)
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        cell = row.CreateCell(i);
                        // row.GetCell(i).CellStyle = CellStyle;
                        if (i == 0) cell.SetCellValue(item.ItemCode);
                        if (i == 1) cell.SetCellValue(item.ColorCode);
                        if (i == 2) cell.SetCellValue(item.RollsAndLocations[0].RollNumber);
                        if (i == 3) cell.SetCellValue(item.TotalCount);
                        if (i == 4) cell.SetCellValue(item.RollsAndLocations[0].BuildingOrWarehouse);
                        if (i == 6) cell.SetCellValue(item.RollsAndLocations[0].TRackNumber);
                        if (i == 6) cell.SetCellValue(item.RollsAndLocations[0].Rack);
                        if (i == 7) cell.SetCellValue(item.RollsAndLocations[0].PONumber);
                        //if (i == 8) cell.SetCellValue((double)item.RollsAndLocations[0].ShippedQuantity);
                        //if (i == 9) cell.SetCellValue((double)item.RollsAndLocations[0].ReceivedQuantity);
                    }
                }
                //    //else
                //    //{
                //    //    rowNumber = rowNumber - 1;
                //    //    for (int x = 0; x < item.RollsAndLocations.Count; x++)
                //    //    {
                //    //        row = worksheet.CreateRow(rowNumber++);
                //    //        for (int i = 0; i <= 38; i++)
                //    //        {
                //    //            cell = row.CreateCell(i);
                //    //            // row.GetCell(i).CellStyle = CellStyle;
                //    //            if (item.Accountability != null)
                //    //            {
                //    //                if (i == 0) cell.SetCellValue(item.Accountability.DateOfInventory?.ToShortDateString());
                //    //                if (i == 1) cell.SetCellValue(item.Accountability.StockTaker);
                //    //                if (i == 2) cell.SetCellValue(item.Accountability.Validator);
                //    //                if (i == 3) cell.SetCellValue(item.Accountability.SwatchSent?.ToShortDateString());
                //    //                if (i == 4) cell.SetCellValue(item.Accountability.SwatchRecieved?.ToShortDateString());
                //    //                if (i == 5)
                //    //                {
                //    //                    if ((bool)item.Accountability.ConfirmedSwatchRecieved)
                //    //                    {
                //    //                        cell.SetCellValue("Yes");
                //    //                    }
                //    //                    else
                //    //                    {
                //    //                        cell.SetCellValue("No");
                //    //                    }
                //    //                }

                //    //            }

                //    //            if (i == 6) cell.SetCellValue(item.Image);
                //    //            if (i == 7) cell.SetCellValue(item.CategoryValue);
                //    //            if (i == 8) cell.SetCellValue(item.TypeValue);
                //    //            if (i == 9) cell.SetCellValue(item.ItemCode);
                //    //            if (i == 10) cell.SetCellValue(item.ColorCode);
                //    //            if (i == 11) cell.SetCellValue(item.ColorValue);
                //    //            if (i == 12) cell.SetCellValue(item.Pantone);
                //    //            if (i == 13) cell.SetCellValue(item.Weight);
                //    //            if (i == 14) cell.SetCellValue(item.WeightUnitValue);
                //    //            if (i == 15) cell.SetCellValue(item.CuttableWidth?.ToString());
                //    //            if (i == 16) cell.SetCellValue(item.ActualCount);
                //    //            if (i == 17) cell.SetCellValue(item.UnitOfMeasurementValue);

                //    //            if (i == 18) cell.SetCellValue(item.RollsAndLocations[x].RollNumber);
                //    //            if (i == 19) cell.SetCellValue(item.RollsAndLocations[x].DateAcquired.ToShortDateString());
                //    //            if (i == 20) cell.SetCellValue(item.RollsAndLocations[x].ShelfLife.ToString());
                //    //            if (i == 21) cell.SetCellValue(item.RollsAndLocations[x].ConsumeBeforeDate.ToShortDateString());
                //    //            if (i == 22) cell.SetCellValue(item.RollsAndLocations[x].ShadingValue);
                //    //            if (i == 23) cell.SetCellValue(item.RollsAndLocations[x].BuildingOrWarehouse);
                //    //            if (i == 24) cell.SetCellValue(item.RollsAndLocations[x].TRackNumber);
                //    //            if (i == 25) cell.SetCellValue(item.RollsAndLocations[x].Rack);

                //    //            if (i == 26) cell.SetCellValue(item.CompositionAndConstruction.Content);
                //    //            if (i == 27) cell.SetCellValue(item.CompositionAndConstruction.Construction);
                //    //            if (i == 28) cell.SetCellValue(item.CompositionAndConstruction.Gauge);
                //    //            if (i == 29) cell.SetCellValue(item.CompositionAndConstruction.RecycledValue);
                //    //            if (i == 30) cell.SetCellValue(item.CompositionAndConstruction.ExcessValue);
                //    //            if (i == 31) cell.SetCellValue(item.CompositionAndConstruction.PreparedForPrintValue);
                //    //            if (i == 32) cell.SetCellValue(item.CompositionAndConstruction.CompressionValue);
                //    //            if (i == 33) cell.SetCellValue(item.CompositionAndConstruction.FabricStretchValue);
                //    //            if (i == 34) cell.SetCellValue(item.CompositionAndConstruction.CreaseLabel);
                //    //            if (i == 35)
                //    //            {
                //    //                var handfeel = "";
                //    //                if (item.CompositionAndConstruction.HandFeelIds != null)
                //    //                {
                //    //                    HandFeelIds = JsonSerializer.Deserialize<List<int>>(item.CompositionAndConstruction.HandFeelIds);

                //    //                    foreach (var id in HandFeelIds)
                //    //                    {
                //    //                        handfeel += HandFeelListModel.Result.Items.Find(x => x.Id == id).Label + ", ";
                //    //                    }
                //    //                    if (!string.IsNullOrWhiteSpace(handfeel))
                //    //                    {
                //    //                        handfeel = handfeel.Remove(handfeel.Length - 2, 1);
                //    //                    }
                //    //                }
                //    //                cell.SetCellValue(handfeel);
                //    //            }
                //    //            if (i == 36) cell.SetCellValue(item.CompositionAndConstruction.PrintRepeatValue);
                //    //            if (i == 37) cell.SetCellValue(item.CareInstructionTypeLabel);
                //    //            if (i == 38) cell.SetCellValue(item.Company.Name);
                //    //        }
                //    //    }
                //    //}

            }

            for (int i = 0; i <= 10; i++)
            {
                worksheet.AutoSizeColumn(i);
            }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            byte[] bytes = ms.ToArray();
            ms.Close();

            await _materialService.GenerateExcelExport(Module + " list", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task GenerateMaterialExcel()
        {
            await checkMaterial();
            IWorkbook workbook = new XSSFWorkbook();
            var dataFormat = workbook.CreateDataFormat();
            var dataStyle = workbook.CreateCellStyle();
            dataStyle.DataFormat = dataFormat.GetFormat("MM/dd/yyyy HH:mm:ss");
            ISheet worksheet = workbook.CreateSheet(Module);

            // style center of sheet;
            ICellStyle CellStyle = workbook.CreateCellStyle();
            CellStyle.Alignment = HorizontalAlignment.Center;
            CellStyle.WrapText = true; //wrap the text in the cell
            // CellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            // CellStyle.FillPattern = FillPattern.SolidForeground;

            // font style bold setup
            var font = workbook.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            // sheet name


            int rowNumber = 0;
            IRow row = worksheet.CreateRow(rowNumber++);

            // cell merge for main headers
            var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 5);
            var cra1 = new NPOI.SS.Util.CellRangeAddress(0, 0, 6, 15);
            var cra2 = new NPOI.SS.Util.CellRangeAddress(0, 0, 16, 17);
            var cra3 = new NPOI.SS.Util.CellRangeAddress(0, 0, 18, 25);
            var cra4 = new NPOI.SS.Util.CellRangeAddress(0, 0, 26, 36);
            worksheet.AddMergedRegion(cra);
            worksheet.AddMergedRegion(cra1);
            worksheet.AddMergedRegion(cra2);
            worksheet.AddMergedRegion(cra3);
            worksheet.AddMergedRegion(cra4);

            #region Header Main titles
            ICell cell = row.CreateCell(0);
            row.GetCell(0).CellStyle = CellStyle;
            cell.SetCellValue("ACCOUNTABILITY");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(6);
            row.GetCell(6).CellStyle = CellStyle;
            cell.SetCellValue("OVERVIEW");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(16);
            row.GetCell(16).CellStyle = CellStyle;
            cell.SetCellValue("INVENTORY");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(18);
            row.GetCell(18).CellStyle = CellStyle;
            cell.SetCellValue("ROLL AND LOCATION");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(26);
            row.GetCell(26).CellStyle = CellStyle;
            cell.SetCellValue("COMPOSITION AND CONSTRUCTION");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(37);
            row.GetCell(37).CellStyle = CellStyle;
            cell.SetCellValue("MISCELLANEOUS");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(38);
            row.GetCell(38).CellStyle = CellStyle;
            cell.SetCellValue("SUPPLIER DETAILS");
            cell.CellStyle.SetFont(font);

            #endregion

            #region Header Subtitles

            row = worksheet.CreateRow(1); // setup for row 1 for sub titles
            for (int i = 0; i <= 38; i++)
            {
                cell = row.CreateCell(i);
                if (i == 0) cell.SetCellValue("Date of Inventory*");
                if (i == 1) cell.SetCellValue("Stocktaker*");
                if (i == 2) cell.SetCellValue("Validator*");
                if (i == 3) cell.SetCellValue("Swatch Sent");
                if (i == 4) cell.SetCellValue("Swatch Received");
                if (i == 5) cell.SetCellValue("Confirmed Swatch Received*");
                if (i == 6) cell.SetCellValue("Image");
                if (i == 7) cell.SetCellValue("Category*");
                if (i == 8) cell.SetCellValue("Material Type*");
                if (i == 9) cell.SetCellValue("Item Code (OEM)*");
                if (i == 10) cell.SetCellValue("Color Code (OEM)*");
                if (i == 11) cell.SetCellValue("Color Group*");
                if (i == 12) cell.SetCellValue("Pantone # (TCX Code)");
                if (i == 13) cell.SetCellValue("Weight*");
                if (i == 14) cell.SetCellValue("Weight Unit*");
                if (i == 15) cell.SetCellValue("Cuttable Width");
                if (i == 16) cell.SetCellValue("Actual Count*");
                if (i == 17) cell.SetCellValue("Unit of Measurement*");
                if (i == 18) cell.SetCellValue("Roll Number*");
                if (i == 19) cell.SetCellValue("Date Acquired*");
                if (i == 20) cell.SetCellValue("Shelf Life (Years)*");
                if (i == 21) cell.SetCellValue("Consume Before Date*");
                if (i == 22) cell.SetCellValue("Shading*");
                if (i == 23) cell.SetCellValue("Building / Warehouse*");
                if (i == 24) cell.SetCellValue("T-Rack Number*");
                if (i == 25) cell.SetCellValue("Rack*");
                if (i == 26) cell.SetCellValue("Content*");
                if (i == 27) cell.SetCellValue("Construction*");
                if (i == 28) cell.SetCellValue("Gauge");
                if (i == 29) cell.SetCellValue("Recycled*");
                if (i == 30) cell.SetCellValue("Excess*");
                if (i == 31) cell.SetCellValue("PFP*");
                if (i == 32) cell.SetCellValue("Compression");
                if (i == 33) cell.SetCellValue("Fabric Stretch*");
                if (i == 34) cell.SetCellValue("Crease*");
                if (i == 35) cell.SetCellValue("Hand Feel*");
                if (i == 36) cell.SetCellValue("Print Repeat");
                if (i == 37) cell.SetCellValue("Care Instructions Type*");
                if (i == 38) cell.SetCellValue("Company Name*");
                cell.CellStyle.SetFont(font);
            }
            #endregion

            rowNumber = 2; // start of material details
            foreach (var item in ExcelMaterialData.Materials)
            {
                // System.Console.WriteLine(JsonSerializer.Serialize(item));
                // System.Console.WriteLine(item.RollsAndLocations.Count);
                row = worksheet.CreateRow(rowNumber++);
                if (item.RollsAndLocations.Count == 1 || item.RollsAndLocations.Count == 0)
                {
                    for (int i = 0; i <= 38; i++)
                    {
                        cell = row.CreateCell(i);
                        // row.GetCell(i).CellStyle = CellStyle;
                        if (item.Accountability != null)
                        {
                            if (i == 0) cell.SetCellValue(item.Accountability.DateOfInventory?.ToShortDateString());
                            if (i == 1) cell.SetCellValue(item.Accountability.StockTaker);
                            if (i == 2) cell.SetCellValue(item.Accountability.Validator);
                            if (i == 3) cell.SetCellValue(item.Accountability.SwatchSent?.ToShortDateString());
                            if (i == 4) cell.SetCellValue(item.Accountability.SwatchRecieved?.ToShortDateString());
                            if (i == 5)
                            {
                                if ((bool)item.Accountability.ConfirmedSwatchRecieved)
                                {
                                    cell.SetCellValue("Yes");
                                }
                                else
                                {
                                    cell.SetCellValue("No");
                                }
                            }
                        }

                        if (i == 6) cell.SetCellValue(item.Image);
                        if (i == 7) cell.SetCellValue(item.CategoryValue);
                        if (i == 8) cell.SetCellValue(item.TypeValue);
                        if (i == 9) cell.SetCellValue(item.ItemCode);
                        if (i == 10) cell.SetCellValue(item.ColorCode);
                        if (i == 11) cell.SetCellValue(item.ColorValue);
                        if (i == 12) cell.SetCellValue(item.Pantone);
                        if (i == 13) cell.SetCellValue((double)item.Weight);
                        if (i == 14) cell.SetCellValue(item.WeightUnitValue);
                        if (i == 15) cell.SetCellValue(item.CuttableWidth?.ToString());
                        if (i == 16) cell.SetCellValue(item.TotalCount);
                        if (i == 17) cell.SetCellValue(item.UnitOfMeasurementValue);

                        if (item.RollsAndLocations.Count == 1)
                        {
                            if (i == 18) cell.SetCellValue(item.RollsAndLocations[0].RollNumber);
                            if (i == 19) cell.SetCellValue(item.RollsAndLocations[0].DateAcquired.ToShortDateString());
                            if (i == 20) cell.SetCellValue(item.RollsAndLocations[0].ShelfLife.ToString());
                            if (i == 21) cell.SetCellValue(item.RollsAndLocations[0].ConsumeBeforeDate.ToShortDateString());
                            if (i == 22) cell.SetCellValue(item.RollsAndLocations[0].ShadingValue);
                            if (i == 23) cell.SetCellValue(item.RollsAndLocations[0].BuildingOrWarehouse);
                            if (i == 24) cell.SetCellValue(item.RollsAndLocations[0].TRackNumber);
                            if (i == 25) cell.SetCellValue(item.RollsAndLocations[0].Rack);
                        }


                        if (i == 26) cell.SetCellValue(item.CompositionAndConstruction.Content);
                        if (i == 27) cell.SetCellValue(item.CompositionAndConstruction.Construction);
                        if (i == 28) cell.SetCellValue(item.CompositionAndConstruction.Gauge);
                        if (i == 26) cell.SetCellValue(item.CompositionAndConstruction.Content);
                        if (i == 27) cell.SetCellValue(item.CompositionAndConstruction.Construction);
                        if (i == 28) cell.SetCellValue(item.CompositionAndConstruction.Gauge);
                        if (i == 29) cell.SetCellValue(item.CompositionAndConstruction.RecycledValue);
                        if (i == 30) cell.SetCellValue(item.CompositionAndConstruction.ExcessValue);
                        if (i == 31) cell.SetCellValue(item.CompositionAndConstruction.PreparedForPrintValue);
                        if (i == 32) cell.SetCellValue(item.CompositionAndConstruction.CompressionValue);
                        if (i == 33) cell.SetCellValue(item.CompositionAndConstruction.FabricStretchValue);
                        if (i == 34) cell.SetCellValue(item.CompositionAndConstruction.CreaseLabel);
                        if (i == 35)
                        {
                            if (!string.IsNullOrWhiteSpace(item.CompositionAndConstruction.HandFeelIds))
                            {
                                HandFeelIds = JsonSerializer.Deserialize<List<int>>(item.CompositionAndConstruction.HandFeelIds);
                                var handfeel = "";
                                foreach (var id in HandFeelIds)
                                {
                                    handfeel += HandFeelListModel.Result.Items.Find(x => x.Id == id).Label + ", ";
                                }
                                if (!string.IsNullOrWhiteSpace(handfeel))
                                {
                                    handfeel = handfeel.Remove(handfeel.Length - 2, 1);
                                }
                                cell.SetCellValue(handfeel);
                            }
                        }
                        if (i == 36) cell.SetCellValue(item.CompositionAndConstruction.PrintRepeatValue);
                        if (i == 37) cell.SetCellValue(item.CareInstructionTypeLabel);
                        if (i == 38) cell.SetCellValue(item.Company.Name);
                    }
                }
                else
                {
                    rowNumber = rowNumber - 1;
                    for (int x = 0; x < item.RollsAndLocations.Count; x++)
                    {
                        row = worksheet.CreateRow(rowNumber++);
                        for (int i = 0; i <= 38; i++)
                        {
                            cell = row.CreateCell(i);
                            // row.GetCell(i).CellStyle = CellStyle;
                            if (item.Accountability != null)
                            {
                                if (i == 0) cell.SetCellValue(item.Accountability.DateOfInventory?.ToShortDateString());
                                if (i == 1) cell.SetCellValue(item.Accountability.StockTaker);
                                if (i == 2) cell.SetCellValue(item.Accountability.Validator);
                                if (i == 3) cell.SetCellValue(item.Accountability.SwatchSent?.ToShortDateString());
                                if (i == 4) cell.SetCellValue(item.Accountability.SwatchRecieved?.ToShortDateString());
                                if (i == 5)
                                {
                                    if ((bool)item.Accountability.ConfirmedSwatchRecieved)
                                    {
                                        cell.SetCellValue("Yes");
                                    }
                                    else
                                    {
                                        cell.SetCellValue("No");
                                    }
                                }

                            }

                            if (i == 6) cell.SetCellValue(item.Image);
                            if (i == 7) cell.SetCellValue(item.CategoryValue);
                            if (i == 8) cell.SetCellValue(item.TypeValue);
                            if (i == 9) cell.SetCellValue(item.ItemCode);
                            if (i == 10) cell.SetCellValue(item.ColorCode);
                            if (i == 11) cell.SetCellValue(item.ColorValue);
                            if (i == 12) cell.SetCellValue(item.Pantone);
                            if (i == 13) cell.SetCellValue((double)item.Weight);
                            if (i == 14) cell.SetCellValue(item.WeightUnitValue);
                            if (i == 15) cell.SetCellValue(item.CuttableWidth);
                            if (i == 16) cell.SetCellValue(item.TotalCount);
                            if (i == 17) cell.SetCellValue(item.UnitOfMeasurementValue);

                            if (i == 18) cell.SetCellValue(item.RollsAndLocations[x].RollNumber);
                            if (i == 19) cell.SetCellValue(item.RollsAndLocations[x].DateAcquired.ToShortDateString());
                            if (i == 20) cell.SetCellValue(item.RollsAndLocations[x].ShelfLife.ToString());
                            if (i == 21) cell.SetCellValue(item.RollsAndLocations[x].ConsumeBeforeDate.ToShortDateString());
                            if (i == 22) cell.SetCellValue(item.RollsAndLocations[x].ShadingValue);
                            if (i == 23) cell.SetCellValue(item.RollsAndLocations[x].BuildingOrWarehouse);
                            if (i == 24) cell.SetCellValue(item.RollsAndLocations[x].TRackNumber);
                            if (i == 25) cell.SetCellValue(item.RollsAndLocations[x].Rack);

                            if (i == 26) cell.SetCellValue(item.CompositionAndConstruction.Content);
                            if (i == 27) cell.SetCellValue(item.CompositionAndConstruction.Construction);
                            if (i == 28) cell.SetCellValue(item.CompositionAndConstruction.Gauge);
                            if (i == 29) cell.SetCellValue(item.CompositionAndConstruction.RecycledValue);
                            if (i == 30) cell.SetCellValue(item.CompositionAndConstruction.ExcessValue);
                            if (i == 31) cell.SetCellValue(item.CompositionAndConstruction.PreparedForPrintValue);
                            if (i == 32) cell.SetCellValue(item.CompositionAndConstruction.CompressionValue);
                            if (i == 33) cell.SetCellValue(item.CompositionAndConstruction.FabricStretchValue);
                            if (i == 34) cell.SetCellValue(item.CompositionAndConstruction.CreaseLabel);
                            if (i == 35)
                            {
                                var handfeel = "";
                                if (item.CompositionAndConstruction.HandFeelIds != null)
                                {
                                    HandFeelIds = JsonSerializer.Deserialize<List<int>>(item.CompositionAndConstruction.HandFeelIds);

                                    foreach (var id in HandFeelIds)
                                    {
                                        handfeel += HandFeelListModel.Result.Items.Find(x => x.Id == id).Label + ", ";
                                    }
                                    if (!string.IsNullOrWhiteSpace(handfeel))
                                    {
                                        handfeel = handfeel.Remove(handfeel.Length - 2, 1);
                                    }
                                }
                                cell.SetCellValue(handfeel);
                            }
                            if (i == 36) cell.SetCellValue(item.CompositionAndConstruction.PrintRepeatValue);
                            if (i == 37) cell.SetCellValue(item.CareInstructionTypeLabel);
                            if (i == 38) cell.SetCellValue(item.Company.Name);
                        }
                    }
                }

            }

            for (int i = 0; i <= 38; i++)
            {
                worksheet.AutoSizeColumn(i);
            }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            byte[] bytes = ms.ToArray();
            ms.Close();

            await _materialService.GenerateExcelExport(Module + " list", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        public async Task GenerateSubMaterialExcel()
        {
            await checkMaterial();
            IWorkbook workbook = new XSSFWorkbook();
            var dataFormat = workbook.CreateDataFormat();
            var dataStyle = workbook.CreateCellStyle();
            dataStyle.DataFormat = dataFormat.GetFormat("MM/dd/yyyy HH:mm:ss");
            ISheet worksheet = workbook.CreateSheet(Module);

            // style center of sheet;
            ICellStyle CellStyle = workbook.CreateCellStyle();
            CellStyle.Alignment = HorizontalAlignment.Center;
            CellStyle.WrapText = true; //wrap the text in the cell
            // CellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            // CellStyle.FillPattern = FillPattern.SolidForeground;

            // font style bold setup
            var font = workbook.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            // sheet name


            int rowNumber = 0;
            IRow row = worksheet.CreateRow(rowNumber++);

            // cell merge for main headers
            var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 5);
            var cra1 = new NPOI.SS.Util.CellRangeAddress(0, 0, 6, 12);
            var cra2 = new NPOI.SS.Util.CellRangeAddress(0, 0, 13, 14);
            var cra3 = new NPOI.SS.Util.CellRangeAddress(0, 0, 15, 17);
            worksheet.AddMergedRegion(cra);
            worksheet.AddMergedRegion(cra1);
            worksheet.AddMergedRegion(cra2);
            worksheet.AddMergedRegion(cra3);

            #region Header Main titles
            ICell cell = row.CreateCell(0);
            row.GetCell(0).CellStyle = CellStyle;
            cell.SetCellValue("ACCOUNTABILITY");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(6);
            row.GetCell(6).CellStyle = CellStyle;
            cell.SetCellValue("OVERVIEW");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(13);
            row.GetCell(13).CellStyle = CellStyle;
            cell.SetCellValue("INVENTORY");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(15);
            row.GetCell(15).CellStyle = CellStyle;
            cell.SetCellValue("LOCATION");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(18);
            row.GetCell(18).CellStyle = CellStyle;
            cell.SetCellValue("SUPPLIER DETAILS");
            cell.CellStyle.SetFont(font);

            #endregion

            #region Header Subtitles

            row = worksheet.CreateRow(1); // setup for row 1 for sub titles
            for (int i = 0; i <= 18; i++)
            {
                cell = row.CreateCell(i);
                if (i == 0) cell.SetCellValue("Date of Inventory*");
                if (i == 1) cell.SetCellValue("Stocktaker*");
                if (i == 2) cell.SetCellValue("Validator*");
                if (i == 3) cell.SetCellValue("Swatch Sent");
                if (i == 4) cell.SetCellValue("Swatch Received");
                if (i == 5) cell.SetCellValue("Confirmed Swatch Received*");
                if (i == 6) cell.SetCellValue("Image");
                if (i == 7) cell.SetCellValue("Category*");
                if (i == 8) cell.SetCellValue("Material Name*");
                if (i == 9) cell.SetCellValue("Material Type*");
                if (i == 10) cell.SetCellValue("Color*");
                if (i == 11) cell.SetCellValue("Weight");
                if (i == 12) cell.SetCellValue("Weight Unit");
                if (i == 13) cell.SetCellValue("Actual Count*");
                if (i == 14) cell.SetCellValue("Unit of Measurement*");
                if (i == 15) cell.SetCellValue("Building / Warehouse*");
                if (i == 16) cell.SetCellValue("T-Rack Number*");
                if (i == 17) cell.SetCellValue("Rack*");
                if (i == 18) cell.SetCellValue("Company Name*");
                cell.CellStyle.SetFont(font);
            }
            #endregion

            rowNumber = 2; // start of material details
            foreach (var item in ExcelSubMaterialData.SubMaterials)
            {
                // System.Console.WriteLine(JsonSerializer.Serialize(item));
                row = worksheet.CreateRow(rowNumber++);
                for (int i = 0; i <= 18; i++)
                {
                    cell = row.CreateCell(i);
                    // row.GetCell(i).CellStyle = CellStyle;
                    if (item.Accountability != null)
                    {
                        if (i == 0) cell.SetCellValue(item.Accountability.DateOfInventory?.ToShortDateString());
                        if (i == 1) cell.SetCellValue(item.Accountability.StockTaker);
                        if (i == 2) cell.SetCellValue(item.Accountability.Validator);
                        if (i == 3) cell.SetCellValue(item.Accountability.SwatchSent?.ToShortDateString());
                        if (i == 4) cell.SetCellValue(item.Accountability.SwatchRecieved?.ToShortDateString());
                        if (i == 5)
                        {
                            if ((bool)item.Accountability.ConfirmedSwatchRecieved)
                            {
                                cell.SetCellValue("Yes");
                            }
                            else
                            {
                                cell.SetCellValue("No");
                            }
                        }
                    }

                    if (i == 6) cell.SetCellValue(item.Image);
                    if (i == 7) cell.SetCellValue(item.CategoryValue);
                    if (i == 8) cell.SetCellValue(item.Name);
                    if (i == 9) cell.SetCellValue(item.TypeValue);
                    if (i == 10) cell.SetCellValue(item.ColorValue);
                    if (i == 11) cell.SetCellValue(item.Weight.GetValueOrDefault());
                    if (i == 12) cell.SetCellValue(item.WeightUnitValue);
                    if (i == 13) cell.SetCellValue(item.TotalCount);
                    if (i == 14) cell.SetCellValue(item.UnitOfMeasurementValue);
                    if (i == 15) cell.SetCellValue(item.Location.BuildingWarehouse);
                    if (i == 16) cell.SetCellValue(item.Location.Room);
                    if (i == 17) cell.SetCellValue(item.Location.Rack);
                    if (i == 18) cell.SetCellValue(item.Company.Name);
                }

            }

            for (int i = 0; i <= 18; i++)
            {
                worksheet.AutoSizeColumn(i);
            }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            byte[] bytes = ms.ToArray();
            ms.Close();

            await _materialService.GenerateExcelExport(Module + " list", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        public async Task GetFilteredByWarehouse()
        {
            try
            {
                FilteredByWarehouseMaterialListModel.Materials.Clear();

                foreach (var warehouse in _selectedWarehouses)
                {
                    foreach (var material in MaterialListModel.Materials)
                    {
                        if (material.RollsAndLocations.Exists(r => r.BuildingOrWarehouse == warehouse))
                            FilteredByWarehouseMaterialListModel.Materials.Add(material);
                    }
                }
                if (!_selectedWarehouses.Any())
                    FilteredByWarehouseMaterialListModel.Materials.AddRange(MaterialListModel.Materials);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }
        public async Task GetFilteredByColor()
        {
            try
            {
                FilteredByColorMaterialListModel.Materials.Clear();
                foreach (var color in _selectedColors) FilteredByColorMaterialListModel.Materials.AddRange(MaterialListModel.Materials.FindAll(m => m.ColorValue == color));

                if (!_selectedColors.Any())
                    FilteredByColorMaterialListModel.Materials.AddRange(MaterialListModel.Materials);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task GetFilteredByMaterialType()
        {
            try
            {
                FilteredByMaterialTypeMaterialListModel.Materials.Clear();
                foreach (var materialType in _selectedMaterialTypes) FilteredByMaterialTypeMaterialListModel.Materials.AddRange(MaterialListModel.Materials.FindAll(m => m.TypeValue == materialType));

                if (!_selectedMaterialTypes.Any())
                    FilteredByMaterialTypeMaterialListModel.Materials.AddRange(MaterialListModel.Materials);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task Search()
        {
            try
            {
                await GetFilteredByMaterialType();
                await GetFilteredByColor();
                await GetFilteredByWarehouse();


                _materials = MaterialListModel.Materials;
                _materials = _materials.Intersect(FilteredByWarehouseMaterialListModel.Materials);
                _materials = _materials.Intersect(FilteredByMaterialTypeMaterialListModel.Materials);
                _materials = _materials.Intersect(FilteredByColorMaterialListModel.Materials);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task ClearAll()
        {

            _selectedWarehouses.Clear();
            _selectedColors.Clear();
            _selectedMaterialTypes.Clear();

            _materials = MaterialListModel.Materials;

            WarehouseText = "Select Warehouse";
            ColorText = "Select Color";
            MaterialTypeText = "Select Material Type";
        }

        private bool OnCustomFilter(MaterialModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        private bool OnCustomFilterSubmaterial(SubMaterialModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task OnClickRow(int categoryId, Guid id)
        {
            var module = "";
            if (categoryId == 1)
            {
                module = "greige";
            }
            if (categoryId == 2)
            {
                module = "fabric";
            }
            if (categoryId == 3)
            {
                module = "trimsandaccessories";
            }
            if (categoryId == 4)
            {
                module = "packaging";
            }
            if (categoryId == 99)
            {
                module = "others";
            }
            var url = $"/inventory/{module}/detail/{id}";
            NavigationManager.NavigateTo(url);
        }

        public async Task OnChangeWarehouse(string value, string checkedValue)
        {
            try
            {
                bool isChecked = bool.Parse(checkedValue);

                if (isChecked)
                {
                    if (!_selectedWarehouses.Contains(value))
                    {
                        _selectedWarehouses.Add(value);
                    }
                }
                else
                {
                    if (_selectedWarehouses.Contains(value))
                    {
                        _selectedWarehouses.Remove(value);
                    }
                }
                WarehouseText = String.Join(", ", _selectedWarehouses);

                if (string.IsNullOrWhiteSpace(WarehouseText))
                {
                    WarehouseText = "Select Warehouse";
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }

        }

        public async Task OnChangeColor(string value, string checkedValue)
        {
            try
            {
                bool isChecked = bool.Parse(checkedValue);

                if (isChecked)
                {
                    if (!_selectedColors.Contains(value))
                    {
                        _selectedColors.Add(value);
                    }
                }
                else
                {
                    if (_selectedColors.Contains(value))
                    {
                        _selectedColors.Remove(value);
                    }
                }
                ColorText = String.Join(", ", _selectedColors);

                if (string.IsNullOrWhiteSpace(ColorText))
                {
                    ColorText = "Select Color";
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task OnChangeMaterialType(string value, string checkedValue)
        {
            try
            {
                bool isChecked = bool.Parse(checkedValue);

                if (isChecked)
                {
                    if (!_selectedMaterialTypes.Contains(value))
                    {
                        _selectedMaterialTypes.Add(value);
                    }
                }
                else
                {
                    if (_selectedMaterialTypes.Contains(value))
                    {
                        _selectedMaterialTypes.Remove(value);
                    }
                }
                MaterialTypeText = String.Join(", ", _selectedMaterialTypes);

                if (string.IsNullOrWhiteSpace(MaterialTypeText))
                {
                    MaterialTypeText = "Select Material Type";
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }
    }
}