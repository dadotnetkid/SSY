using System;
using System.Collections.Generic;
using SSY.Products.Collections.DesignStatuses.Dtos;
using SSY.Products.Collections.Drops.Dtos;
using SSY.Products.Collections.Factories.Dtos;
using SSY.Products.Collections.MarketingTypes.Dtos;
using SSY.Products.Collections.PricePoints.Dtos;
using SSY.Products.Collections.Seasons.Dtos;
using SSY.Products.Collections.ShippingTypes.Dtos;
using SSY.Products.Collections.Statuses.Dtos;
using SSY.Products.Sizes.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Dropdowns.Dto
{
	public class DropdownDto
	{
		public DropdownDto()
		{
		}

		public PagedResultDto<SeasonDto> Season { get; set; }
        public PagedResultDto<PricePointDto> PricePoint { get; set; }
        public PagedResultDto<FactoryDto> Factory { get; set; }
        public PagedResultDto<ShippingTypeDto> ShippingType { get; set; }
        public PagedResultDto<MarketingTypeDto> MarketingType { get; set; }
        public PagedResultDto<SizeDto> Size { get; set; }
        public PagedResultDto<DropDto> Drop { get; set; }
        public PagedResultDto<StatusDto> Status { get; set; }
        public PagedResultDto<DesignStatusDto> DesignStatus { get; set; }
    }
}

