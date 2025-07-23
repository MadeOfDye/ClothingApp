using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Review
    {
        // placeholder implementation of review as it is not included in the current vertical slice.
        public Guid ReviewId { get; private set; }
        public Guid ItemId { get; private set; }
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

        //TODO: Implement the constructor and methods according to the domain requirements.

    }
}
