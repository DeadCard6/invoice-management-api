using InvoiceManagementApi.Application.DTOs.Requests.Categories;
using InvoiceManagementApi.Application.DTOs.Requests.Clients;
using InvoiceManagementApi.Application.DTOs.Requests.Invoices;
using InvoiceManagementApi.Application.DTOs.Requests.Products;
using InvoiceManagementApi.Application.DTOs.Responses.Categories;
using InvoiceManagementApi.Application.DTOs.Responses.Clients;
using InvoiceManagementApi.Application.DTOs.Responses.Invoices;
using InvoiceManagementApi.Application.DTOs.Responses.Products;

namespace InvoiceManagementApi.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponse>> GetAllAsync(bool? isActive);
    Task<ClientResponse> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateClientRequest request);
    Task UpdateAsync(int id, CreateClientRequest request);
    Task DeleteAsync(int id);
    Task ReactivateAsync(int id);
}

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAllAsync();
    Task<int> CreateAsync(CreateCategoryRequest request);
    Task UpdateAsync(int id, CreateCategoryRequest request);
}

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllAsync(int? categoryId, bool? isActive, string? name);
    Task<ProductResponse> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateProductRequest request);
    Task UpdateAsync(int id, CreateProductRequest request);
    Task DeleteAsync(int id);
    Task ReactivateAsync(int id);
}

public interface IInvoiceService
{
    Task<int> CreateInvoiceAsync(CreateInvoiceRequest request);
    Task<IEnumerable<InvoiceResponse>> GetAllAsync(int? clientId, string? status, DateTime? startDate, DateTime? endDate);
    Task<InvoiceResponse> GetByIdAsync(int id);
    Task VoidAsync(int id);
    Task PayAsync(int id);
}

