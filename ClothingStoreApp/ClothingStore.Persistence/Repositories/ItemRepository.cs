using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Interfaces;
using ClothingStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Persistence.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> UpdateSafeAsync(Item entity, CancellationToken ct = default)
        {
            var exists = await _context.Items.AnyAsync(x => x.ItemId == entity.ItemId, ct);
            if (!exists) return false;

            _context.Items.Update(entity);
            return true;
        }


        public async Task<IReadOnlyList<Item>> GetHotItemsAsync(int count, CancellationToken ct)
        {
            return await _context.Items
                 .Where(item => item.Hot)
                 .OrderByDescending(i => i.CreatedAt)
                 .Take(count)
                 .ToListAsync(ct);
        }

        //public async Task<IReadOnlyList<Item>> GetLastChanceItemsAsync(int count, CancellationToken ct)
        //{
        //    return await _context.Items
        //        .Where(item => item.LastChance)
        //        .OrderByDescending(i => i.CreatedAt)
        //        .Take(count)
        //        .ToListAsync(ct);
        //}

        //public async Task<IReadOnlyList<Item>> GetItemsByBrandAsync(string brand, CancellationToken ct)
        //{
        //    return await _context.Items
        //        .Where(item => item.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
        //        .ToListAsync(ct);
        //} 

        //public async Task<IReadOnlyList<Item>> GetItemsByCollectionAsync(string collection, CancellationToken ct)
        //{
        //    return await _context.Items
        //        .Where(item => item.Collection.Equals(collection, StringComparison.OrdinalIgnoreCase))
        //        .ToListAsync(ct);
        //}

        //public async Task<IReadOnlyList<Item>> GetItemsByTagAsync(string tag, CancellationToken ct)
        //{
        //    return await _context.Items
        //        .Where(item => item.Tags.Any(t => t.Name.Equals(tag, StringComparison.OrdinalIgnoreCase)))
        //        .ToListAsync(ct);
        //}

        //public async Task<IReadOnlyList<Item>> GetItemsByTagsAsync(IEnumerable<string> tags, CancellationToken ct)
        //{
        //    return await _context.Items
        //        .Where(item => item.Tags.Any(t => tags.Contains(t.Name, StringComparer.OrdinalIgnoreCase)))
        //        .ToListAsync(ct);
        //}

        //public async Task<Item?> GetItemByName(string name)
        //{
        //     return await _context.Items
        //        .FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));   
        //}

        public async Task<Item?> GetItemByIdWithIncludesAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Items
                .Include(i => i.Variants)
                    .ThenInclude(v => v.AvailableLocations)
                        .ThenInclude(al => al.AvailableLocationsOfGivenSize)
                            .ThenInclude(s => s.Location)
                .Include(i => i.Variants)
                    .ThenInclude(v => v.Gallery)
                .Include(i => i.Tags)
                .FirstOrDefaultAsync(i => i.ItemId == id, ct);
        }
    }
}
