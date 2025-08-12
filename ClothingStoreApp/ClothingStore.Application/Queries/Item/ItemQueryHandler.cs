using ClothingStore.Application.Common;
using ClothingStore.Application.DTOs;
using ClothingStore.Domain.Interfaces;
using MediatR;
using ClothingStore.Application.DTOs.Assemblers;
namespace ClothingStore.Application.Queries.Item
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

        public async Task<CollectionResponse<ItemDto>> Handle(GetAllItemsSortedAndPaginatedQuery query, CancellationToken token)
        {
            var count = await _itemRepository.Query().CountAsync(token);
            var items = await _itemRepository.Query()
                .ApplySorting(query.FieldToSortBy, query.Ascending)
                .ApplyPaging(query.PageNumber, query.PageSize)
                .Select(ItemProjections.ItemToDto)
                .ToListAsync(token);
            return new CollectionResponse<ItemDto> { Records = items, TotalNumberOfRecords = count };
        }

        public async Task<CollectionResponse<ItemDto>> Handle(GetAllItemsQuery query, CancellationToken token)
        {
            var count = await _itemRepository.ListAllAsync().CountAsync(token);
            var items = await _itemRepository.ListAllAsync(token);
            return new CollectionResponse<ItemDto> 
            { 
                Records = items.Select(item => item.ToDTO()).ToList(), 
                TotalNumberOfRecords = count 
            };
        }

        public async Task<ItemDto> Handle(GetItemByIdQuery query, CancellationToken token)
        {
            var item = await _itemRepository.GetByIdAsync(query.Id, token);
            if (item == null)
                throw new KeyNotFoundException($"Item with ID {query.Id} not found");
            return item.ToDTO();
        }
        public async Task<ItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
            => await _itemRepository.Query(x => x.Id == request.Id).Select(item => item.ToDTO()).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
