using AdventureWorksLt.Data.Contexts;
using AdventureWorksLt.Data.Contexts.Interfaces;
using AdventureWorksLt.Data.Repositories;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorksLt.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services.SetupDataContext(configuration.GetConnectionString("AdventureWorksLtConnection"))
                       .SetupRepositories();
    }

    private static IServiceCollection SetupDataContext(this IServiceCollection services, string? connectionString)
    {
        return services.AddDbContext<ISalesContext, SalesContext>(opt => 
            opt.UseSqlServer(connectionString));
    }

    private static IServiceCollection SetupRepositories(this IServiceCollection services)
    {
        return services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>()
                       .AddTransient<IProductDescriptionRepository, ProductDescriptionRepository>()
                       .AddTransient<IProductModelRepository, ProductModelRepository>()
                       .AddTransient<IProductRepository, ProductRepository>();
    }
}