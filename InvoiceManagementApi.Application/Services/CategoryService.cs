using InvoiceManagementApi.Application.DTOs.Requests.Categories;
using InvoiceManagementApi.Application.DTOs.Responses.Categories;
using InvoiceManagementApi.Application.Interfaces;
using InvoiceManagementApi.Domain.Entities;
using InvoiceManagementApi.Domain.Exceptions;
using InvoiceManagementApi.Domain.Interfaces;

namespace InvoiceManagementApi.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            Name = request.Name,
            Description = request.Description
        };

        await _categoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
        return category.Id;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        });
    }

    public async Task UpdateAsync(int id, CreateCategoryRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) throw new NotFoundException(nameof(Category), id);

        category.Name = request.Name;
        category.Description = request.Description;

        _categoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync();
    }
}

