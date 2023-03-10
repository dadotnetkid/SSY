using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Calendar.Model;
using SSY.Blazor.HttpClients.Models.Products.Collections.Calendars;

namespace SSY.Blazor.Pages.CollectionAndProduct.Components.Calendar
{
    public partial class Calendar
    {
        public Calendar()
        {
        }
        public string ModuleChange = "";
        public string Module = "Calendar";
        public string ModuleMessage = "";
        public string CollectionDetails = "Calendar";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject] public ICalendarApi CalendarApi { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        public CalendarModel CalendarList { get; set; }
        public List<CalendarModel> CalendarListSample { get; set; } = new();

        string actual = "Actual";
        string target = "Target";
        private bool isSortedAscending;
        private string activeSortColumn;
        public List<CalendarCollectionModel> CalendarCollectionList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var getCalendarResponse = await CalendarApi.GetCalendar();
            if (getCalendarResponse.IsSuccessStatusCode)
            {
                CalendarCollectionList = getCalendarResponse.Content.Items;
            }

            #region comment remove later
            /* CalendarListSample = CalendarListSample ?? new();
           CalendarList = CalendarList ?? new();

           DateTime aDate = DateTime.Now;

           CalendarList.CollectionName = "Jhun Camit";
           CalendarList.SalesForeCastQuantity = 500;
           CalendarList.ActualSalesQuantity = 500;
           CalendarList.EligibleForReDropNewCollection = "Yes";
           if (actual == "Actual")
           {
               CalendarList.TargetVsActual = actual;
           }
           if (target == "Target")
           {
               CalendarList.TargetVsActual = target;
           }
           CalendarList.CollectionDevelopment = aDate;
           CalendarList.ProductOnBoarded = aDate;
           CalendarList.DesignDraftUploaded = aDate;
           CalendarList.DesignDraftRejectedByDesignHead = aDate;
           CalendarList.DesignDraftApprovedByDesignHead = aDate;
           CalendarList.DesignDraftRejectedByInfluencer = aDate;
           CalendarList.DesignDraftApprovedByInfluencer = aDate;
           CalendarList.CreateProductOptions = aDate;
           CalendarList.TwoDTechnicalDesignBoardUploaded = aDate;
           CalendarList.ThreeDVirtualFittingOrderPlaced = aDate;
           CalendarList.ThreeDVirtualFittingPreviewsUploaded = aDate;
           CalendarList.ThreeDVirtualFittingPreviewsRejected = aDate;
           CalendarList.ThreeDVirtualFittingPreviewsApproved = aDate;
           CalendarList.AllFinalThreeDVirtualFittingsUploaded = aDate;
           CalendarList.FinalThreeDVirtualFittingsRejectedByInfluencer = aDate;
           CalendarList.FinalThreeDVirtualFittingsApprovedByInfluencer = aDate;
           CalendarList.ThreeDTechnicalDesignBoardUploaded = aDate;
           CalendarList.MockupOrdered = aDate;
           CalendarList.MockupImagesUploaded = aDate;
           CalendarList.MockupImagesRejectedByDesignHead = aDate;
           CalendarList.MockupImagesApprovedByDesignHead = aDate;
           CalendarList.FirstFitSampleOrdered = aDate;
           CalendarList.ODMFirstPatternReview = aDate;
           CalendarList.ODMFirstFitSampleProduction = aDate;
           CalendarList.FirstFitSampleImagesUploaded = aDate;
           CalendarList.FirstFitSampleRejectedByDesignHead = aDate;
           CalendarList.FirstFitSampleApprovedByDesignHead = aDate;
           CalendarList.FirstFitSampleShipped = aDate;
           CalendarList.FirstFitSampleDelivered = aDate;
           CalendarList.FirstFitSampleApprovedByInfluencer = aDate;
           CalendarList.FirstFitSampleRejectedByInfluencer = aDate;

           CalendarList.SecondFitSampleOrdered = aDate;
           CalendarList.ODMSecondPatternReview = aDate;
           CalendarList.ODMSecondFitSampleProduction = aDate;
           CalendarList.SecondFitSampleImagesUploaded = aDate;
           CalendarList.SecondFitSampleRejectedByDesignHead = aDate;
           CalendarList.SecondFitSampleApprovedByDesignHead = aDate;
           CalendarList.SecondFitSampleShipped = aDate;
           CalendarList.SecondFitSampleDelivered = aDate;
           CalendarList.SecondFitSampleApprovedByInfluencer = aDate;
           CalendarList.SecondFitSampleRejectedByInfluencer = aDate;
           CalendarList.PhotoshootSampleOrdered = aDate;
           CalendarList.PhotoshootSampleProduction = aDate;
           CalendarList.PhotoshootSampleImagesUploaded = aDate;
           CalendarList.PhotoshootSampleRejectedByDesignHead = aDate;
           CalendarList.PhotoshootSampleApprovedByDesignHead = aDate;
           CalendarList.PhotoshootSampleShipped = aDate;
           CalendarList.PhotoshootSampleDelivered = aDate;
           CalendarList.PhotoshootSampleApprovedByInfluencer = aDate;
           CalendarList.PhotoshootSampleRejectedByInfluencer = aDate;
           CalendarList.ReadyForLaunch = aDate;
           CalendarList.TentativeReadyForLaunch = aDate;
           CalendarList.MarketingSampleOrdered = aDate;
           CalendarList.MarketingSampleShipped = aDate;
           CalendarList.LaunchDate = aDate;
           CalendarList.TentativeLaunchDate = aDate;


           CalendarListSample.Add(CalendarList);
           Console.WriteLine(JsonSerializer.Serialize(CalendarList));*/


            #endregion

            StateHasChanged();
        }



        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                CalendarListSample = CalendarListSample.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;

            }
            else
            {
                if (isSortedAscending)
                {
                    CalendarListSample = CalendarListSample.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    CalendarListSample = CalendarListSample.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
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
    }
}