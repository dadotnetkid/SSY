using System;
using System.Threading.Tasks;
using SSY.Inventory.Adjustments.Types;
using Type = SSY.Inventory.Adjustments.Types.Type;

namespace SSY.Inventory.Adjustments
{
    public class AdjustmentManager : DomainService, IAdjustmentManager
    {
        private readonly IRepository<Type> _materialActionRepository;
        private readonly IRepository<Adjustment, Guid> _adjustmentRepository;
        private readonly IRepository<MaterialRoll, Guid> _materialRollRepository;
        private readonly IRepository<AdjustRollKey, Guid> _adjustRollRepository;

        public AdjustmentManager(
             IRepository<Type> materialActionRepository,
             IRepository<MaterialRoll, Guid> materialRollRepository,
             IRepository<AdjustRollKey, Guid> adjustRollRepository,
             IRepository<Adjustment, Guid> adjustmentRepository)
        {
            _materialActionRepository = materialActionRepository;
            _materialRollRepository = materialRollRepository;
            _adjustRollRepository = adjustRollRepository;
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task AdjustRollAsync(Adjustment adjustment, Roll roll)
        {
            try
            {
                var materialActions = await _materialActionRepository.GetListAsync();

                int increment = materialActions.Find(x => x.Label == "Increment").Id;
                int decrement = materialActions.Find(x => x.Label == "Decrement").Id;

                if (adjustment.From < adjustment.To)
                {
                    adjustment.ActionId = increment;
                }
                else if (adjustment.From > adjustment.To)
                {
                    adjustment.ActionId = decrement;
                }
                else
                {
                    throw new ArgumentException("There is no Adjustment on the roll count.");
                }

                await _adjustmentRepository.InsertAsync(adjustment);

                // Indexing
                await _materialRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, roll.MaterialId, roll.Id));

                await _adjustRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, adjustment.Id, roll.Id));
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public async Task DisposeRollAsync(Adjustment adjustment, Roll roll)
        {
            try
            {
                adjustment.From = roll.TotalCount.Value;

                adjustment.To = 0;

                await _adjustmentRepository.InsertAsync(adjustment);

                // Indexing
                await _materialRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, roll.MaterialId, roll.Id));

                await _adjustRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, adjustment.Id, roll.Id));
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public async Task AdjustSubMaterialAsync(Adjustment adjustment, Roll roll)
        {
            try
            {
                adjustment.From = roll.TotalCount.Value;

                var materialActions = await _materialActionRepository.GetListAsync();

                int increment = materialActions.Find(x => x.Label == "Increment").Id;
                int decrement = materialActions.Find(x => x.Label == "Decrement").Id;

                if (adjustment.From < adjustment.To)
                {
                    adjustment.ActionId = increment;
                }
                else if (adjustment.From > adjustment.To)
                {
                    adjustment.ActionId = decrement;
                }
                else
                {
                    throw new ArgumentException("There is no Adjustment on the roll count.");
                }

                await _adjustmentRepository.InsertAsync(adjustment);

                // Indexing
                await _materialRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, roll.MaterialId, roll.Id));

                await _adjustRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, adjustment.Id, roll.Id));
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public async Task DisposeSubMaterialAsync(Adjustment adjustment, Roll roll)
        {
            try
            {
                adjustment.From = roll.TotalCount.Value;

                adjustment.To = 0;

                await _adjustmentRepository.InsertAsync(adjustment);

                // Indexing
                await _materialRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, roll.MaterialId, roll.Id));

                await _adjustRollRepository.InsertAsync(new(roll.TenantId, roll.IsActive, adjustment.Id, roll.Id));
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

