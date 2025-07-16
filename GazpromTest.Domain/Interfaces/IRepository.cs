namespace GazpromTest.Domain.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(int limit, int page, CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TKey> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(TKey id, CancellationToken cancellationToken);
}