using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Entities
{
   public class Variant
    {
        public Guid VariantId { get; private set; }
        public Guid ItemId { get; private set; }
        public Item Item { get; private set; }
        public Color Color { get; private set; }
        private readonly List<AvailableLocationBySize> _availableLocations = new();
        public IReadOnlyCollection<AvailableLocationBySize> AvailableLocations => _availableLocations;
        private readonly List<Photo> _gallery = new();
        public IReadOnlyCollection<Photo> Gallery => _gallery;
        public int totalQuantity => _availableLocations.Sum(a => a.TotalStockOfSize);

        protected Variant() { }

        public Variant(Guid itemId, Color color)
        {
            VariantId = Guid.NewGuid();
            ItemId = itemId;
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public void AddPhoto(Photo photo)
        {
            if(photo == null)
                throw new ArgumentNullException(nameof(photo), "Photo cannot be null");
            _gallery.Add(photo);
        }

        public void AddLocation(AvailableLocationBySize location)
        {
            if (_availableLocations.Any(l => l.LocationId == location.LocationId && l.Size == location.Size))
                throw new InvalidOperationException("Location/Size combo exists");
            _availableLocations.Add(location);
        }
    }
}
