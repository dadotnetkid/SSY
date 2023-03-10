using System;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
	public class GetAllCollectionOutputModel : GetAllOutputModelBase<CollectionOutputModel>
    {
	}

    public class GetAllCollectionList : Results<CollectionDto>
    {
    }
}

