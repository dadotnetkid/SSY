using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.DesignStatuses;

public class DesignStatusDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<DesignStatus, int> _designStatusRepository;

    public DesignStatusDataSeederContributor(IRepository<DesignStatus, int> designStatusRepository)
    {
        _designStatusRepository = designStatusRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _designStatusRepository.GetCountAsync() <= 0)
        {
            await _designStatusRepository.InsertAsync(new DesignStatus(1001, "Collection Development", "Collection Development", 1), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(1002, "Design Concept Uploaded", "Design Concept Uploaded", 2), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(1003, "Design Concept Approved", "Design Concept Approved", 3), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(1004, "Design Concept Rejected", "Design Concept Rejected", 4), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(2001, "Design Draft", "Design Draft", 5), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(3001, "3D Virtual Fitting", "3D Virtual Fitting", 6), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(4001, "Mock Up", "Mock Up", 7), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(5001, "Fit Sample", "Fit Sample", 8), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(6001, "Photoshoot Sample", "Photoshoot Sample", 8), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(7001, "Launch Ready", "Launch Ready", 10), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(8001, "Launch Date", "Launch Date", 11), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(9001, "Redrop Preparation", "Redrop Preparation", 12), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(10001, "Redrop Launch Ready", "Redrop Launch Ready", 13), autoSave: true);
            await _designStatusRepository.InsertAsync(new DesignStatus(11001, "Redrop Launch Date", "Redrop Launch Date", 14), autoSave: true);
        }
    }
}