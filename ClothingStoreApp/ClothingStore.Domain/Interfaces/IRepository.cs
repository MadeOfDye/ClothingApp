using System.Linq.Expressions;

namespace ClothingStore.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        Task<T?> GetByIdAsync(Guid Id, CancellationToken ct = default);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken ct = default);
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken ct = default);
        IQueryable<T> Query();
        Task<T?> AddAsync(T entity, CancellationToken ct = default);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
