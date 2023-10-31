using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Publishing.Domain.Services;

namespace ACME.LearningPlatform.API.Publishing.Application.Internal.QueryServices;

public class CategoryQueryService: ICategoryQueryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryQueryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await _categoryRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await _categoryRepository.ListAsync();
    }
}