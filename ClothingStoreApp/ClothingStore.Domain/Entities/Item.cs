namespace ClothingStore.Domain.Entities
{
    using ClothingStore.Domain.Interfaces;
    using System.Text.RegularExpressions;

    public class Item : IAggregateRoot
    {
        public Guid ItemId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        private readonly HashSet<Variant> _variants = new();
        public IReadOnlyCollection<Variant> Variants => _variants;
        public bool Hot { get; private set; }
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }
        private readonly HashSet<Tag> _tags = new();
        public IReadOnlyCollection<Tag> Tags => _tags;
        private readonly List<Review> _reviews = new();
        public IReadOnlyCollection<Review> Reviews => _reviews;
        public bool LastChance { get; private set; }
        public string Brand { get; private set; }
        public string Collection { get; private set; }
        public string? CareGuide { get; private set; }
        public string? MaterialDistribution { get; private set; }
        public DateTimeOffset CreatedAt { get; }

        protected Item() { }

        public Item(string name, string description, decimal price, string brand, string collection, string careGuide)
        {
            ItemId = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentException("Name is required");
            Description = description;
            if (collection != String.Empty && !string.IsNullOrWhiteSpace(collection))
                Collection = collection;
            else
                Collection = String.Empty;
            Hot = false;
            Price = (price >= 0) ? price : throw new ArgumentException("Price must be a positive integer value");
            Discount = 0;
            Brand = !string.IsNullOrWhiteSpace(brand) ? brand : throw new ArgumentException("Must specify the brand of clothing");
            MaterialDistribution =String.Empty;
            LastChance = false;
            if (string.IsNullOrWhiteSpace(careGuide))
                throw new ArgumentException("Care guide cannot be null or empty", nameof(careGuide));
            CareGuide = careGuide;
            DateTimeOffset now = DateTimeOffset.UtcNow;
        }


        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            Name = name;
        }

        public void UpdateDescription(string description)
        {
            Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ArgumentException("Description cannot be null or empty", nameof(description));
        }
        public void SetHot(bool isHot)
        {
            Hot = isHot;
        }

        public void SetLastChance(bool isLastChance)
        {
            LastChance = isLastChance;
        }

        public void DiscountItem(decimal discount)
        {
            if (discount < 0 || discount > 1)
                throw new ArgumentOutOfRangeException(nameof(discount), "Discount must be between 0 and 1");
            Discount = discount;
        }

        public void SetMaterialDistribution(string materialDistribution)
        {
            if (string.IsNullOrWhiteSpace(materialDistribution))
                throw new ArgumentException("Material distribution cannot be null or empty", nameof(materialDistribution));
            Regex materialRegex = new Regex(@"^[A-Za-z0-9\s]+:\s?(100|[1-9][0-9])%(,\s?[A-Za-z0-9\s]+:\s?(100|[1-9][0-9])%)*$");
            if (!materialRegex.IsMatch(materialDistribution))
            {
                throw new ArgumentException("Material distribution must be a comma-separated list of materials with percentages (e.g., 'Cotton 50%, Polyester 50%')", nameof(materialDistribution));
            }
            MaterialDistribution = materialDistribution;
        }

        public void AddVariant(Variant variant)
        {
            if (variant == null)
                throw new ArgumentNullException(nameof(variant), "Variant cannot be null");
            //if (variant.ItemId != ItemId)
            //    throw new InvalidOperationException("Variant must belong to this Item.");
            if (_variants.Any(v => v.VariantId == variant.VariantId))
                throw new InvalidOperationException("Variant already exists in the item");
            _variants.Add(variant);
        }

        public void AddTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag), "Tag cannot be null");
            if (_tags.Any(t => t == tag))
                throw new InvalidOperationException("Tag already exists in the item");
            _tags.Add(tag);
        }

        public void AddReview(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review), "Review Cannot Be NULL");
            //if(review.ItemId != ItemId)
            //    throw new InvalidOperationException("Review must belong to this Item.");
            if (_reviews.Any(r => r.Content.Equals(review.Content)))
                throw new InvalidOperationException("A Review already exists with the same content");
            _reviews.Add(review);
        }

        public void RemoveReview(Guid reviewId)
        {
            if (reviewId == Guid.Empty)
                throw new ArgumentException("Review ID cannot be empty", nameof(reviewId));
            var review = _reviews.FirstOrDefault(r => r.ReviewId == reviewId);
            if (review == null)
                throw new InvalidOperationException("Review not found");
            _reviews.Remove(review);
        }

        public void RemoveTag(Tag tag)
        {
            if (!_tags.Contains(tag))
                throw new InvalidOperationException("Tag not found in the item");
            _tags.Remove(tag);

        }

        public void RemoveVariant(Guid variantId)
        {
            var variant = _variants.FirstOrDefault(v => v.VariantId == variantId);
            if (variant == null)
                throw new InvalidOperationException("Variant not found");
            _variants.Remove(variant);
        }
    }
}
