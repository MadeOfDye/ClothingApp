namespace ClothingStore.Domain.Entities
{
    using ClothingStore.Domain.ValueObjects;

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
        public int TotalQuantity => _availableLocations.Sum(a => a.TotalStockOfSize);

        protected Variant() { }

        public Variant(Color color)
        {
            VariantId = Guid.NewGuid();
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public void UpdateColor(Color color)
        {
            if (color == null)
                throw new ArgumentNullException(nameof(color), "Color cannot be null");
            Color = color;
        }

        public void AddPhoto(Photo photo)
        {
            //if(photo.VariantId != VariantId)
            //    throw new InvalidOperationException("Photo must belong to this Variant.");
            _gallery.Add(photo);
        }

        public void AddLocation(AvailableLocationBySize location)
        {
            if (_availableLocations.Any(l => l.AvailableLocationBySizeId == location.AvailableLocationBySizeId && l.Size == location.Size))
                throw new InvalidOperationException("Location/Size combo exists");
            //if(location.VariantId != VariantId)
            //    throw new InvalidOperationException("Location must belong to this Variant.");
            _availableLocations.Add(location);
        }

        public void RemoveLocation(Guid locationId)
        {
            if (locationId == Guid.Empty)
                throw new ArgumentNullException(nameof(locationId), "Location cannot be null");
            AvailableLocationBySize location = _availableLocations.FirstOrDefault(l => l.AvailableLocationBySizeId == locationId) ?? throw new InvalidOperationException("Location not found");
            _availableLocations.Remove(location);
        }

        public void RemovePhoto(Guid photoId)
        {
            if (photoId == Guid.Empty)
                throw new ArgumentNullException(nameof(photoId), "Photo cannot be null");
           Photo photo = _gallery.FirstOrDefault(p => p.PhotoId == photoId) ?? throw new InvalidOperationException("Photo not found");
            if (photo == null)
                throw new InvalidOperationException("Photo not found");
            _gallery.Remove(photo);
        }
    }
}
