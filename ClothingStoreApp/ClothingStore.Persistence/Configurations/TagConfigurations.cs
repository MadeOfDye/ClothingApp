using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class TagConfigurations: IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");    
            builder.HasKey(tag => tag.TagId)
                .HasName("PK_Tags");
            var seeds = Enum.GetValues<TagEnum>()
            .Select((enumVal, idx) => new Tag(
                name: enumVal.ToString(),
                ordinal: (int)enumVal
            ))
            .ToArray();

            builder.HasData(seeds);
        }
    }
}
