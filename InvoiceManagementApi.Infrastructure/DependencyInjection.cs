using InvoiceManagementApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<InvoiceManagementApi.Domain.Interfaces.IUnitOfWork, InvoiceManagementApi.Infrastructure.Persistence.Repositories.UnitOfWork>();
        services.AddScoped<InvoiceManagementApi.Domain.Interfaces.IUserRepository, InvoiceManagementApi.Infrastructure.Persistence.Repositories.UserRepository>();
        
        services.AddScoped<InvoiceManagementApi.Domain.Interfaces.IClientRepository, InvoiceManagementApi.Infrastructure.Persistence.Repositories.ClientRepository>();
        services.AddScoped<InvoiceManagementApi.Domain.Interfaces.IProductRepository, InvoiceManagementApi.Infrastructure.Persistence.Repositories.ProductRepository>();
        services.AddScoped<InvoiceManagementApi.Domain.Interfaces.IInvoiceRepository, InvoiceManagementApi.Infrastructure.Persistence.Repositories.InvoiceRepository>();
        services.AddScoped<InvoiceManagementApi.Domain.Interfaces.ICategoryRepository, InvoiceManagementApi.Infrastructure.Persistence.Repositories.CategoryRepository>();

        return services;
    }
}

