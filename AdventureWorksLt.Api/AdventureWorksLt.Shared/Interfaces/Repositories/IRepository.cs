namespace AdventureWorksLt.Shared.Interfaces.Repositories;

public interface IRepository<TDto, TDetailDto>
{
    Task<TDto[]> GetAsync();
    Task<TDetailDto?> GetAsync(int id);
    Task<bool> CreateAsync(TDetailDto dto);
    Task<bool> UpdateAsync(int id, TDetailDto dto);
    Task<bool> DeleteAsync(int id);
}

public interface IRepository<TDto> : IRepository<TDto, TDto>
{
}