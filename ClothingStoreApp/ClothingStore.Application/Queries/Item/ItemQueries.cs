using ClothingStore.Application.Common;
using ClothingStore.Application.DTOs;
using MediatR;

namespace ClothingStore.Application.Queries.Item
{
    public class GetAllItemsQuery: IRequest<CollectionResponse<ItemDto>>
    {

    }

    public class GetAllItemsSortedAndPaginatedQuery : IRequest<CollectionResponse<ItemDto>>
    {
        public string FieldToSortBy { get; set;}
        public bool Ascending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class  GetItemByIdQuery: IRequest<ItemDto>
    {
        public required Guid Id { get; set; }
    }
}
