using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.CalendarConfigurations;

public class CalendarConfigurationDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<CalendarConfiguration, int> _repository;
    private readonly IRepository<Products.Statuses.Status, int> _productStatusRepository;

    public CalendarConfigurationDataSeederContributor(IRepository<CalendarConfiguration, int> repository, IRepository<Products.Statuses.Status, int> productStatusRepository)
    {
        _repository = repository;
        _productStatusRepository = productStatusRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _productStatusRepository.GetCountAsync() > 0 && await _repository.GetCountAsync() <= 0)
        {
            await _repository.InsertAsync(new CalendarConfiguration(1001, 1002, 7, 1, remarks: "Design Draft Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1002, 1006, 2, 2, remarks: "Design Draft Approved by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1003, 1007, 2, 3, remarks: "Collection Confirmed"));
            await _repository.InsertAsync(new CalendarConfiguration(1004, 1008, 2, 4, remarks: "Product Options Created"));
            await _repository.InsertAsync(new CalendarConfiguration(1005, 1009, 2, 5, remarks: "2D Technical Design Board Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1006, 2001, 1, 6, remarks: "3D Virtual Fitting Order Placed"));
            await _repository.InsertAsync(new CalendarConfiguration(1007, 2002, 7, 7, remarks: "3D Virtual Fitting Previews Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1008, 2004, 1, 8, remarks: "3D Virtual Fitting Previews Approved"));
            await _repository.InsertAsync(new CalendarConfiguration(1009, 4014, 3, 9, remarks: "All Final 3D Virtual Fittings Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1010, 2007, 1, 10, remarks: "Final 3D Virtual Fittings Approved by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1011, 2008, 3, 11, remarks: "3D Technical Design Board Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1012, 3001, 1, 12, remarks: "Mockup Ordered"));
            await _repository.InsertAsync(new CalendarConfiguration(1013, 3002, 5, 13, remarks: "Mockup Image/s Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1014, 3003, 1, 14, remarks: "Mockup Image/s Rejected by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1015, 3004, 1, 15, remarks: "Mockup Image/s Approved by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1016, 4001, 1, 16, remarks: "1st Fit Sample Ordered"));
            await _repository.InsertAsync(new CalendarConfiguration(1017, 4002, 3, 17, remarks: "ODM 1st Pattern Review"));
            await _repository.InsertAsync(new CalendarConfiguration(1018, 4003, 10, 18, remarks: "ODM 1st Fit Sample Production"));
            await _repository.InsertAsync(new CalendarConfiguration(1019, 4004, 1, 19, remarks: "1st Fit Sample Image/s Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1020, 4006, 1, 20, remarks: "1st Fit Sample Approved by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1021, 4007, 1, 21, remarks: "1st Fit Sample Shipped"));
            await _repository.InsertAsync(new CalendarConfiguration(1022, 4008, 5, 22, remarks: "1st Fit Sample Delivered"));
            await _repository.InsertAsync(new CalendarConfiguration(1023, 4009, 1, 23, remarks: "1st Fit Sample Approved by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1024, 4010, 5, 24, remarks: "2nd 3D Technical Design Board Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1025, 4011, 2, 25, remarks: "2nd 3D Virtual Fitting Preview Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1026, 4012, 2, 26, remarks: "2nd 3D Virtual Fitting Boards Rejected by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1027, 4013, 2, 27, remarks: "2nd 3D Virtual Fitting Boards Approved by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1028, 4014, 2, 28, remarks: "2nd All Final 3D Virtual Fittings Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1029, 4015, 2, 29, remarks: "2nd 3D Virtual Fitting Boards Rejected by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1030, 4016, 2, 30, remarks: "2nd 3D Virtual Fitting Boards Approved by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1031, 4017, 2, 31, remarks: "2nd Final 3D Technical Design Board Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1032, 4018, 2, 32, remarks: "2nd Fit Sample Ordered"));
            await _repository.InsertAsync(new CalendarConfiguration(1033, 4019, 2, 33, remarks: "ODM 2nd Pattern Review"));
            await _repository.InsertAsync(new CalendarConfiguration(1034, 4020, 2, 34, remarks: "ODM 2nd Fit Sample Production"));
            await _repository.InsertAsync(new CalendarConfiguration(1035, 4021, 2, 35, remarks: "2nd Fit Sample Image/s Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1036, 4022, 2, 36, remarks: "2nd Fit Sample Rejected by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1037, 4023, 2, 37, remarks: "2nd Fit Sample Approved by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1038, 4024, 2, 38, remarks: "2nd Fit Sample Shipped"));
            await _repository.InsertAsync(new CalendarConfiguration(1039, 4025, 2, 39, remarks: "2nd Fit Sample Delivered"));
            await _repository.InsertAsync(new CalendarConfiguration(1040, 4026, 2, 40, remarks: "2nd Fit Sample Approved by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1041, 4027, 2, 41, remarks: "2nd Fit Sample Rejected by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1042, 5001, 2, 42, remarks: "Photoshoot Sample Ordered"));
            await _repository.InsertAsync(new CalendarConfiguration(1043, 5002, 2, 43, remarks: "Photoshoot Sample Production"));
            await _repository.InsertAsync(new CalendarConfiguration(1044, 5003, 2, 44, remarks: "Photoshoot Sample Image/s Uploaded"));
            await _repository.InsertAsync(new CalendarConfiguration(1045, 5004, 2, 45, remarks: "Photoshoot Sample Rejected by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1046, 5005, 2, 46, remarks: "Photoshoot Sample Approved by Design Head"));
            await _repository.InsertAsync(new CalendarConfiguration(1047, 5006, 2, 47, remarks: "Photoshoot Sample Shipped"));
            await _repository.InsertAsync(new CalendarConfiguration(1048, 5007, 2, 48, remarks: "Photoshoot Sample Delivered"));
            await _repository.InsertAsync(new CalendarConfiguration(1049, 5008, 2, 49, remarks: "Photoshoot Sample Approved by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1050, 5009, 2, 50, remarks: "Photoshoot Sample Rejected by Influencer"));
            await _repository.InsertAsync(new CalendarConfiguration(1051, 6001, 2, 51, remarks: "Ready for Launch"));
            await _repository.InsertAsync(new CalendarConfiguration(1052, 6002, 2, 52, remarks: "Tentative Ready for Launch"));
            await _repository.InsertAsync(new CalendarConfiguration(1053, 7001, 2, 53, remarks: "Marketing Sample Ordered"));
            await _repository.InsertAsync(new CalendarConfiguration(1054, 7002, 2, 54, remarks: "Marketing Sample Shipped"));
            await _repository.InsertAsync(new CalendarConfiguration(1055, 7003, 2, 55, remarks: "Launch Date"));
            await _repository.InsertAsync(new CalendarConfiguration(1056, 7004, 2, 56, remarks: "Tentative Launch Date"));
            await _repository.InsertAsync(new CalendarConfiguration(1057, 8001, 2, 57, remarks: "Launch Finished"));
            await _repository.InsertAsync(new CalendarConfiguration(1058, 9001, 2, 58, remarks: "Ready for Redrop Launch"));
            await _repository.InsertAsync(new CalendarConfiguration(1059, 9002, 2, 59, remarks: "Tentative Ready for Redrop Launch"));
            await _repository.InsertAsync(new CalendarConfiguration(1060, 10001, 2, 60, remarks: "Redrop Launch Date"));
            await _repository.InsertAsync(new CalendarConfiguration(1061, 10002, 2, 61, remarks: "Redrop Tentative Launch Date"));



        }
    }
}