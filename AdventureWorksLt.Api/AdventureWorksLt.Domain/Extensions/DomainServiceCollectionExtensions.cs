using AdventureWorksLt.Domain.Services;
using AdventureWorksLt.Shared.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorksLt.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        return services.AddTransient<IProductCategoryService, ProductCategoryService>()
                       .AddTransient<IProductDescriptionService, ProductDescriptionService>()
                       .AddTransient<IProductModelService, ProductModelService>()
                       .AddTransient<IProductService, ProductService>();
    }
}