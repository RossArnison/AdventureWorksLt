using AdventureWorksLt.Shared.Dtos;
using AdventureWorksLt.Shared.Dtos.Product;

namespace AdventureWorksLt.Shared.Interfaces.Repositories;

public interface IProductRepository : IRepository<ProductTableDto, ProductDetailsDto>
{
}