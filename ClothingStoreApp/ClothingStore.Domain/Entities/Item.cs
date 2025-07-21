using ClothingStore.Domain.Enumerators;

namespace ClothingStore.Domain.Entities
{
    public class Item
    {
        public Guid ItemId {  get; private set; }
        public string Name { get; private set; }
        private readonly HashSet<Variant> _variants = new();
        public IReadOnlyCollection<Variant> Variants => _variants;
        public bool Hot {  get; private set; }
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }
        private readonly HashSet<Tag> _tags = new();
        public IReadOnlyCollection<Tag> Tags => _tags;
        private readonly List<Review> _reviews = new();
        public IReadOnlyCollection<Review> Reviews => _reviews;
        public bool LastChance { get; private set; }
        public string? Brand {  get; private set; }
        public string? Collection { get; private set; }
        public string? CareGuide { get; private set; }
        public string? MaterialDistribution { get; private set; }
        public int TotalStock => _variants.Sum(v => v.totalQuantity);

        protected Item() {}

        public Item(string name, decimal price, string brand)
        {
            ItemId = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentException("Name is required");
            Price = price;
            Brand = brand;
        }

        public void AddVariant(Variant variant)
        {
            if (_variants.Any(v => v.Color.Equals(variant.Color)))
                throw new InvalidOperationException("Variant already exists");
            _variants.Add(variant);
        }
    }
}
