using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Photo
    {
        public Guid PhotoId { get; private set; }
        public Guid VariantId { get; private set; } 
        public string Url { get; private set; }
        public DateTimeOffset UploadedAt { get; private set; }

        public Variant Variant { get; private set; }

        protected Photo() { }

        public Photo(Guid variantId, string url)
        {
            PhotoId = Guid.NewGuid();
            VariantId = variantId;
            Url = !string.IsNullOrWhiteSpace(url)
                             ? url
                             : throw new ArgumentException("URL required");
            UploadedAt = DateTime.UtcNow;
        }
    }

}
