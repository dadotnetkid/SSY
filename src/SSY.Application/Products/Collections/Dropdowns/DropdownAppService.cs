using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSY.Products.Collections.Drops;
using SSY.Products.Collections.Factories;
using SSY.Products.Collections.MarketingTypes;
using SSY.Products.Collections.PricePoints;
using SSY.Products.Collections.Seasons;
using SSY.Products.Collections.ShippingTypes;
using SSY.Products.Collections.Dropdowns.Dto;
using SSY.Products.Sizes;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using SSY.Products.Collections.Statuses;
using SSY.Products.Collections.DesignStatuses;

namespace SSY.Products.Collections.Dropdowns
{
    public class CollectionDropdownAppService : ApplicationService
    {
        private readonly ISeasonAppService _seasonAppService;
        private readonly IPricePointAppService _pricePointAppService;
        private readonly IFactoryAppService _factoryAppService;
        private readonly IMarketingTypeAppService _marketingTypeAppService;
        private readonly ISizeAppService _sizeAppService;
        private readonly IDropAppService _dropAppService;
        private readonly IShippingTypeAppService _shippingTypeAppService;
        private readonly IStatusAppService _statusAppService;
        private readonly IDesignStatusAppService _designStatusAppService;

        public CollectionDropdownAppService(
            ISeasonAppService seasonAppService,
            IPricePointAppService pricePointAppService,
            IFactoryAppService factoryAppService,
            IMarketingTypeAppService marketingTypeAppService,
            ISizeAppService sizeAppService,
            IDropAppService dropAppService,
            IShippingTypeAppService shippingTypeAppService,
            IStatusAppService statusAppService,
            IDesignStatusAppService designStatusAppService
            )
        {
            _seasonAppService = seasonAppService;
            _pricePointAppService = pricePointAppService;
            _factoryAppService = factoryAppService;
            _marketingTypeAppService = marketingTypeAppService;
            _sizeAppService = sizeAppService;
            _dropAppService = dropAppService;
            _shippingTypeAppService = shippingTypeAppService;
            _statusAppService = statusAppService;
            _designStatusAppService = designStatusAppService;
        }

        public async Task<DropdownDto> GetDropdowns()
        {
            try
            {
                var seasons = await _seasonAppService.GetListAsync(new() { MaxResultCount = 100 });
                var pricePoints = await _pricePointAppService.GetListAsync(new() { MaxResultCount = 100 });
                var factories = await _factoryAppService.GetListAsync(new() { MaxResultCount = 100 });
                var marketingTypes = await _marketingTypeAppService.GetListAsync(new() { MaxResultCount = 100 });
                var sizes = await _sizeAppService.GetListAsync(new() { MaxResultCount = 100 });
                var drops = await _dropAppService.GetListAsync(new() { MaxResultCount = 100 });
                var shippingTypes = await _shippingTypeAppService.GetListAsync(new() { MaxResultCount = 100 });
                var statuses = await _statusAppService.GetListAsync(new() { MaxResultCount = 100 });
                var designStatuses = await _designStatusAppService.GetListAsync(new() { MaxResultCount = 100 });

                DropdownDto dropdown = new()
                {
                    Season = seasons,
                    PricePoint = pricePoints,
                    Factory = factories,
                    MarketingType = marketingTypes,
                    Size = sizes,
                    Drop = drops,
                    ShippingType = shippingTypes,
                    Status = statuses,
                    DesignStatus = designStatuses
                };

                return dropdown;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }
    }
}

