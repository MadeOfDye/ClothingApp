namespace ClothingStore.Domain.Entities
{
    public class Tag
    {
        public Guid TagId { get; private set; }
        public Guid ItemId { get; private set; } // Foreign key for EF Core
        public virtual Item Item { get; private set; } // Navigation for EF Core

        public string Name { get; private set; }
        public int Ordinal { get; private set; }

        protected Tag() { }

        public Tag(string name, int ordinal)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tag name cannot be null or empty", nameof(name));
            if (ordinal < 0)
                throw new ArgumentOutOfRangeException(nameof(ordinal), "Ordinal must be a non-negative integer");
            TagId = Guid.NewGuid();
            Name = name;
            Ordinal = ordinal;
        }
    }
}
