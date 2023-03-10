/*using System;
using SSY.Inventory.PrintRepeats;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.ProductAssignments
{
    public class ProductAssignmentDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<ProductAssignment, int> _productAssignmentRepository;

        public ProductAssignmentDataSeederContributor(IRepository<ProductAssignment, int> productAssignmentRepository)
        {
            _productAssignmentRepository = productAssignmentRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _productAssignmentRepository.GetCountAsync() <= 0)
            {
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1001, "Leggings", "Leggings", 1));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1002, "Biker Shorts", "Biker Shorts", 2));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1003, "Shorts", "Shorts", 3));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1004, "Bra", "Bra", 4));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1005, "Fitted Tank", "Fitted Tank", 5));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1006, "Loose Tank", "Loose Tank", 6));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1007, "Tshirt", "Tshirt", 7));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1008, "Sweatshirt", "Sweatshirt", 8));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1009, "Jogger", "Jogger", 9));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1010, "Sweatshorts", "Sweatshorts", 10));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1011, "Windbreaker Jacket", "Windbreaker Jacket", 11));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1012, "Windbreaker Running Shorts", "", 12));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1013, "Jumpsuit", "Jumpsuit", 13));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1014, "Hoodie", "Hoodie", 14));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1015, "Sweatshirt", "Sweatshirt", 15));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1016, "Jogger", "Jogger", 16));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1017, "Sweatshorts", "Sweatshorts", 17));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1018, "Sweat Cardigan", "Sweat Cardigan", 18));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1019, "Jersey Loose Tank", "Jersey Loose Tank", 19));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1020, "Jersey Tshirt", "Jersey Tshirt", 20));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1021, "Jersey Jumpsuit", "Jersey Jumpsuit", 21));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1022, "Windbreaker Jacket", "Windbreaker Jacket", 22));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1023, "WindBreaker Running Shorts", "WindBreaker Running Shorts", 23));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1024, "Mesh Tshirt", "Mesh Tshirt", 24));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1025, "Lounge Pants", "Lounge Pants", 25));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1026, "Lounge Shirt", "Lounge Shirt", 26));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1027, "Lounge Tank", "Lounge Tank", 27));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1028, "Lounge Bra", "Lounge Bra", 28));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1029, "Lounge Dress", "Lounge Dress", 29));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1030, "Lounge Skirt", "Lounge Skirt", 30));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1031, "Lounge Shorts", "Lounge Shorts", 31));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1032, "Cardigan", "Cardigan", 32));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1033, "Sweater", "Sweater", 33));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1034, "Beanie", "Beanie", 34));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1035, "Scarf", "Scarf", 35));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1036, "Mesh Loose Tank", "Mesh Loose Tank", 36));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1037, "WindBreaker Pants", "WindBreaker Pants", 37));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1038, "Sweat Dress", "Sweat Dress", 38));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1039, "Sweat Skirt", "Sweat Skirt", 39));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1040, "Sweat Jacket", "Sweat Jacket", 40));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1041, "Sweat Coat", "Sweat Coat", 41));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1042, "Sports Bra", "Sports Bra", 42));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1043, "Fitted Tank", "Fitted Tank", 43));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1044, "Active Jumpsuit", "Active Jumpsuit", 44));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1045, "Active Dress", "Active Dress", 45));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1046, "Jersey Dress", "Jersey Dress", 46));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1047, "Lounge Cardigan", "Lounge Cardigan", 47));
                await _productAssignmentRepository.InsertAsync(new ProductAssignment(1048, "Lounge Sweater", "Lounge Sweater", 48));
            }
        }
    }
}*/