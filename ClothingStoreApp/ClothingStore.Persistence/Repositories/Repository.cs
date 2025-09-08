using ClothingStore.Domain.Interfaces;
using ClothingStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClothingStore.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T?> AddAsync(T entity, CancellationToken ct = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity) + " Should not be null.");
            await _context.Set<T>().AddAsync(entity, ct);

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken token = default)
        {
            if (entities == null || !entities.Any() || entities.Any(e => e == null))
                throw new ArgumentNullException(nameof(entities) + " Should not be null or empty, or contain null elements.");
            await _context.Set<T>().AddRangeAsync(entities, token);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity) + " Should not be null.");
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities) + " Should not be null or empty.");
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<T?> GetByIdAsync(Guid Id, CancellationToken ct = default)
        {
            return await _context.Set<T>().FindAsync(Id, ct);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken ct = default)
        {
            return await _context.Set<T>().ToListAsync(ct);
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken ct = default)
        {
            return await _context.Set<T>().Where(filter).ToListAsync(ct);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ? _context.Set<T>().AsQueryable().AsNoTracking() : _context.Set<T>().Where(filter).AsQueryable().AsNoTracking();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return _context.SaveChangesAsync(ct);
        }
    }
}
