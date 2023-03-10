using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Administration.Influencers.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Dropdowns.Model;
using static SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model.CollectionModel;
using TypeModel = SSY.Blazor.HttpClients.Data.Inventory.Types.Model.TypeModel;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Overview
{
    public class OverviewModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }


        [JsonPropertyName("checkActivewear")]
        public string CheckActivewear { get; set; } = "Activewear";
        [JsonPropertyName("checkKnitwear")]
        public string CheckKnitwear { get; set; } = "Knitwear";
        [JsonPropertyName("checkSweats")]
        public string CheckSweats { get; set; } = "Sweats";
        [JsonPropertyName("checkJersey")]
        public string CheckJersey { get; set; } = "Jersey";
        [JsonPropertyName("checkMesh")]
        public string CheckMesh { get; set; } = "Mesh";
        [JsonPropertyName("checkWindbreaker")]
        public string CheckWindbreaker { get; set; } = "Windbreaker";
        ////////////////////////
        //for product overview//
        ////////////////////////
        [JsonPropertyName("sku")]
        public string SKU { get; set; }
        ////////////////////////
        //for product overview//
        ////////////////////////

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // Influencers
        [JsonPropertyName("influencers")]
        public List<string> Influencers { get; set; } = new();

        public void AddInfluencers(string input)
        {
            Influencers.Add(input);
        }

        [JsonPropertyName("influencersFullName")]
        public List<string> InfluencersFullName { get; set; } = new();

        public void AddInfluencersFullName(string input)
        {
            InfluencersFullName.Add(input);
        }

        [JsonPropertyName("influencersModel")]
        public List<InfluencerModel> InfluencersModel { get; set; } = new();

        public void AddInfluencersModel(InfluencerModel input)
        {
            InfluencersModel.Add(input);
        }

        public List<Guid> InfluencerIdsList { get; set; } = new();

        [JsonPropertyName("materialProductTypeList")]
        public List<CollectionModel.MaterialProductTypes> MaterialProductTypeList { get; set; } = new();

        [JsonPropertyName("materialTypeIdList")]
        public List<int> MaterialTypeIdList { get; set; } = new();

        [JsonPropertyName("influencersName")]
        public string InfluencersName { get; set; }

        [JsonPropertyName("colorOptionName")]
        public string ColorOptionName { get; set; }

        [JsonPropertyName("colorOptionValues")]
        public List<string> ColorOptionValues { get; set; } = new();
        public void AddColorOptionsName(string input)
        {
            ColorOptionValues.Add(input);
        }

        [JsonPropertyName("factory")]
        public string Factory { get; set; }

        [JsonPropertyName("pricePoint")]
        public string PricePoint { get; set; }

        [JsonPropertyName("dateAdded")]
        public DateTime DateAdded { get; set; }

        [JsonPropertyName("forecastQuantity")]
        public int ForecastQuantity { get; set; }

        //////////////////////////
        // size collection count//
        //////////////////////////
        [JsonPropertyName("activeWear")]
        public int ActiveWear { get; set; }

        [JsonPropertyName("sweats")]
        public int Sweats { get; set; }

        [JsonPropertyName("knitwear")]
        public int Knitwear { get; set; }
        //////////////////////////////
        // end size collection count//
        //////////////////////////////

        [JsonPropertyName("materialType")]
        public string MaterialType { get; set; }

        [JsonPropertyName("materialTypeName")]
        public List<string> MaterialTypeName { get; set; } = new();

        public void AddMaterialTypeName(string input)
        {
            MaterialTypeName.Add(input);
        }

        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonPropertyName("launchProgress")]
        public string LaunchProgress { get; set; }

        [JsonPropertyName("collectionStatus")]
        public string CollectionStatus { get; set; }

        [JsonPropertyName("shopifyAvailability")]
        public string ShopifyAvailability { get; set; }


        // Material Types
        [JsonPropertyName("types")]
        public List<TypeModel> Types { get; set; } = new();

        public void AddType(TypeModel type)
        {
            Types.Add(type);
        }

        // Color Types
        [JsonPropertyName("colorOptionIds")]
        public List<string> ColorOptionIds { get; set; } = new();
        public void AddColorOptionIds(string id)
        {
            ColorOptionIds.Add(id);
        }

        [JsonPropertyName("colorOptionIdList")]
        public List<int> ColorOptionIdList { get; set; } = new();
        public void AddColorOption(int id)
        {
            ColorOptionIdList.Add(id);
        }

        [JsonPropertyName("colorOptions")]
        public List<ColorModel> ColorOptions { get; set; } = new();

        public void AddColorOption(ColorModel colorOption)
        {
            ColorOptions.Add(colorOption);
        }

        [JsonPropertyName("fabricOptions")]
        public List<FabricModel> FabricOptions { get; set; } = new();

        public void AddFabricOption(FabricModel fabricOption)
        {
            FabricOptions.Add(fabricOption);
        }

        public List<int> FabricSelectionList { get; set; } = new();
        public void AddFabricSelection(int colorOption)
        {
            FabricSelectionList.Add(colorOption);
        }


        public class ColorModel
        {
            public Guid Id { get; set; }
            public int ColorId { get; set; }
            public string Value { get; set; }
            public string Title { get; set; }
            public int MaterialId { get; set; }

            public List<FabricModel> MaterialModelList { get; set; } = new();
            public List<string> Colors { get; set; } = new();

            public ColorListModel ColorListModel { get; set; } = new();
        }

        public class FabricModel
        {
            public int ColorId { get; set; }
            public string ColorTitle { get; set; }
            public string MaterialName { get; set; }
            public Guid MaterialId { get; set; }
            public int MaterialTypeId { get; set; }
        }


        public List<MaterialProductType> MaterialProductTypes { get; set; } = new();



    }

    public class MaterialProductType
    {
        public int MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }
        public string SelectedProductTypes { get; set; } = "Select Product Types";
        public List<Items> ProductTypes { get; set; } = new();
        public List<int> ProductTypeIds { get; set; } = new();
        public List<string> ProductTypeNames { get; set; } = new();
    }

}
