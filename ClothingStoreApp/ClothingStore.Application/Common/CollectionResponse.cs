namespace ClothingStore.Application.Common
{
    public class CollectionResponse<T>
    {
        public required IReadOnlyList<T> Records { get; set; }
        public required int TotalNumberOfRecords { get; set; }
    }
}
