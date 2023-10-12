using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Publishing.Domain.Services;
using ACME.LearningPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningPlatform.API.Publishing.Application.Internal.CommandServices;

public class CategoryCommandService: ICategoryCommandService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Category> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command.Name);
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.CompleteAsync();
        return category;
    }
}