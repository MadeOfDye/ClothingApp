using ClothingStore.Domain.Entities;

namespace ClothingStore.Domain.Interfaces
{
    public interface IItemRepository: IRepository<Item>
    {
        // Placeholder for additional methods specific to Item repository
        Task<IReadOnlyList<Item>> GetHotItemsAsync(int count, CancellationToken ct);
        Task<Item?> GetItemByIdWithIncludesAsync(Guid id, CancellationToken ct = default);
    }
}
