using ClothingStore.Application.Common;
using ClothingStore.Application.DTOs;
using ClothingStore.Application.DTOs.Mappers;
using ClothingStore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Application.Aggregates.Item.Query
{
    public class ItemQueryHandler : IRequestHandler<GetAllItemsQuery, CollectionResponse<ItemDto>>,
                                                        IRequestHandler<GetItemByIdQuery, ItemDto>,
                                                        IRequestHandler<GetAllItemsSortedAndPaginatedQuery, CollectionResponse<ItemDto>>
    {
        private readonly IItemRepository _itemRepository;
        public ItemQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<CollectionResponse<ItemDto>> Handle(GetAllItemsSortedAndPaginatedQuery query, CancellationToken token = default)
        {
            var baseQuery = _itemRepository.Query();
            var count = await baseQuery.CountAsync(token);
            var items = await baseQuery
                .ApplySorting(query.FieldToSortBy, query.Ascending)
                .ApplyPaging(query.PageNumber, query.PageSize)
                .Select(ItemProjections.ItemToDto)
                .ToListAsync(token);
            return new CollectionResponse<ItemDto> { Records = items, TotalNumberOfRecords = count };
        }

        public async Task<CollectionResponse<ItemDto>> Handle(GetAllItemsQuery query, CancellationToken token = default)
        {
            var baseQuery = _itemRepository.Query().AsNoTracking();
            var count = await baseQuery.CountAsync(token);
            var items = await baseQuery
                .Select(ItemProjections.ItemToDto)
                .ToListAsync(token);

            return new CollectionResponse<ItemDto> { Records = items, TotalNumberOfRecords = count };
        }

        public async Task<ItemDto> Handle(GetItemByIdQuery query, CancellationToken token = default)
        {
            var dto = await _itemRepository.Query(x => x.ItemId == query.Id)
                .AsNoTracking()
                .Select(ItemProjections.ItemToDto)
                .FirstOrDefaultAsync(token);

            if (dto == null)
                throw new KeyNotFoundException($"Item with ID {query.Id} not found");

            return dto;
        }
    }
}
