using InvoiceManagementApi.Application.Interfaces;
using InvoiceManagementApi.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IInvoiceService, InvoiceService>();

        return services;
    }
}

