using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Drops.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Factories.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.MarketingTypes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.PricePoints.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ProductSizes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Seasons.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ShippingTypes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class CollectionDropdownDto
	{
		public CollectionDropdownDto()
		{
			SeasonList = new();
			PricePointList = new();
			FactoryList = new();
			ShippingTypeList = new();
			MarketingTypeList = new();
			SizeList = new();
			DropList = new();
			StatusList = new();
        }

        [JsonPropertyName("season")]
        public GetAllSeasonList SeasonList { get; set; }

        [JsonPropertyName("pricePoint")]
        public GetAllPricePointList PricePointList { get; set; }

        [JsonPropertyName("factory")]
        public GetAllFactoryList FactoryList { get; set; }

        [JsonPropertyName("shippingType")]
        public GetAllShippingTypeList ShippingTypeList { get; set; }

        [JsonPropertyName("marketingType")]
        public GetAllMarketingTypeList MarketingTypeList { get; set; }

        [JsonPropertyName("size")]
        public GetAllSizeList SizeList { get; set; }

        [JsonPropertyName("drop")]
        public GetAllDropList DropList { get; set; }

        [JsonPropertyName("status")]
        public GetAllCollectionStatusList StatusList { get; set; }

        [JsonPropertyName("designStatus")]
        public GetAllCollectionDesignStatusList DesignStatusList { get; set; }
    }
}

