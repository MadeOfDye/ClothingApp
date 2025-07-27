namespace ClothingStore.Domain.Entities
{
    public class Review
    {
        // placeholder implementation of review as it is not included in the current vertical slice.
        public Guid ReviewId { get; private set; }
        public Guid ItemId { get; private set; }

        public Item Item { get; private set; }// Navigation property for EFCore
        public string Content { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public int Likes { get; private set; }
        public int Dislikes { get; private set; }
        private List<Review> _comments = new();
        public IReadOnlyCollection<Review> Reviews => _comments;
        public bool IsFlagged { get; private set; }
        //TODO: Another parameter will be a list of Reports with Report being an entity that is outside the scope of the current vertical slice.
        public int TimesEdited { get; private set; }
        public DateTimeOffset LastEdited { get; private set; }

        protected Review() { }

        public Review(string content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content), "Content cannot be null or empty");
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be null or empty", nameof(content));
            ReviewId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Likes = 0;
            Dislikes = 0;
            IsFlagged = false;
            TimesEdited = 0;
            LastEdited = DateTime.UtcNow;
        }
        //TODO: Implement the constructor and methods according to the domain requirements.

    }
}
