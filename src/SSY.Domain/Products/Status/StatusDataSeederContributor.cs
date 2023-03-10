using System;
using System.Threading.Tasks;
using SSY.Products.Collections.DesignStatuses;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Statuses;

public class StatusDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Status, int> _statusRepository;
    private readonly IRepository<DesignStatus, int> _designStatusRepository;

    public StatusDataSeederContributor(IRepository<Status, int> statusRepository, IRepository<DesignStatus, int> designStatusRepository)
    {
        _statusRepository = statusRepository;
        _designStatusRepository = designStatusRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _designStatusRepository.GetCountAsync() > 0 && await _statusRepository.GetCountAsync() <= 0)
        {
            //Design Draft
            await _statusRepository.InsertAsync(new Status(1001, 2001, true, "Product Onboarded", "Product Onboarded", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1002, 2001, true, "Design Draft Uploaded", "Design Draft Uploaded", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1003, 2001, true, "Design Draft Rejected by Design Head", "Design Draft Rejected by Design Head", 3), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1004, 2001, true, "Design Draft Approved by Design Head", "Design Draft Approved by Design Head", 4), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1005, 2001, true, "Design Draft Rejected by Influencer", "Design Draft Rejected by Influencer", 5), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1006, 2001, true, "Design Draft Approved by Influencer", "Design Draft Approved by Influencer", 6), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1007, 2001, true, "Collection Confirmed", "Collection Confirmed", 7), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1008, 2001, true, "Product Options Created", "Product Options Created", 8), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1009, 2001, true, "2D Technical Design Board Uploaded", "2D Technical Design Board Uploaded", 9), autoSave: true);

            //3D Virtual Fitting
            await _statusRepository.InsertAsync(new Status(2001, 3001, true, "3D Virtual Fitting Order Placed", "3D Virtual Fitting Order Placed", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2002, 3001, true, "Parent 3D Virtual Fitting Previews Uploaded", "Parent 3D Virtual Fitting Previews Uploaded", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2003, 3001, true, "Parent 3D Virtual Fitting Previews Rejected", "Parent 3D Virtual Fitting Previews Rejected", 3), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2004, 3001, true, "Parent 3D Virtual Fitting Previews Approved", "Parent 3D Virtual Fitting Previews Approved", 4), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2005, 3001, true, "Child Final 3D Virtual Fittings Uploaded", "Child Final 3D Virtual Fittings Uploaded", 5), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2006, 3001, true, "Child Final 3D Virtual Fittings Rejected by Influencer", "Child Final 3D Virtual Fittings Rejected by Influencer", 6), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2007, 3001, true, "Child Final 3D Virtual Fittings Approved by Influencer", "Child Final 3D Virtual Fittings Approved by Influencer", 7), autoSave: true);
            await _statusRepository.InsertAsync(new Status(2008, 3001, true, "3D Technical Design Board Uploaded", "3D Technical Design Board Uploaded", 8), autoSave: true);

            //Mock up
            await _statusRepository.InsertAsync(new Status(3001, 4001, true, "Mockup Ordered", "Mockup Ordered", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(3002, 4001, true, "Mockup Image/s Uploaded", "Mockup Image/s Uploaded", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(3003, 4001, true, "Mockup Image/s Rejected by Design Head", "Mockup Image/s Rejected by Design Head", 3), autoSave: true);
            await _statusRepository.InsertAsync(new Status(3004, 4001, true, "Mockup Image/s Approved by Design Head", "Mockup Image/s Approved by Design Head", 4), autoSave: true);

            //Fit Sample
            await _statusRepository.InsertAsync(new Status(4001, 5001, true, "1st Fit Sample Ordered", "1st Fit Sample Ordered", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4002, 5001, true, "ODM 1st Pattern Review", "ODM 1st Pattern Review", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4003, 5001, true, "ODM 1st Fit Sample Production", "ODM 1st Fit Sample Production", 3), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4004, 5001, true, "1st Fit Sample Image/s Uploaded", "1st Fit Sample Image/s Uploaded", 4), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4005, 5001, true, "1st Fit Sample Rejected by Design Head", "1st Fit Sample Rejected by Design Head", 5), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4006, 5001, true, "1st Fit Sample Approved by Design Head", "1st Fit Sample Approved by Design Head", 6), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4007, 5001, true, "1st Fit Sample Shipped", "1st Fit Sample Shipped", 7), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4008, 5001, true, "1st Fit Sample Delivered", "1st Fit Sample Delivered", 8), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4009, 5001, true, "1st Fit Sample Approved by Influencer", "1st Fit Sample Approved by Influencer", 9), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4010, 5001, true, "2nd 3D Technical Design Board Uploaded", "2nd 3D Technical Design Board Uploaded", 10), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4011, 5001, true, "2nd 3D Virtual Fitting Preview Uploaded", "2nd 3D Virtual Fitting Preview Uploaded", 11), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4012, 5001, true, "2nd 3D Virtual Fitting Boards Rejected by Design Head", "2nd 3D Virtual Fitting Boards Rejected by Design Head", 12), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4013, 5001, true, "2nd 3D Virtual Fitting Boards Approved by Design Head", "2nd 3D Virtual Fitting Boards Approved by Design Head", 13), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4014, 5001, true, "2nd All Final 3D Virtual Fittings Uploaded", "2nd All Final 3D Virtual Fittings Uploaded", 16), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4015, 5001, true, "2nd 3D Virtual Fitting Boards Rejected by Influencer", "2nd 3D Virtual Fitting Boards Rejected by Influencer", 14), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4016, 5001, true, "2nd 3D Virtual Fitting Boards Approved by Influencer", "2nd 3D Virtual Fitting Boards Approved by Influencer", 15), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4017, 5001, true, "2nd Final 3D Technical Design Board Uploaded", "2nd Final 3D Technical Design Board Uploaded", 16), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4018, 5001, true, "2nd Fit Sample Ordered", "2nd Fit Sample Ordered", 16), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4019, 5001, true, "ODM 2nd Pattern Review", "ODM 2nd Pattern Review", 17), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4020, 5001, true, "ODM 2nd Fit Sample Production", "ODM 2nd Fit Sample Production", 18), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4021, 5001, true, "2nd Fit Sample Image/s Uploaded", "2nd Fit Sample Image/s Uploaded", 19), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4022, 5001, true, "2nd Fit Sample Rejected by Design Head", "2nd Fit Sample Rejected by Design Head", 20), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4023, 5001, true, "2nd Fit Sample Approved by Design Head", "2nd Fit Sample Approved by Design Head", 21), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4024, 5001, true, "2nd Fit Sample Shipped", "2nd Fit Sample Shipped", 22), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4025, 5001, true, "2nd Fit Sample Delivered", "2nd Fit Sample Delivered", 23), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4026, 5001, true, "2nd Fit Sample Approved by Influencer", "2nd Fit Sample Approved by Influencer", 24), autoSave: true);
            await _statusRepository.InsertAsync(new Status(4027, 5001, true, "2nd Fit Sample Rejected by Influencer", "2nd Fit Sample Rejected by Influencer", 25), autoSave: true);

            //Photoshoot Sample
            await _statusRepository.InsertAsync(new Status(5001, 6001, true, "Photoshoot Sample Ordered", "Photoshoot Sample Ordered", 26), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5002, 6001, true, "Photoshoot Sample Production", "Photoshoot Sample Production", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5003, 6001, true, "Photoshoot Sample Image/s Uploaded", "Photoshoot Sample Image/s Uploaded", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5004, 6001, true, "Photoshoot Sample Rejected by Design Head", "Photoshoot Sample Rejected by Design Head", 3), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5005, 6001, true, "Photoshoot Sample Approved by Design Head", "Photoshoot Sample Approved by Design Head", 4), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5006, 6001, true, "Photoshoot Sample Shipped", "Photoshoot Sample Shipped", 5), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5007, 6001, true, "Photoshoot Sample Delivered", "Photoshoot Sample Delivered", 6), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5008, 6001, true, "Photoshoot Sample Approved by Influencer", "Photoshoot Sample Approved by Influencer", 7), autoSave: true);
            await _statusRepository.InsertAsync(new Status(5009, 6001, true, "Photoshoot Sample Rejected by Influencer", "Photoshoot Sample Rejected by Influencer", 8), autoSave: true);

            //Launch Ready
            await _statusRepository.InsertAsync(new Status(6001, 7001, true, "Ready for Launch", "Ready for Launch", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(6002, 7001, true, "Tentative Ready for Launch", "Tentative Ready for Launch", 2), autoSave: true);

            //Launch Date
            await _statusRepository.InsertAsync(new Status(7001, 8001, true, "Marketing Sample Ordered", "Marketing Sample Ordered", 3), autoSave: true);
            await _statusRepository.InsertAsync(new Status(7002, 8001, true, "Marketing Sample Shipped", "Marketing Sample Shipped", 4), autoSave: true);
            await _statusRepository.InsertAsync(new Status(7003, 8001, true, "Launch Date", "Launch Date", 5), autoSave: true);
            await _statusRepository.InsertAsync(new Status(7004, 8001, true, "Tentative Launch Date", "Tentative Launch Date", 6), autoSave: true);

            //Redrop Preparation
            await _statusRepository.InsertAsync(new Status(8001, 9001, true, "Launch Finished", "Launch Finished", 1), autoSave: true);

            //Redrop Launch Ready
            await _statusRepository.InsertAsync(new Status(9001, 10001, true, "Ready for Redrop Launch", "Ready for Redrop Launch", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(9002, 10001, true, "Tentative Ready for Redrop Launch", "Tentative Ready for Redrop Launch", 2), autoSave: true);

            //Redrop Launch Date
            await _statusRepository.InsertAsync(new Status(10001, 11001, true, "Redrop Launch Date", "Redrop Launch Date", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(10002, 11001, true, "Redrop Tentative Launch Date", "Redrop Tentative Launch Date", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(10003, 11001, true, "Redrop Launch Finished", "Redrop Launch Finished", 3), autoSave: true);
        }
    }
}