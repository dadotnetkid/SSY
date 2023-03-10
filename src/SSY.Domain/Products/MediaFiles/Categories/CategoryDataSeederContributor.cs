using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.MediaFiles.Categories;

public class CategoryDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, int> _categoryRepository;

    public CategoryDataSeederContributor(IRepository<Category, int> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _categoryRepository.GetCountAsync() <= 0)
        {
            await _categoryRepository.InsertAsync(new Category(2001, "FirstDesignDraft", "FirstDesignDraft", 1), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2002, "ThreeDVirtualFitting", "ThreeDVirtualFitting", 2), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2003, "MockUpImages", "MockUpImages", 3), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2004, "FirstFitSampleImagesOEM", "FirstFitSampleImagesOEM", 4), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2005, "SecondFitSampleImagesOEM", "SecondFitSampleImagesOEM", 5), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2006, "PhotoshootSamplesOEM", "PhotoshootSamplesOEM", 6), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2007, "FirstFitSampleImagesInfluencer", "FirstFitSampleImagesInfluencer", 7), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2008, "SecondFitSampleImagesInfluencer", "SecondFitSampleImagesInfluencer", 8), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2009, "PhotoshootSamplesInfluencer", "PhotoshootSamplesInfluencer", 9), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(2010, "ProductionFiles", "ProductionFiles", 10), autoSave: true);
        }
    }
}