using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses;
using SSY.Blazor.HttpClients.Data.Inventory.ProductAssignments.Model;
using SSY.Blazor.HttpClients.RefitServices.Products.Shopifies;
using SSY.Blazor.Pages.Shared.Components.ModalMassUpload;
using Volo.Abp;

namespace SSY.Blazor.Pages.CollectionAndProduct.Components.Collections
{
    public partial class Collections
    {
        public Collections()
        {
        }
        private string Module = "Collections";
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject] IShopifyApi shopifyApi { get; set; }
        public CollectionService _collectionService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private ProductAssignmentService _productAssignmentService { get; set; }
        private CollectionDesignStatusService _collectionDesignStatusService { get; set; }
        private ProductService _productService { get; set; }
        private CollectionStatusService _collectionStatusService { get; set; }
        public MaterialService _materialService { get; set; }
        public ReservationService _reservationService { get; set; }

        private IEnumerable<CollectionListDto> _CollectionListModel { get; set; }
        private IEnumerable<CollectionOutputModel> _CollectionOutputModel { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }

        [Parameter]
        public string PageName { get; set; }

        public GetAllCollectionOutputModel CollectionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllProductAssignmentOutputModel ProductAssignmentModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public GetAllMaterialOutputModel MaterialListModel { get; set; } = new() { Result = new() { Items = new() } };

        public List<CollectionListDto> CollectionList { get; set; } = new();

        private bool isSortedAscending;
        private string activeSortColumn;
        string provisionalLaunchDate = string.Empty;
        private string customFilterValue;

        public GetAllProductOutputModel ProductListModel { get; set; } = new() { Items = new() };

        public List<Guid> CollectionIds { get; set; } = new();
        private bool IsLoading;
        private Modal ModalWaiting;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetAllCollection();
            }
            await js.InvokeVoidAsync("loadMultiSelectSearch");

            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
                _productAssignmentService = new(js, ClientFactory, NavigationManager, Configuration);
                _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionDesignStatusService = new(js, ClientFactory, NavigationManager, Configuration);
                _productService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionStatusService = new(js, ClientFactory, NavigationManager, Configuration);
                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _reservationService = new(js, ClientFactory, NavigationManager, Configuration);

                MaterialListModel = await _materialService.GetAllMaterial(2, null, null, null, null, 10000);

                ProductAssignmentModel = await _productAssignmentService.GetAllProductAssignment(null, null, null, 100);

                await GetAllCollection();
                await base.OnInitializedAsync();
                IsLoading = false;
            }

            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        private bool OnCustomFilter(CollectionListDto model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task OnDeleteHandler(Guid Id)
        {
            try
            {
                await ShowWaitingModal();

                List<Guid> reservationIds = new();
                List<Guid> reservedRollIds = new();
                List<Guid> productIds = new();

                var collection = CollectionList.Find(x => x.Id == Id);

                collection.ColorOptions.ForEach(colorOption =>
                {
                    colorOption.Fabrics.ForEach(fabric => {
                        fabric.Rolls.ForEach(x => reservedRollIds.Add(x.RollId));
                    });
                });

                collection.ColorOptions.ForEach(colorOption =>
                {
                    colorOption.Fabrics.ForEach(fabric => {

                        var material = MaterialListModel.Result.Items.FirstOrDefault(m => m.Id == fabric.MaterialId);

                        material.RollsAndLocations.ForEach(x =>
                        {
                            x.RollReservations.FindAll(f => f.CollectionId == colorOption.CollectionId).ForEach(r =>
                            {
                                if (reservedRollIds.Any(a => a == r.RollId))
                                    reservationIds.Add(r.ReservationId);
                            });
                        });

                    });
                });

                if (reservationIds.Count != 0)
                    await _reservationService.DeleteMaterialReservationList(reservationIds);

                await _collectionService.DeleteCollectionV2(Id);
                await HideWaitingModal();
                await GetAllCollection();
            }
            catch (Exception ex)
            {
                await HideWaitingModal();
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - OnDeleteHandler()");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task GetAllCollection()
        {
            CollectionList = (await _collectionService.GetAllCollectionList()).Items;

            CollectionList.ForEach(collection =>
            {

                if (collection.StatusValue.Equals("Confirmed"))
                    collection.StatusHexCode = "7B8E61";
                else if (collection.StatusValue.Equals("On Hold"))
                    collection.StatusHexCode = "F2F2F2";
                else if (collection.StatusValue.Equals("In Progress"))
                    collection.StatusHexCode = "FF8A34";
                else
                    collection.StatusHexCode = "F2F2F2";
            });

            _CollectionListModel = CollectionList;
        }

        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                CollectionListModel.Result.Items = CollectionListModel.Result.Items.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;

            }
            else
            {
                if (isSortedAscending)
                {
                    CollectionListModel.Result.Items = CollectionListModel.Result.Items.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    CollectionListModel.Result.Items = CollectionListModel.Result.Items.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }

                isSortedAscending = !isSortedAscending;
            }
        }

        private string SetSortIcon(string columnName)
        {
            if (activeSortColumn != columnName)
            {
                return "fa fa-sort";
            }
            if (isSortedAscending)
            {
                return "fa fa-sort-up";
            }
            else
            {
                return "fa fa-sort-down";
            }
        }

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

        public async Task onChangeCheckBoxAll(bool checkedValue)
        {

            if (checkedValue)
            {
                foreach (var item in CollectionList)
                {
                    CollectionIds.Add(item.Id);
                }
            }
            else
            {
                CollectionIds.Clear();

            }
        }

        public async Task onChangeCheckBox(Guid id, bool checkedValue)
        {
            if (checkedValue)
            {
                if (!CollectionIds.Contains(id))
                {
                    CollectionIds.Add(id);
                }
            }
            else
            {
                if (CollectionIds.Contains(id))
                {
                    CollectionIds.Remove(id);
                }

            }
        }

        public async Task UnCheckAll()
        {
            CollectionIds.Clear();
        }

        public async Task DeleteSelectedIds()
        {
            try
            {
                await ShowWaitingModal();
                foreach (var id in CollectionIds)
                {
                    List<Guid> reservationIds = new();
                    List<Guid> reservedRollIds = new();

                    var collection = CollectionListModel.Result.Items.Find(x => x.Id == id);

                    collection.ColorOptions.ForEach(colorOption =>
                    {

                        colorOption.ColorOption.Rolls.ForEach(x =>
                        {
                            reservedRollIds.Add(x.RollId);
                        });

                        var material = MaterialListModel.Result.Items.FirstOrDefault(m => m.Id == colorOption.ColorOption.MaterialId);

                        material.RollsAndLocations.ForEach(x =>
                        {
                            x.RollReservations.FindAll(f => f.CollectionId == colorOption.CollectionId).ForEach(r =>
                            {
                                if (reservedRollIds.Any(a => a == r.RollId))
                                    reservationIds.Add(r.ReservationId);
                            });
                        });

                    });

                    reservationIds.ForEach(async item =>
                    {
                        // Delete Reservation Entry
                        await _deleteDataByIdService.DeleteDataById<DeleteModel>(item, "Reservation");
                    });

                    await _collectionService.DeleteCollectionV2(id);

                }
                await HideWaitingModal();
                //await js.InvokeVoidAsync("defaultMessage", "success", "Successfully Deleted!", "");
                await GetAllCollection();
                CollectionIds.Clear();
            }
            catch (Exception ex)
            {
                await HideWaitingModal();
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        private async Task OnCollectionAvailability(ChangeEventArgs args, CollectionListDto context)
        {
            if (!((bool)args.Value)) return;
            var res = await shopifyApi.CreateCustomCollectionAsync(new()
            {
                Title = context.Name,
                Published = true,
            }, context.Id);
            if (res.IsSuccessStatusCode)
            {
                context.Availability = true;
                await js.InvokeVoidAsync("defaultMessage", "success", "Collection successfully pushed to Shopify", "");
            }
        }

        private Task ShowWaitingModal()
        {
            return ModalWaiting.Show();
        }

        private Task HideWaitingModal()
        {
            return ModalWaiting.Hide();
        }
    }

}